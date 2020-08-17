/**
 * diy自定义组件
 * */
export default {
    namespaced: true,
    state: {
        configName: '',
        // 已知组件列表默认数据 数组
        defaultArray: {}

    },
    mutations: {
        /**
         * @description 默认配置push到数组里面
         * @param {Object} state vuex state
         * @param {Object} data
         * 把默认数据添加到默认数组里面，解耦重复组件公用一条配置的问题
         */
        ADDARRAY (state, data) {
            state.defaultArray[data.num] = data.val
        },
        /**
         * @description 删除列表第几个默认数据
         * @param {Object} state vuex state
         * @param {Object} data 数据
         */
        DELETEARRAY (state, data) {
            let tempObj = delete state.defaultArray[data.num]
            console.log(tempObj)
            // state.defaultArray.splice(index, 1)
        },
        /**
         * @description 数组排序
         * @param {Object} state vuex state
         * @param {Object} data 位置index记录
         */
        defaultArraySort (state, data) {

            let newArr = objToArr(state.defaultArray)
            let sortArr = []
            let newObj = {}
            function objToArr (data) {
                let obj = Object.keys(data);
                let m = obj.map(key => data[key]);
                return m
            }
            function swapArray (arr, index1, index2) {
                arr[index1] = arr.splice(index2, 1, arr[index1])[0];
                return arr;
            }
            if (data.oldIndex != undefined) {
                sortArr = JSON.parse(JSON.stringify(swapArray(newArr, data.newIndex, data.oldIndex)))
            } else {
                newArr.splice(data.newIndex, 0, data.element.data().defaultConfig);
                sortArr = JSON.parse(JSON.stringify(newArr))
            }
            for (let i = 0; i < sortArr.length; i++) {
                newObj[sortArr[i].timestamp] = sortArr[i];
            }
            console.log(newObj, 'newObj')
            state.defaultArray = newObj;
        },
        /**
         * @description 更新数组某一组数据
         * @param {Object} state vuex state
         * @param {Object} data
         */
        UPDATEARR (state, data) {
            console.log(data, 'UPDATEARR')
            state.defaultArray[data.num] = data.val
            let value = Object.assign({}, state.defaultArray);
            state.defaultArray = value;
        },
        /**
         * @description 保存组件名称
         * @param {Object} state vuex state
         * @param {string} data
         */
        SETCONFIGNAME (state, name) {
            state.configName = name;
        },
        /**
         * @description 默认组件清空
         * @param {Object} state vuex state
         * @param {string} data
         */
        SETEMPTY (state, name) {
            state.defaultArray = {};
        }
    },
    actions: {
        getData ({ commit }, data) {
            console.log(data, 'actions')
        }
    }
}
