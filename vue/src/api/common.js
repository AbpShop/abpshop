import request from '@/plugins/request';

/**
 * @description 表格--删除
 * @param {Number} param id {Number} 配置id
 */
export function tableDelApi (data) {
    return request({
        url: data.url,
        method: data.method,
        data: data.ids
    });
}

/**
 * 获取消息提醒
 */
export function jnoticeRequest () {
    return request({
        url: 'jnotice',
        method: 'GET'
    });
}
