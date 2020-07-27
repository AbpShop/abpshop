using Abp;
using Flurl.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace AbpShop.Third.WeChat
{
    /// <summary>
    /// 微信
    /// </summary>
    public class WeChatRestApi : AbpServiceBase, ITransientDependency
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _conf = null;
        private readonly IDistributedCache<AccessTokenResult, String> _cache;
        private string AppId;
        private string AppSecret;

        /// <summary>
        /// 
        /// </summary>
        public WeChatRestApi(
              Microsoft.Extensions.Configuration.IConfiguration conf,
             IDistributedCache<AccessTokenResult, String> cache
           )
        {
            _cache = cache;
            _conf = conf;
            AppId = _conf["WeChatSetting:WxOpenAppId"];
            AppSecret = _conf["WeChatSetting:WxOpenAppSecret"];
        }
        /// <summary>
        /// 推送微信小程序订阅消息
        /// <param name="openId">接收者（用户）的 openid</param>
        /// <param name="data">模板内容，格式形如 { "key1": { "value": any }, "key2": { "value": any } }</param>
        /// <param name="templateId">所需下发的订阅模板id</param>
        /// <param name="pagePath">点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。</param>
        /// <param name="miniprogramState">跳转小程序类型：developer为开发版；trial为体验版；formal为正式版；默认为正式版</param>
        /// </summary>
        public async Task<bool> PushSubscribeMessage(string openId, object data, string templateId = "Rbw1l47kUiwfI9UI4cFZ8zRHq2tP6GqNB9g5XUsLIOs", string pagePath = "pages/index/index", string miniprogramState = "formal")
        {
            try
            {
                //接口调用凭证
                string access_token = GetAccessTokenResult(AppId).Result.access_token;
                var result = await $"https://api.WeChat.qq.com/cgi-bin/message/subscribe/send?access_token={access_token}"
    .PostJsonAsync(new { touser = openId, template_id = templateId, page = pagePath, data = data, miniprogram_state = miniprogramState })
    .ReceiveJson();

                if (result["errcode"] == ReturnCode.请求成功)
                    return true;
                else
                    Logger.Error($"推送微信小程序订阅消息异常:{result["errmsg"]}");
            }
            catch (Exception ex)
            {
                Logger.Error($"微信消息推送异常: {ex.Message} {ex.StackTrace}");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取当前帐号下的个人模板列表
        /// </summary>
        public async Task<dynamic> GetTemplateList()
        {
            var result = await WeChatRequest($"wxaapi/newtmpl/gettemplate?access_token={WeChat.ACCESS_TOKEN}", true);
            return result.data;
        }
        /// <summary>
        /// 获取可用AccessTokenResult对象
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        private async Task<AccessTokenResult> GetAccessTokenResult(string appId, bool getNewToken = false)
        {
            var accessToken = await _cache.GetAsync(appId);
            if (accessToken == null || getNewToken == true || accessToken.expires_in < DateTime.Now.Second)
            {
                accessToken = await GetTokenAsync();
                _ = _cache.SetAsync(appId, accessToken, new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(accessToken.expires_in)
                });
                return accessToken;
            }
            else
            {
                return accessToken;
            }
        }
        /// <summary>
        /// 【异步方法】获取凭证接口
        /// </summary>
        /// <param name="grant_type">获取access_token填写client_credential</param>
        /// <returns></returns>
        private async Task<AccessTokenResult> GetTokenAsync(string grant_type = "client_credential")
        {
            var url = string.Format("cgi-bin/token?grant_type={0}&appid=[appid]&secret=[secret]",
                                    grant_type);
            return await WeChatRequest(url, true);
        }

        /// <summary>
        /// 微信通过接口处理
        /// <param name="api">微信接口地址</param>
        /// <param name="throwExceptionMsg">当接口返回错误码,是否直接抛出异常</param>
        /// <param name="data">请求数据</param>
        /// </summary>
        private async Task<dynamic> WeChatRequest(string api, bool throwExceptionMsg = true, object data = null)
        {
            try
            {
                WxJsonResult result = new WxJsonResult();
                result.errcode = -1;
                if (api.Contains(WeChat.ACCESS_TOKEN))
                {
                    //接口调用凭证
                    string access_token = GetAccessTokenResult(AppId).Result.access_token;
                    api = api.Replace(WeChat.ACCESS_TOKEN, access_token);
                }
                //如果存在参数appid,就替换
                api = api.Replace(WeChat.APPID, AppId);
                api = $"https://api.WeChat.qq.com/{api}";
                ExpandoObject json = null;
                if (api.Contains("/get"))
                    json = await api.GetJsonAsync();
                else
                    json = await api.PostJsonAsync(data).ReceiveJson();
                //手动映射
                if (json != null)
                {
                    if (json.Any(pair => pair.Key == "errcode"))
                        result.errcode = int.Parse(json.Single(pair => pair.Key == "errcode").Value.ToString());
                    if (json.Any(pair => pair.Key == "errmsg"))
                        result.errmsg = json.Single(pair => pair.Key == "errmsg").Value.ToString();
                    if (json.Any(pair => pair.Key == "data"))
                        result.data = json.Single(pair => pair.Key == "data").Value;
                    if (json.Any(pair => pair.Key == "count"))
                        result.count = int.Parse(json.Single(pair => pair.Key == "count").Value.ToString());
                }
                //调用日志处理
                String loggerMsg = $"微信小程序调用接口异常{api} 请求数据{JsonConvert.SerializeObject(data)} 返回数据 {JsonConvert.SerializeObject(result)}";
                if (result.errcode == 0)
                    Logger.Info(loggerMsg);
                else
                {
                    Logger.Error(loggerMsg);
                    if (throwExceptionMsg)
                        throw new UserFriendlyException(result.errmsg);
                }
                //抛出异常,返回数据
                if (throwExceptionMsg)
                    return result.data;
                else
                    return result;
            }
            catch (Exception ex)
            {
                Logger.Error(JsonConvert.SerializeObject(ex));
                throw new UserFriendlyException("微信接口开小差了");
            }

        }
    }
}
