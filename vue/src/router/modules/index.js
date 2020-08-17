import BasicLayout from '@/layouts/basic-layout';

const meta = {
    auth: true
};

const pre = 'home_';

export default {
    path: '/admin/home',
    name: 'home',
    header: 'home',
    redirect: {
        name: `${pre}index`
    },
    meta,
    component: BasicLayout,
    children: [
        {
            path: '/',
            name: `${pre}index`,
            meta: {
                auth: ['admin-index-index'],
                title: '主页'
            },
            component: () => import('@/pages/index/index')
        }
    ]
};
