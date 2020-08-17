import BasicLayout from '@/layouts/basic-layout';

const meta = {
    auth: true
};

const pre = 'setting_';

export default {
    path: '/admin/setting',
    name: 'setting',
    header: 'setting',
    redirect: {
        name: `${pre}systemRole`
    },
    component: BasicLayout,
    children: [
        {
            path: 'system_role/index',
            name: `${pre}systemRole`,
            meta: {
                auth: ['setting-system-role'],
                title: '身份管理'
            },
            component: () => import('@/pages/setting/systemRole/index')
        },
        {
            path: 'system_admin/index',
            name: `${pre}systemAdmin`,
            meta: {
                auth: ['setting-system-list'],
                title: '管理员管理'
            },
            component: () => import('@/pages/setting/systemAdmin/index')
        },
        {
            path: 'system_menus/index',
            name: `${pre}systemMenus`,
            meta: {
                auth: ['setting-system-menus'],
                title: '权限规则'
            },
            component: () => import('@/pages/setting/systemMenus/index')
        },
        {
            path: 'system_config',
            name: `${pre}setSystem`,
            meta: {
                auth: ['setting-system-config'],
                title: '系统设置'
            },
            component: () => import('@/pages/setting/setSystem/index')
        },
        {
            path: 'system_config/:type?/:tab_id?',
            name: `${pre}setApp`,
            meta: {
                ...meta,
                title: '应用设置'
            },
            component: () => import('@/pages/setting/setSystem/index')
        },
        {
            path: 'system_config/payment/:type?/:tab_id?',
            name: `${pre}payment`,
            meta: {
                ...meta,
                title: '支付配置'
            },
            component: () => import('@/pages/setting/setSystem/index')
        },
        {
            path: 'system_config_retail/:type?/:tab_id?',
            name: `${pre}distributionSet`,
            meta: {
                ...meta,
                title: '分销设置'
            },
            component: () => import('@/pages/setting/setSystem/index')
        },
        {
            path: 'sms/sms_config/index',
            name: `${pre}config`,
            meta: {
                auth: ['setting-sms-sms-config'],
                title: '短信账户'
            },
            component: () => import('@/pages/notify/smsConfig/index')
        },
        {
            path: 'sms/sms_template_apply/index',
            name: `${pre}smsTemplateApply`,
            meta: {
                auth: ['setting-sms-config-template'],
                title: '短信模板'
            },
            component: () => import('@/pages/notify/smsTemplateApply/index')
        },
        {
            path: 'sms/sms_pay/index',
            name: `${pre}smsPay`,
            meta: {
                auth: ['setting-sms-sms-template'],
                title: '短信购买'
            },
            component: () => import('@/pages/notify/smsPay/index')
        },
        {
            path: 'sms/sms_template_apply/commons',
            name: `${pre}commons`,
            meta: {
                ...meta,
                title: '公共短信模板'
            },
            component: () => import('@/pages/notify/smsTemplateApply/index')
        },
        {
            path: 'system_group_data/index/:id',
            name: `${pre}groupDataIndex`,
            meta: {
                auth: ['setting-system-group_data-index'],
                title: '首页导航按钮'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/slide/:id',
            name: `${pre}groupDataSlide`,
            meta: {
                auth: ['setting-system-group_data-slide'],
                title: '首页幻灯片'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/sign/:id',
            name: `${pre}groupDataSign`,
            meta: {
                auth: ['setting-system-group_data-sign'],
                title: '签到天数配置'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/order/:id',
            name: `${pre}groupDataOrder`,
            meta: {
                auth: ['setting-system-group_data-order'],
                title: '订单详情动态图'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/user/:id',
            name: `${pre}groupDataUser`,
            meta: {
                auth: ['setting-system-group_data-user'],
                title: '个人中心菜单'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/new/:id',
            name: `${pre}groupDataNew`,
            meta: {
                auth: ['setting-system-group_data-new'],
                title: '首页滚动新闻'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/hot/:id',
            name: `${pre}groupDataHot`,
            meta: {
                auth: ['setting-system-group_data-hot'],
                title: '热门榜单推荐'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/new_product/:id',
            name: `${pre}groupDataNewProduct`,
            meta: {
                auth: ['setting-system-group_data-new_product'],
                title: '首发新品推荐'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/promotion/:id',
            name: `${pre}groupDataPromotion`,
            meta: {
                auth: ['setting-system-group_data-promotion'],
                title: '促销单品推荐'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/poster/:id',
            name: `${pre}groupDataPoster`,
            meta: {
                auth: ['setting-system-group_data-poster'],
                title: '个人中心分销海报'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/best/:id',
            name: `${pre}groupDataBest`,
            meta: {
                auth: ['setting-system-group_data-best'],
                title: '精品推荐'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/activity/:id',
            name: `${pre}groupDataActivity`,
            meta: {
                auth: ['setting-system-group_data-activity'],
                title: '首页活动区域图片'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/system/:id',
            name: `${pre}groupDataSystem`,
            meta: {
                auth: ['setting-system-group_data-system'],
                title: '首页配置'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'system_group_data/hot_money/:id',
            name: `${pre}groupDataHotMoney`,
            meta: {
                auth: ['admin-setting-system_group_data-hot_money'],
                title: '首页超值爆款'
            },
            component: () => import('@/pages/system/group/list')
        },
        {
            path: 'merchant/system_store/index',
            name: `${pre}systemStore`,
            meta: {
                auth: ['setting-system-config-merchant'],
                title: '门店设置'
            },
            component: () => import('@/pages/setting/systemStore/index')
        },
        {
            path: 'freight/express/index',
            name: `${pre}freight`,
            meta: {
                auth: ['setting-freight-express'],
                title: '物流公司'
            },
            component: () => import('@/pages/setting/freight/index')
        },
        {
            path: 'store_service/index',
            name: `${pre}service`,
            meta: {
                auth: ['setting-store-service'],
                title: '客服管理'
            },
            component: () => import('@/pages/setting/storeService/index')
        },
        {
            path: 'freight/city/list',
            name: `${pre}dada`,
            meta: {
                auth: ['setting-system-city'],
                title: '城市数据'
            },
            component: () => import('@/pages/setting/cityDada/index')
        },
        {
            path: 'freight/shipping_templates/list',
            name: `${pre}templates`,
            meta: {
                auth: ['setting-shipping-templates'],
                title: '运费模板'
            },
            component: () => import('@/pages/setting/shippingTemplates/index')
        },
        {
            path: 'merchant/system_store/list',
            name: `${pre}store`,
            meta: {
                auth: ['setting-merchant-system-store'],
                title: '提货点列表'
            },
            component: () => import('@/pages/setting/storeList/index')
        },
        {
            path: 'merchant/system_store_staff/index',
            name: `${pre}staff`,
            meta: {
                auth: ['setting-merchant-system-store-staff'],
                title: '核销员管理'
            },
            component: () => import('@/pages/setting/clerkList/index')
        },
        {
            path: 'merchant/system_verify_order/index',
            name: `${pre}order`,
            meta: {
                auth: ['setting-merchant-system-verify-order'],
                title: '核销订单'
            },
            component: () => import('@/pages/setting/verifyOrder/index')
        }
    ]
};
