<template>
    <div>
        <PageHeader class="product_tabs" :title="$route.meta.title" hidden-breadcrumb>
            <div slot="title">
                <router-link :to="{path:'/admin/setting/pages/devise'}"><Button icon="ios-arrow-back" size="small"  class="mr20">返回</Button></router-link>
                <span v-text="$route.meta.title" class="mr20"></span>
            </div>
        </PageHeader>
        <Card :bordered="false" dis-hover class="ivu-mt" style="width: 100%;">
            <div class="diy-wrapper">
                <!-- 左侧 -->
                <div class="left">
                    <div class="title-bar">组件库</div>
                    <div class="wrapper">
                        <div v-for="(item,index) in  leftMenu" :key="index">
                            <div class="tips">{{item.title}}</div>
                            <draggable
                                    class="dragArea list-group"
                                    :list="item.list"
                                    :group="{ name: 'people', pull: 'clone', put: false }"
                                    :clone="cloneDog"
                                    @change="log"
                            >
                                <div class="list-group-item" v-for="(element,index) in item.list" :key="element.id" @click="addDom(element,index,0)">
                                    <span class="iconfont-diy" :class="element.icon"></span>
                                    <p>{{ element.cname }}</p>
                                </div>
                            </draggable>
                        </div>

                    </div>
                    <div style="padding: 0 20px"><Button type="primary" style="width: 100%" @click="saveConfig">保存</Button></div>

                </div>
                <!-- 中间 -->
                <div class="content">
                    <div style="margin: 21px 24px 0;overflow: hidden;">
                        <Scroll height="808">
                            <draggable
                                    class="dragArea list-group"
                                    :list="mConfig"
                                    group="people"
                                    @change="log"
                            >
                                <div class="mConfig-item" :class="{on:activeIndex == key}" v-for="(item,key) in mConfig" :key="key" @click="bindconfig(item,key)">
                                    <component :is="item.name" ref="getComponentData" :configData="propsObj" :index="key" :num="item.num"></component>
                                    <div class="delete-box">
                                        <span @click.stop="bindDelete(item,key)">删除</span>
                                    </div>
                                    <div class="handle"></div>
                                </div>
                            </draggable>
                        </Scroll>
                    </div>

                </div>
                <!-- 右侧 -->
                <div class="right-box">
                    <div class="mConfig-item" v-for="(item,key) in rConfig" :key="key">
                        <div class="title-bar">{{item.cname}}</div>
                        <component :is="item.configName" @config="config" :activeIndex="activeIndex" :num="item.num" :index="key"></component>
                    </div>
                </div>
            </div>
        </Card>
    </div>
</template>

