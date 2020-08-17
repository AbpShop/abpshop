import BasicLayout from '@/layouts/basic-layout';

const meta = {
    auth: true
};

const pre = 'user_';

export default {
    path: '/admin/user',
    name: 'user',
    header: 'user',
    redirect: {
        name: `${pre}list`
    },
    meta,
    component: BasicLayout,
    children: [
        {
            path: 'list',
            name: `${pre}list`,
            meta: {
                auth: ['admin-user-user-index'],
                title: '会员管理'
            },
            component: () => import('@/pages/user/list/index')
        },
        {
            path: 'level',
            name: `${pre}level`,
            meta: {
                auth: ['user-user-level'],
                footer: true,
                title: '会员等级'
            },
            component: () => import('@/pages/user/level/index')
        },
        {
            path: 'group',
            name: `${pre}group`,
            meta: {
                auth: ['user-user-group'],
                footer: true,
                title: '会员分组'
            },
            component: () => import('@/pages/user/group/index')
        },
        {
            path: 'label',
            name: `${pre}label`,
            meta: {
                auth: ['user-user-label'],
                footer: true,
                title: '会员标签'
            },
            component: () => import('@/pages/user/label/index')
        }
    ]
};
