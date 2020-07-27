using System;
using System.Collections.Generic;
using System.Text;

namespace AbpShop.Third.WeChat
{
    /// <summary>
    /// 微信通用定义
    /// </summary>
    public class WeChat
    {
        public const string APPID = "[appid]"; //参数名约束规则定义
        public const string ACCESS_TOKEN = "[access_token]"; //参数名约束规则定义
    }

    /// <summary>
    /// 订阅消息模板
    /// </summary>
    public class SubscribeTemplate
    {
        Dictionary<string, string> Template { get; set; } // key 模板标题 value 模板id
        List<string> KeyWords { get; set; } //模板字段
        int Type { get; set; } //模版类型，2 为一次性订阅，3 为长期订阅
        string Example { get; set; } //模板内容示例
    }

    /// <summary>
    /// access_token请求后的JSON返回格式
    /// </summary>
    public class AccessTokenResult : WxJsonResult
    {
        public string access_token { get; set; }  //获取到的凭证
        public int expires_in { get; set; }  //凭证有效时间，单位：秒
    }

    /// <summary>
    /// 小程序返回结果
    /// </summary>
    public class WxJsonResult
    {
        public int errcode { get; set; } //错误码
        public string errmsg { get; set; } //错误信息
        public dynamic data { get; set; } //返回数据
        public int count { get; set; } //总数
    }
}