<script>
    import { diySave, diyGetInfo, categoryList } from '@/api/diy'
    import vuedraggable from 'vuedraggable'
    import mPage from '@/components/mobilePage/index.js'
    import mConfig from '@/components/mobileConfig/index.js'
    let idGlobal = 0;
    export default {
        name: 'index.vue',
        components: {
            draggable: vuedraggable,
            ...mPage,
            ...mConfig
        },
        data () {
            return {
                leftMenu: [], // 左侧菜单
                lConfig: [], // 左侧组件
                mConfig: [], // 中间组件渲染
                rConfig: [], // 右侧组件配置
                activeConfigName: '',
                propsObj: {}, // 组件传递的数据,
                activeIndex: -99, // 选中的下标
                number: 0,
                pageId: '',
                pageName: '',
                pageType: '',
                category: []
            };
        },
        created () {
            this.categoryList()
            console.log(this.$route)
            this.pageId = this.$route.query.id
            this.pageName = this.$route.query.name
            this.pageType = this.$route.query.type
            this.lConfig = this.objToArr(mPage)
        },
        mounted () {
            this.$nextTick(() => {
                this.arraySort();
                if (this.pageId) {
                    this.getDefaultConfig()
                }
            })
        },
        methods: {
            // 对象转数组
            objToArr (data) {
                let obj = Object.keys(data);
                let m = obj.map(key => data[key]);
                return m
            },
            log: function (evt) {
                // 中间拖拽排序
                if (evt.moved) {
                    console.log(evt.moved)
                    this.$store.commit('admin/mobildConfig/defaultArraySort', evt.moved)
                }
                // 从左向右拖拽排序
                if (evt.added) {
                    let data = evt.added.element
                    let obj = {}
                    let timestamp = new Date().getTime()*1000;
                    data.num = timestamp
                    this.activeConfigName = data.name
                    let tempItem = JSON.parse(JSON.stringify(data))
                    this.rConfig = [];
                    this.rConfig.push(tempItem)
                    // 保存组件名称
                    this.$store.commit('admin/mobildConfig/SETCONFIGNAME', data.name)
                    this.$store.commit('admin/mobildConfig/defaultArraySort', evt.added)
                }
            },
            cloneDog (data) {
                // this.mConfig.push(tempItem)
                return {
                    ...data
                }
            },
            // 组件添加
            addDom (item, index, type) {
                idGlobal += 1
                let obj = {}
                let timestamp = new Date().getTime() * 1000;
                item.num = `${timestamp}`
                this.activeConfigName = item.name
                let tempItem = JSON.parse(JSON.stringify(item))
                this.rConfig = [];
                this.mConfig.push(tempItem)
                this.rConfig.push(tempItem)
                this.activeIndex = this.mConfig.length - 1
                // 保存组件名称
                this.$store.commit('admin/mobildConfig/SETCONFIGNAME', item.name)
                // 保存默认组件配置
                this.$store.commit('admin/mobildConfig/ADDARRAY', { num: item.num, val: item.data().defaultConfig })
            },
            // 点击显示相应的配置
            bindconfig (item, index) {
                this.rConfig = [];
                let tempItem = JSON.parse(JSON.stringify(item))
                this.rConfig.push(tempItem)
                this.activeIndex = index
                this.$store.commit('admin/mobildConfig/SETCONFIGNAME', item.name)

            },
            // 组件删除
            bindDelete (item, key) {
                this.mConfig.splice(key, 1)
                this.rConfig.splice(0, 1)
                // 删除第几个配置
                this.$store.commit('admin/mobildConfig/DELETEARRAY', item)
            },
            // 组件返回
            config (data) {
                let propsObj = this.propsObj
                propsObj.data = data
                propsObj.name = this.activeConfigName
            },
            addSort (arr, index1, index2) {
                arr[index1] = arr.splice(index2, 1, arr[index1])[0];
                return arr;
            },
            // 数组排序
            arraySort () {
                let tempArr = []
                let basis = {
                    title: '基础组件',
                    list: []
                }
                let marketing = {
                    title: '营销组件',
                    list: []
                }
                let tool = {
                    title: '工具组件',
                    list: []
                }
                this.lConfig.map((el, index) => {
                    if (el.type == 0) {
                        basis.list.push(el)
                    }
                    if (el.type == 1) {
                        marketing.list.push(el)
                    }
                    if (el.type == 2) {
                        tool.list.push(el)
                    }
                })
                tempArr.push(basis, marketing, tool)
                this.leftMenu = tempArr
            },
            // 保存配置
            saveConfig () {
                let val = this.$store.state.admin.mobildConfig.defaultArray
                diySave(this.pageId, {
                    name: this.pageName,
                    type: this.pageType,
                    value: val
                }).then(res => {
                    this.$Message.success('保存成功');
                })
            },
            // 获取默认配置
            getDefaultConfig () {
                diyGetInfo(this.pageId).then(({ data }) => {
                    let obj = {}
                    let tempARR = []
                    let newArr = this.objToArr(data.info.value)
                    newArr.map((el, index) => {
                        this.lConfig.map((item, j) => {
                            if (el.name == item.defaultName) {
                                item.num = el.timestamp
                                let tempItem = JSON.parse(JSON.stringify(item))
                                tempARR.push(tempItem)
                                obj[el.timestamp] = el
                                this.mConfig.push(tempItem)
                                // 保存默认组件配置
                                this.$store.commit('admin/mobildConfig/ADDARRAY', { num: el.timestamp, val: el })
                            }
                        })
                    })
                })
            },
            categoryList () {
                categoryList(res => {
                    this.category = res.data
                })
            }
        },
        beforeDestroy () {
            console.log(this.$store.state.admin.mobildConfig,'beforeDestroy')
            this.$store.commit('admin/mobildConfig/SETEMPTY')

        },
        destroyed () {
            console.log(this.$store.state.admin.mobildConfig,'destroyed')
            this.$store.commit('admin/mobildConfig/SETEMPTY')
        }
    }
</script>

<style scoped lang="stylus">
    .ivu-mt
        display flex
        justify-content space-between
    .iconfont-diy
        font-size 24px

    .diy-wrapper
        max-width 90%
        min-width 1100px
        margin 0 auto
        display flex
        justify-content space-between
        .left
            width 275px
            border 1px solid #DDDDDD
            border-radius 4px
            .title-bar
                height 38px
                color #333
                line-height 38px
                padding-left 24px
                border-bottom 1px solid #eee
                border-radius 4px
            .wrapper
                padding 15px
                .tips
                    padding-bottom 15px
                    font-size 12px
                    color #999999
            .dragArea.list-group
                display flex
                flex-wrap wrap
                .list-group-item
                    display flex
                    flex-direction column
                    align-items center
                    justify-content center
                    width:74px;
                    height:66px;
                    margin-right 10px
                    margin-bottom 10px
                    background #f7f7f7
                    font-size 12px
                    color #666
                    cursor: pointer;
                    &:nth-child(3n)
                        margin-right 0

        .content
            position relative
            width 427px
            height 849px
            margin 0 53px
            .dragArea.list-group
                width 100%
                height 740px
                .mConfig-item
                    position relative
                    .delete-box
                        display none
                        position absolute
                        left 0
                        top 0
                        width 100%
                        height 100%
                        border 2px dashed #00a0e9;
                        padding 10px 0
                        span
                            position absolute
                            right 0
                            bottom 0
                            width: 32px;
                            height: 16px;
                            line-height: 16px;
                            display: inline-block;
                            text-align: center;
                            font-size: 10px;
                            color: #fff;
                            background: rgba(0, 0, 0, 0.4);
                            margin-left: 2px;
                            cursor: pointer;
                            z-index: 11;
                    &:hover,&.on
                        cursor: move;
                        .delete-box
                            display block

        .right-box
            width 400px
            border:1px solid #ddd;
            border-radius 4px
            .title-bar
                width 100%
                height 38px
                line-height 38px
                padding-left 24px
                color #333
                border-radius 4px
                border-bottom 1px solid #eee
        ::-webkit-scrollbar {
            width: 6px;
            background-color: transparent;
        }
        ::-webkit-scrollbar-track {
            border-radius:10px;
        }

        ::-webkit-scrollbar-thumb {
            background-color: #bfc1c4;
        }
/deep/.ivu-scroll-loader
    display none
/deep/ .ivu-card-body
    width 100%;
</style>
