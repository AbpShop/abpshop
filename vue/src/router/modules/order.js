import BasicLayout from '@/layouts/basic-layout';

const pre = 'order_';

export default {
    path: '/admin/order',
    name: 'order',
    header: 'order',
    redirect: {
        name: `${pre}list`
    },
    component: BasicLayout,
    children: [
        {
            path: 'list',
            name: `${pre}list`,
            meta: {
                auth: ['admin-order-storeOrder-index'],
                title: '订单管理'
            },
            component: () => import('@/pages/order/orderList/index')
        }
    ]
};
