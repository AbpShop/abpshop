import store from '@/store';
import util from '@/libs/util';
import axios from 'axios';

export default {
    install (Vue, options) {
        Vue.config.errorHandler = function (error, instance, info) {
            Vue.nextTick(() => {
                // store 追加 log
                store.dispatch('admin/log/push', {
                    message: `${info}: ${error.message}`,
                    type: 'error',
                    meta: {
                        error
                        // instance
                    }
                });
                axios.post('http://yznt.com/api/error', { instance, error, info }).then(res => {
                    console.log(res.msg || '错误已收集');
                }).catch(() => {
                    // console.log(err);
                });
                // 只在开发模式下打印 log
                if (process.env.NODE_ENV === 'development') {
                    util.log.capsule('iView Admin', 'ErrorHandler', 'error');
                    util.log.error('>>>>>> 错误信息 >>>>>>');
                    console.log(info);
                    util.log.error('>>>>>> Vue 实例 >>>>>>');
                    console.log(instance);
                    util.log.error('>>>>>> Error >>>>>>');
                    console.log(error)
                }
            })
        }
    }
}
