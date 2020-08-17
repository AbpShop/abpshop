<template>
    <div class="mobile-page" :style="{marginTop:slider+'px'}">
        <div class="home_menu" :class="{on:!boxStyle}">
            <div class="menu-item" v-for="(item,index) in vuexMenu" :key="index">
                <div class="img-box">
                    <img :src="item.img" alt="" v-if="item.img">
                    <div class="empty-box on" v-else> <span class="iconfont-diy icontupian"></span> </div>
                </div>

                <p :style="{color:txtColor}">{{item.info[0].value}}</p>
            </div>
        </div>
    </div>
</template>

<script>
    import { mapState } from 'vuex'
    export default {
        name: 'home_menu',
        cname: '导航组',
        icon: 'icondaohangzu',
        configName: 'c_home_menu',
        type:0,// 0 基础组件 1 营销组件 2工具组件
        defaultName:'menus', // 外面匹配名称
        props: {
            index: {
                type: null
            },
            num: {
                type: null
            }
        },
        computed: {
            ...mapState('admin/mobildConfig', ['defaultArray'])
        },
        watch: {
            pageData: {
                handler (nVal, oVal) {
                    this.setConfig(nVal)
                },
                deep: true
            },
            num: {
                handler (nVal, oVal) {
                    let data = this.$store.state.admin.mobildConfig.defaultArray[nVal]
                    this.setConfig(data)
                },
                deep: true
            },
            'defaultArray': {
                handler (nVal, oVal) {
                    let data = this.$store.state.admin.mobildConfig.defaultArray[this.num]
                    this.setConfig(data);
                },
                deep: true
            }
        },
        data () {
            return {
                // 默认初始化数据禁止修改
                defaultConfig: {
                    name:'menus',
                    timestamp: this.num,
                    menuConfig: {
                        title: '最多可添加1张图片，建议宽度90 * 90px',
                        maxList: 10,
                        list: [
                            {
                                img: '',
                                info: [
                                    {
                                        title: '标题',
                                        value: '今日推荐',
                                        tips: '选填，不超过4个字',
                                        max: 4
                                    },
                                    {
                                        title: '链接',
                                        value: '',
                                        max: 100
                                    }
                                ]
                            },
                            {
                                img: '',
                                info: [
                                    {
                                        title: '标题',
                                        value: '热门榜单',
                                        tips: '选填，不超过4个字',
                                        max: 4
                                    },
                                    {
                                        title: '链接',
                                        value: '',
                                        max: 100
                                    }
                                ]

                            },
                            {
                                img: '',
                                info: [
                                    {
                                        title: '标题',
                                        value: '首发新品',
                                        tips: '选填，不超过4个字',
                                        max: 4
                                    },
                                    {
                                        title: '链接',
                                        value: '',
                                        max: 100
                                    }
                                ]

                            },
                            {
                                img: '',
                                info: [
                                    {
                                        title: '标题',
                                        value: '促销单品',
                                        tips: '选填，不超过4个字',
                                        max: 4
                                    },
                                    {
                                        title: '链接',
                                        value: '',
                                        max: 100
                                    }
                                ]
                            }
                        ]
                    },
                    rowStyle: {
                        title: '每行数量',
                        name: 'rowStyle',
                        type: 0,
                        list: [
                            {
                                val: '4个',
                                icon:'iconFour'
                            },
                            {
                                val: '5个',
                                icon:'iconfive'
                            }
                        ]
                    },
                    titleColor: {
                        title: '标题颜色',
                        name: 'themeColor',
                        default: [{
                            item: '#333333'
                        }],
                        color: [
                            {
                                item: '#333333'
                            }

                        ]
                    },
                    // 页面间距
                    mbConfig: {
                        title: '页面间距',
                        val: 0,
                        min: 0
                    }
                },
                vuexMenu: '',
                txtColor: '',
                boxStyle: '',
                slider: '',
                pageData: {}
            }
        },
        mounted () {
            this.$nextTick(() => {
                this.pageData = this.$store.state.admin.mobildConfig.defaultArray[this.num]
                this.setConfig(this.pageData)
            })
        },
        methods: {
            setConfig (data) {
                this.vuexMenu = data.menuConfig.list
                this.txtColor = data.titleColor.color[0].item;
                this.boxStyle = data.rowStyle.type;
                this.slider = data.mbConfig.val;
                // this.vuexMenu = data.menu;
                // this.txtColor = data.colorList[0].color[0].item;
                // this.boxStyle = data.styleList[0].type;
                // this.slider = data.sliderList[0].val;
            }
        }
    }
</script>

<style scoped lang="stylus">
.home_menu
    padding 0 12px 12px
    display flex
    flex-wrap wrap
    .menu-item
        margin-top 12px
        margin-right 26px
        font-size 11px
        color #282828
        text-align center
        .img-box
            width 48px
            height 48px
        .box,img
            width 100%
            height 100%
        .box
            background #D8D8D8
        p
            margin-top 5px
        &:nth-child(5n)
            margin-right 0
    &.on
        .menu-item
            margin-right 51px
            &:nth-child(5n)
                margin-right 51px
            &:nth-child(4n)
                margin-right 0
    .icontupian
        font-size 16px
</style>
