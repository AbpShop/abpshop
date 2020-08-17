import request from '@/plugins/request';

/**
 * @description 分销 -- 列表
 * @param {Object} param params {Object} 传值参数
 */
export function agentListApi (params) {
    return request({
        url: 'agent/index',
        method: 'get',
        params
    });
}

/**
 * @description 分销 -- 表头
 * @param {Object} param params {Object} 传值参数
 */
export function statisticsApi (params) {
    return request({
        url: 'agent/statistics',
        method: 'get',
        params
    });
}

/**
 * @description 分销 -- 推广人,订单列表
 * @param {Object} param params {Object} 传值参数
 * @param {String} param url {String} 请求地址
 */
export function stairListApi (url, params) {
    return request({
        url: url,
        method: 'get',
        params
    });
}

/**
 * @description 分销 -- 公众号推广二维码
 * @param {Object} param params {Object} 传值参数
 */
export function lookCodeApi (params) {
    return request({
        url: 'agent/look_code',
        method: 'get',
        params
    });
}

/**
 * @description 分销 -- 小程序推广二维码
 * @param {Object} param params {Object} 传值参数
 */
export function lookxcxCodeApi (params) {
    return request({
        url: 'agent/look_xcx_code',
        method: 'get',
        params
    });
}

/**
 * @description 分销 -- h5推广二维码
 * @param {Object} param params {Object} 传值参数
 */
export function lookh5CodeApi (params) {
    return request({
        url: 'agent/look_h5_code',
        method: 'get',
        params
    });
}

/**
 * @description 分销 -- 用户推广列表导出
 */
export function userAgentApi (data) {
    return request({
        url: `export/userAgent`,
        method: 'get',
        params: data
    });
}
