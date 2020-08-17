import index from './modules/index';
import product from './modules/product';
import order from './modules/order';
import user from './modules/user';
import echarts from './modules/echarts';
import setting from './modules/setting';
import agent from './modules/agent';
import finance from './modules/finance';
import cms from './modules/cms';
import marketing from './modules/marketing';
import app from './modules/app';
import system from './modules/system';
import BasicLayout from '@/layouts/basic-layout';

/**
 * 在主框架内显示
 */

const frameIn = [
    {
        path: '/admin/',
        meta: {
            title: 'AbpShop'
        },
        redirect: {
            name: 'home_index'
        },
        component: BasicLayout,
        children: [
            {
                path: '/admin/system/log',
                name: 'log',
                meta: {
                    title: '前端日志',
                    auth: true
                },
                component: () => import('@/pages/system/log')
            },
            {
                path: '/admin/system/user',
                name: `systemUser`,
                meta: {
                    auth: true,
                    title: '个人中心'
                },
                component: () => import('@/pages/setting/user/index')
            },
            // 刷新页面 必须保留
            {
                path: 'refresh',
                name: 'refresh',
                hidden: true,
                component: {
                    beforeRouteEnter(to, from, next) {
                        next(instance => instance.$router.replace(from.fullPath));
                    },
                    render: h => h()
                }
            },
            // 页面重定向 必须保留
            {
                path: 'redirect/:route*',
                name: 'redirect',
                hidden: true,
                component: {
                    beforeRouteEnter(to, from, next) {
                        next(instance => instance.$router.replace(JSON.parse(from.params.route)));
                    },
                    render: h => h()
                }
            }
        ]
    },
    {
        path: '/admin/widget.images/index.html',
        name: `images`,
        meta: {
            auth: true,
            title: '上传图片'
        },
        component: () => import('@/components/uploadPictures/widgetImg')
    },
    {
        path: '/admin/widget.widgets/icon.html',
        name: `imagesIcon`,
        meta: {
            auth: true,
            title: '上传图标'
        },
        component: () => import('@/components/iconFrom/index')
    },
    {
        path: '/admin/store.StoreProduct/index.html',
        name: `storeProduct`,
        meta: {
            title: '选择商品'
        },
        component: () => import('@/components/goodsList/index')
    },
    {
        path: '/admin/system.User/list.html',
        name: `changeUser`,
        meta: {
            title: '选择用户'
        },
        component: () => import('@/components/customerInfo/index')
    },
    {
        path: '/admin/widget.video/index.html',
        name: `video`,
        meta: {
            title: '上传视频'
        },
        component: () => import('@/components/uploadVideo/index')
    },
    index,
    product,
    order,
    user,
    echarts,
    setting,
    agent,
    finance,
    cms,
    marketing,
    app,
    system
];

/**
 * 在主框架之外显示
 */

const frameOut = [
    // 登录
    {
        path: '/admin/login',
        name: 'login',
        meta: {
            title: '$t:page.login.title'
        },
        component: () => import('@/pages/account/login')
    }

];

/**
 * 错误页面
 */

const errorPage = [
    {
        path: '/admin/403',
        name: '403',
        meta: {
            title: '403'
        },
        component: () => import('@/pages/system/error/403')
    },
    {
        path: '/admin/500',
        name: '500',
        meta: {
            title: '500'
        },
        component: () => import('@/pages/system/error/500')
    },
    {
        path: '/admin/*',
        name: '404',
        meta: {
            title: '404'
        },
        component: () => import('@/pages/system/error/404')
    }
];

// 导出需要显示菜单的
export const frameInRoutes = frameIn;

// 重新组织后导出
export default [
    ...frameIn,
    ...frameOut,
    ...errorPage
];
