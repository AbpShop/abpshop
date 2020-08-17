import request from '@/plugins/request';

/**
 * @description 订单管理--列表
 * @param {Object} param data {Object} 传值参数
 */
export function orderList (data) {
    return request({
        url: '/order/list',
        method: 'get',
        params: data
    });
};

/**
 * @description 订单数据--列表
 * @param {Object} param data {Object} 传值参数
 */
export function getOrdes (data) {
    return request({
        url: '/order/chart',
        method: 'get',
        params: data
    });
};

/**
 * @description 订单表单编辑数据
 * @param {Number} param id {Number} 订单id
 */
export function getOrdeDatas (id) {
    return request({
        url: `/order/edit/${id}`,
        method: 'get'
    });
};

/**
 * @description 订单表单详情数据
 * @param {Number} param id {Number} 订单id
 */
export function getDataInfo (id) {
    return request({
        url: `/order/info/${id}`,
        method: 'get'
    });
};

/**
 * @description 修改备注信息
 * @param {Number} param data.id {Number} 订单id
 * @param {String} param data.remark {String} 备注信息
 */
export function putRemarkData (data) {
    return request({
        url: `/order/remark/${data.id}`,
        method: 'put',
        data: data.remark
    });
};

/**
 * @description 获取订单记录
 * @param {Number} param data.id {Number} 订单id
 * @param {String} param data.datas {String} 分页参数
 */
export function getOrderRecord (data) {
    return request({
        url: `/order/status/${data.id}`,
        method: 'get',
        params: data.datas
    });
};

/**
 * @description 获取退款表单数据
 * @param {Number} param id {Number} 订单id
 */
export function getRefundFrom (id) {
    return request({
        url: `/order/refund/${id}`,
        method: 'get'
    });
};

/**
 * @description 获取快递公司
 */
export function getExpressData () {
    return request({
        url: `/order/express_list`,
        method: 'get'
    });
};

/**
 * @description 获取不退款表单数据
 * @param {Number} param id {Number} 订单id
 */
export function getnoRefund (id) {
    return request({
        url: `/order/no_refund/${id}`,
        method: 'get'
    });
};

/**
 * @description 发送货提交表单
 * @param {Number} param data.id {Number} 订单id
 * @param {Object} param data.datas {Object} 表单信息
 */
export function putDelivery (data) {
    return request({
        url: `/order/delivery/${data.id}`,
        method: 'put',
        data: data.datas
    });
};

/**
 * @description 获取退积分表单
 * @param {Number} param id {Number} 订单id
 */
export function refundIntegral (id) {
    return request({
        url: `/order/refund_integral/${id}`,
        method: 'get'
    });
};

/**
 * @description 立即支付
 * @param {String} param path {String} 请求地址
 * @param {String} param method {String} 请求方式
 */
export function payOffline (path, method) {
    return request({
        url: path,
        method: method
    });
};

/**
 * @description 配送信息表单
 * @param {Number} param id {Number} 订单id
 */
export function getDistribution (id) {
    return request({
        url: `/order/distribution/${id}`,
        method: 'get'
    });
};

/**
 * @description 订单物流信息
 * @param {Number} param id {Number} 订单id
 */
export function getExpress (id) {
    return request({
        url: `/order/express/${id}`,
        method: 'get'
    });
};

/**
 * @description  订单核销
 * @param {String} param data {String} 核销内容
 */
export function putWrite (data) {
    return request({
        url: '/order/write',
        method: 'post',
        data: data
    });
}

/**
 * @description 订单管理 -- 导出
 */
export function storeOrderApi (data) {
    return request({
        url: `export/storeOrder`,
        method: 'get',
        params: data
    });
}
