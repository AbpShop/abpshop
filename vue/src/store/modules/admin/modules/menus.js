/**
 * 布局菜单配置
 * */
import { menusApi } from '@/api/account';

function getMenusName () {
    let storage = window.localStorage, menuList = storage.getItem('menuList'), menuData = []
    try {
        menuData = menuList !== undefined ? JSON.parse(menuList) : [];
    } catch (e) {}
    if (typeof menuData !== 'object' || menuData === null) {
        menuData = []
    }
    return menuData
}

export default {
    namespaced: true,
    state: {
        menusName: getMenusName()
    },
    mutations: {
        getmenusNav (state, menuList) {
            state.menusName = menuList;
            let storage = window.localStorage;
            storage.setItem('menuList', JSON.stringify(menuList));
        }
    },
    actions: {
        getMenusNavList ({ commit }) {
            return new Promise((resolve, reject) => {
                menusApi().then(async res => {
                    resolve(res);
                    commit('getmenusNav', res.data.menus);
                    let storage = window.localStorage;
                    storage.setItem('menuList', JSON.stringify(res.data.menus));
                }).catch(res => {
                    reject(res);
                })
            })
        }
    }
};
