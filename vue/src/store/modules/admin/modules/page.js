/**
 * 多标签页
 * */
import { get } from 'lodash';
import router from '@/router';
import Setting from '@/setting';
import menuSider from '@/menu/sider';
import { getAllSiderMenu, includeArray } from '@/libs/system';

// 判定是否需要缓存
const isKeepAlive = data => get(data, 'meta.cache', false);

export default {
    namespaced: true,
    state: {
        // 可以在多页 tab 模式下显示的页面
        pool: [],
        // 当前显示的多页面列表
        opened: Setting.page.opened,
        // 当前页面
        current: '',
        // 需要缓存的页面 name
        keepAlive: []
    },
    actions: {
        /**
         * @description 从持久化数据载入分页列表
         */
        openedLoad ({ state, commit, dispatch, rootState }) {
            return new Promise(async resolve => {
                // store 赋值
                const value = await dispatch('admin/db/get', {
                    dbName: 'sys',
                    path: 'page.opened',
                    defaultValue: Setting.page.opened,
                    user: true
                }, { root: true });
                // 在处理函数中进行数据优化 过滤掉现在已经失效的页签或者已经改变了信息的页签
                // 以 fullPath 字段为准
                // 如果页面过多的话可能需要优化算法
                // valid 有效列表 1, 1, 0, 1 => 有效, 有效, 失效, 有效
                const valid = [];
                // 处理数据
                state.opened = value.map(opened => {
                    // 忽略首页
                    if (opened.fullPath === '/index') {
                        valid.push(1);
                        return opened;
                    }
                    // 尝试在所有的支持多标签页的页面里找到 name 匹配的页面
                    const find = state.pool.find(item => item.name === opened.name);
                    // 记录有效或无效信息
                    valid.push(find ? 1 : 0);
                    // 返回合并后的数据 新的覆盖旧的
                    // 新的数据中一般不会携带 params 和 query, 所以旧的参数会留存
                    return Object.assign({}, opened, find);
                })
                    .filter((opened, index) => valid[index] === 1)
                    // 对 menu 鉴权过滤
                    .filter(opened => {
                        const allSiderMenu = getAllSiderMenu(menuSider);
                        const find = allSiderMenu.find(item => item.path === opened.fullPath);

                        let state = true;
                        if (find && find.auth) {
                            const userInfo = rootState.admin.user.info;
                            // @权限
                            const access = userInfo.access;
                            // 如果用户当前的权限，不是该 menu 对应的 权限，则过滤这个 Tab
                            if (access && !includeArray(find.auth, access)) state = false;
                        }
                        return state;
                });
                // 根据 opened 数据生成缓存设置
                commit('keepAliveRefresh');
                // end
                resolve();
            });
        },
        /**
         * 将 opened 属性赋值并持久化 在这之前请先确保已经更新了 state.opened
         */
        opened2db ({ state, dispatch }) {
            return new Promise(async resolve => {
                // 设置数据
                dispatch('admin/db/set', {
                    dbName: 'sys',
                    path: 'page.opened',
                    value: state.opened,
                    user: true
                }, { root: true });
                // end
                resolve();
            });
        },
        /**
         * @description 更新页面列表上的某一项
         * @param {Object} param { index, params, query, fullPath } 路由信息
         */
        openedUpdate ({ state, commit, dispatch }, { index, params, query, fullPath, meta }) {
            return new Promise(async resolve => {
                // 更新页面列表某一项
                let page = state.opened[index];
                page.params = params || page.params;
                page.query = query || page.query;
                page.fullPath = fullPath || page.fullPath;
                page.meta = meta || page.meta;
                state.opened.splice(index, 1, page);
                // 持久化
                await dispatch('opened2db');
                // end
                resolve();
            });
        },
        /**
         * @description 新增一个 tag (打开一个页面)
         * @param {Object} param new tag info
         */
        add ({ state, commit, dispatch }, { tag, params, query, fullPath }) {
            return new Promise(async resolve => {
                // 设置新的 tag 在新打开一个以前没打开过的页面时使用
                let newTag = tag;
                newTag.params = params || newTag.params;
                newTag.query = query || newTag.query;
                newTag.fullPath = fullPath || newTag.fullPath;
                // 添加进当前显示的页面数组
                if (typeof newTag.query.fodder === 'undefined') state.opened.push(newTag);
                // 如果这个页面需要缓存 将其添加到缓存设置
                if (isKeepAlive(newTag)) {
                    commit('keepAlivePush', tag.name);
                }
                // 持久化
                await dispatch('opened2db');
                // end
                resolve();
            });
        },
        /**
         * @description 打开一个新的页面
         * @param {Object} param 从路由钩子的 to 对象上获取 { name, params, query, fullPath } 路由信息
         */
        open ({ state, commit, dispatch }, { name, params, query, fullPath }) {
            return new Promise(async resolve => {
                // 已经打开的页面
                let opened = state.opened;
                // 判断此页面是否已经打开 并且记录位置
                let pageOpenedIndex = 0;
                const pageOpened = opened.find((page, index) => {
                    const same = page.fullPath === fullPath;
                    pageOpenedIndex = same ? index : pageOpenedIndex;
                    return same;
                });
                if (pageOpened) {
                    // 页面以前打开过
                    await dispatch('openedUpdate', {
                        index: pageOpenedIndex,
                        params,
                        query,
                        fullPath
                    });
                } else {
                    // 页面以前没有打开过
                    let page = state.pool.find(t => t.name === name);
                    // 如果这里没有找到 page 代表这个路由虽然在框架内 但是不参与标签页显示
                    if (page) {
                        await dispatch('add', {
                            tag: Object.assign({}, page),
                            params,
                            query,
                            fullPath
                        });
                    }
                }
                commit('currentSet', fullPath);
                // end
                resolve();
            });
        },
        /**
         * @description 关闭一个 tag (关闭一个页面)
         * @param {Object} param { tagName: 要关闭的标签名字 }
         */
        close ({ state, commit, dispatch }, { tagName }) {
            return new Promise(async resolve => {
                // 下个新的页面
                let newPage = state.opened[0];
                const isCurrent = state.current === tagName;
                // 如果关闭的页面就是当前显示的页面
                if (isCurrent) {
                    // 去找一个新的页面
                    let len = state.opened.length;
                    for (let i = 0; i < len; i++) {
                        if (state.opened[i].fullPath === tagName) {
                            // 是否只剩最后一个，是则跳首页
                            if (len > 1) {
                                // 如果是最后一个，则向前一个跳，否则向下一个跳
                                if (i === len - 1) {
                                    newPage = state.opened[i - 1];
                                } else {
                                    newPage = state.opened[i + 1];
                                }
                            } else {
                                newPage = {};
                            }
                            break;
                        }
                    }
                }
                // 找到这个页面在已经打开的数据里是第几个
                const index = state.opened.findIndex(page => page.fullPath === tagName);
                if (index >= 0) {
                    // 如果这个页面是缓存的页面 将其在缓存设置中删除
                    commit('keepAliveRemove', state.opened[index].name);
                    // 更新数据 删除关闭的页面
                    state.opened.splice(index, 1);
                }
                // 持久化
                await dispatch('opened2db');
                // 最后需要判断是否需要跳到首页
                if (isCurrent) {
                    const { name = 'home_index', params = {}, query = {} } = newPage;
                    let routerObj = {
                        name,
                        params,
                        query
                    };
                    router.push(routerObj);
                }
                // end
                resolve();
            });
        },
        /**
         * @description 关闭当前标签左边的标签
         * @param {Object} param { pageSelect: 当前选中的tagName }
         */
        closeLeft ({ state, commit, dispatch }, { pageSelect } = {}) {
            return new Promise(async resolve => {
                const pageAim = pageSelect || state.current;
                let currentIndex = 0;
                state.opened.forEach((page, index) => {
                    if (page.fullPath === pageAim) {
                        currentIndex = index;
                    }
                });
                if (currentIndex > 0) {
                    // 删除打开的页面 并在缓存设置中删除
                    state.opened.splice(1, currentIndex - 1).forEach(({ name }) => commit('keepAliveRemove', name));
                }
                state.current = pageAim;
                if (router.app.$route.fullPath !== pageAim) {
                    router.push(pageAim);
                }
                // 持久化
                await dispatch('opened2db');
                // end
                resolve();
            });
        },
        /**
         * @description 关闭当前标签右边的标签
         * @param {Object} param { pageSelect: 当前选中的tagName }
         */
        closeRight ({ state, commit, dispatch }, { pageSelect } = {}) {
            return new Promise(async resolve => {
                const pageAim = pageSelect || state.current;
                let currentIndex = 0;
                state.opened.forEach((page, index) => {
                    if (page.fullPath === pageAim) {
                        currentIndex = index;
                    }
                });
                // 删除打开的页面 并在缓存设置中删除
                state.opened.splice(currentIndex + 1).forEach(({ name }) => commit('keepAliveRemove', name));
                // 设置当前的页面
                state.current = pageAim;
                if (router.app.$route.fullPath !== pageAim) {
                    router.push(pageAim);
                }
                // 持久化
                await dispatch('opened2db');
                // end
                resolve();
            });
        },
        /**
         * @description 关闭当前激活之外的 tag
         * @param {Object} param { pageSelect: 当前选中的tagName }
         */
        closeOther ({ state, commit, dispatch }, { pageSelect } = {}) {
            return new Promise(async resolve => {
                const pageAim = pageSelect || state.current;
                let currentIndex = 0;
                state.opened.forEach((page, index) => {
                    if (page.fullPath === pageAim) {
                        currentIndex = index;
                    }
                });
                // 删除打开的页面数据 并更新缓存设置
                if (currentIndex === 0) {
                    state.opened.splice(1).forEach(({ name }) => commit('keepAliveRemove', name));
                } else {
                    state.opened.splice(currentIndex + 1).forEach(({ name }) => commit('keepAliveRemove', name));
                    state.opened.splice(1, currentIndex - 1).forEach(({ name }) => commit('keepAliveRemove', name));
                }
                // 设置新的页面
                state.current = pageAim;
                if (router.app.$route.fullPath !== pageAim) {
                    router.push(pageAim);
                }
                // 持久化
                await dispatch('opened2db');
                // end
                resolve();
            });
        },
        /**
         * @description 关闭所有 tag
         * @param {Object} state vuex state
         */
        closeAll ({ state, commit, dispatch }) {
            return new Promise(async resolve => {
                // 删除打开的页面 并在缓存设置中删除
                state.opened.splice(1).forEach(({ name }) => commit('keepAliveRemove', name));
                // 持久化
                await dispatch('opened2db');
                // 关闭所有的标签页后需要判断一次现在是不是在首页
                if (router.app.$route.name !== '/admin/home') {
                    router.push({
                        name: 'home_index'
                    });
                }
                // end
                resolve();
            });
        }
    },
    mutations: {
        /**
         * @class keepAlive
         * @description 从已经打开的页面记录中更新需要缓存的页面记录
         * @param {Object} state vuex state
         */
        keepAliveRefresh (state) {
            state.keepAlive = state.opened.filter(item => isKeepAlive(item)).map(e => e.name);
        },
        /**
         * @description 删除一个页面的缓存设置
         * @param {Object} state vuex state
         * @param {String} name name
         */
        keepAliveRemove (state, name) {
            const list = [ ...state.keepAlive ];
            const index = list.findIndex(item => item === name);

            if (index !== -1) {
                list.splice(index, 1);
                state.keepAlive = list;
            }
        },
        /**
         * @description 增加一个页面的缓存设置
         * @param {Object} state vuex state
         * @param {String} name name
         */
        keepAlivePush (state, name) {
            const keep = [ ...state.keepAlive ];
            keep.push(name);
            state.keepAlive = keep;
        },
        /**
         * @description 清空页面缓存设置
         * @param {Object} state vuex state
         */
        keepAliveClean (state) {
            state.keepAlive = [];
        },
        /**
         * @class current
         * @description 设置当前激活的页面 fullPath
         * @param {Object} state vuex state
         * @param {String} fullPath new fullPath
         */
        currentSet (state, fullPath) {
            state.current = fullPath;
        },
        /**
         * @class pool
         * @description 保存 pool (候选池)
         * @param {Object} state vuex state
         * @param {Array} routes routes
         */
        init (state, routes) {
            const pool = [];
            const push = function (routes) {
                routes.forEach(route => {
                    if (route.children) {
                        push(route.children);
                    } else {
                        if (!route.hidden) {
                            const { meta, name, path } = route;
                            pool.push({ meta, name, path });
                        }
                    }
                })
            };
            push(routes);
            state.pool = pool;
        }
    }
}
