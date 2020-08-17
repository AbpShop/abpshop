<template>
    <div class="mobile-page">
        <div class="hot_banner" :style="{
            marginLeft:edge+'px',
            marginRight:edge+'px',
            marginTop:mTOP+'px'
        }">
            <img :src="imgUrl" alt="" v-if="imgUrl" :class="{on:!borderRadius}" >
            <div class="empty-box" :class="{on:!borderRadius}" v-else><span class="iconfont-diy icontupian"></span></div>
            <div v-if="tabVal !=0">
                <div class="dot" v-if="docStyle == 0">
                    <div class="dot-item active"></div>
                    <div class="dot-item"></div>
                    <div class="dot-item"></div>
                </div>
                <div class="dot line-dot" v-if="docStyle==1">
                    <div class="line_dot-item active"></div>
                    <div class="line_dot-item"></div>
                    <div class="line_dot-item"></div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    export default {
        name: 'hot_banner',
        cname: '广告轮播图',
        configName: 'c_hot_banner',
        icon: 'icontupianguanggao',
        type: 0, // 0 基础组件 1 营销组件 2工具组件
        defaultName: 'swipers', // 外面匹配名称
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
                    console.log(nVal, this.index, 'pageData监听')
                    this.setConfig(nVal)
                },
                deep: true
            },
            num: {
                handler (nVal, oVal) {
                    console.log(this.defaultArray);
                    let data = this.$store.state.admin.mobildConfig.defaultArray[nVal]
                    this.setConfig(data)
                    // this.$store.state.admin.mobildConfig.defaultArray.forEach((el, i) => {
                    //     if (el.timestamp == nVal) {
                    //         this.setConfig(el)
                    //         console.log(i, 'index监听')
                    //     }
                    // })
                },
                deep: true
            },
            'defaultArray': {
                handler (nVal, oVal) {
                    console.log(nVal, 'mo阿三');
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
                    name: 'swipers',
                    timestamp: this.num,
                    tabVal: 0,
                    // 模板选择
                    tabConfig: {
                        tabVal: 0,
                        type: 1,
                        tabList: [
                            {
                                name: '样式1',
                                icon: 'iconbanner_1'
                            },
                            {
                                name: '样式2',
                                icon: 'iconbanner_2'
                            },
                            {
                                name: '样式3',
                                icon: 'iconbanner_3'
                            }
                        ]
                    },
                    // 图片列表
                    swiperConfig: {
                        title: '最多可添加10张图片，建议宽度750px；鼠标拖拽左侧圆点可调整图片 顺序',
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
                            }
                        ]
                    },
                    // 左右间距
                    lrConfig: {
                        title: '左右边距',
                        val: 10,
                        min: 0
                    },
                    // 页面间距
                    mbConfig: {
                        title: '页面间距',
                        val: 0,
                        min: 0
                    },
                    // 轮播图点样式
                    docConfig: {
                        cname: 'swiper',
                        title: '轮播切换',
                        type: 0,
                        list: [
                            {
                                val: '圆点',
                                icon: 'iconDot'
                            },
                            {
                                val: '直线',
                                icon: 'iconSquarepoint'
                            }
                        ]

                    },
                    // 图片样式
                    imgConfig: {
                        cname: 'docStyle',
                        title: '图片倒角',
                        type: 0,
                        list: [
                            {
                                val: '圆角',
                                icon: 'iconPic_fillet'
                            },
                            {
                                val: '直角',
                                icon: 'iconPic_square'
                            }
                        ]
                    },
                    itemEdge: {
                        title: '图片边距',
                        val: 0,
                        min: 0
                    }
                },
                pageData: {},
                tabVal: 0,
                mTOP: 0,
                edge: '',
                imgUrl: '',
                docStyle: 0,
                borderRadius: 0
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
                this.tabVal = data.tabConfig.tabVal
                this.edge = data.lrConfig.val
                this.mTOP = data.mbConfig.val;
                this.imgUrl = data.swiperConfig.list[0].img
                this.docStyle = data.docConfig.type
                this.borderRadius = data.imgConfig.type
                // this.listRight = data.sliderList[0].val;
                // this.bgColor = data.colorList[0].color[0].item;
                // this.themeColor = data.colorList[1].color[0].item;
            }
        }
    }
</script>

<style scoped lang="stylus">
.hot_banner
    position relative
    width auto
    .empty-box
        width 100%
        height 175px
        background #ddd
    img
        width 100%
        height 175px
        &.on
            border-radius 6px
    .dot
        position absolute
        left 0
        bottom 20px
        width 100%
        display flex
        align-items center
        justify-content center
        .dot-item
            width:5px;
            height:5px;
            background:#fff;
            border-radius:50%;
            margin 0 3px
            &.active
                background #AAAAAA
        &.line-dot
            bottom 20px
            .line_dot-item
                width:8px;
                height:2px;
                background #fff
                margin 0 3px
                &.active
                    background #AAAAAA
</style>
