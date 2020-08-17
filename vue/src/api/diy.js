import request from '@/plugins/request';

/**
 * @description DIY模板列表
 * @param {Object} param data {Object} 传值参数
 */
export function diyList (data) {
    return request({
        url: 'diy/get_list',
        method: 'get',
        params: data
    });
}

/**
 * @description 保存DIY数据
 * @param {Object} param data {Object} 传值参数
 */
export function diySave (id, data) {
    return request({
        url: 'diy/save/' + id,
        method: 'post',
        data: data
    });
}

/**
 * @description 获取DIY数据
 * @param {Object} param data {Object} 传值参数
 */
export function diyGetInfo (id, data) {
    return request({
        url: 'diy/get_info/' + id,
        method: 'get',
        params: data
    });
}

/**
 * @description 删除DIY数据
 * @param {Object} param data {Object} 传值参数
 */
export function diyDel (id) {
    return request({
        url: 'diy/del/' + id,
        method: 'delete'
    });
}

/**
 * @description 使用diy模板
 * @param {Object} param data {Object} 传值参数
 */
export function setStatus (id) {
    return request({
        url: 'diy/set_status/' + id,
        method: 'put'
    });
}

/**
 * @description 获取分类
 */
export function categoryList () {
    return request({
        url: '/cms/category_list',
        method: 'get'
    });
}

/**
 * @description 获取产品分类
 */
export function getCategory () {
    return request({
        url: 'diy/get_category',
        method: 'get'
    });
}

/**
 * @description 获取链接列表
 */
export function getUrl () {
    return request({
        url: 'diy/get_url',
        method: 'get'
    });
}

/**
 * @description 获取商品列表
 */
export function getProduct (data) {
    return request({
        url: 'diy/get_product',
        method: 'get',
        params: data
    });
}
