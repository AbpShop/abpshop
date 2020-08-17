<template>
    <div class="mobile-page" :style="{marginTop:`${mTOP}px`}">

        <div class="bg" :style="{background: `linear-gradient(90deg,${bgColor[0].item} 0%,${bgColor[1].item} 100%)`}" v-if="bgColor.length>0 && swiperStyle == 2" ></div>
        <div class="banner"
             :style="{
                paddingLeft:edge+'px',
                paddingRight:edge+'px'
             }"
        >
            <img :class="{doc:imgStyle}" :src="imgSrc" alt="" v-if="imgSrc">
            <div class="empty-box" :class="{on:imgStyle}" v-else>
                <span class="iconfont-diy icontupian"></span>
            </div>
        </div>
        <div v-if="swiperStyle !=0">
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
</template>

<script>
    import { mapState } from 'vuex';
    export default {
        name: 'banner', // 组件名称
        cname: '轮播图', // 标题名称
        icon: 'icontupianguanggao',
        defaultName:'swiperBg', // 外面匹配名称
        configName: 'c_banner', // 右侧配置名称
        type: 0, // 0 基础组件 1 营销组件 2工具组件
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
                    name: 'swiperBg',
                    timestamp: this.num,
                    // 模板选择
                    tabConfig: {
                        tabVal: 0,
                        type: 1,
                        tabList: [
                            {
                                name: '单图模板',
                                icon: 'iconbanner_1'
                            },
                            {
                                name: '多图模板1',
                                icon: 'iconbanner_2'
                            },
                            {
                                name: '多图模板2',
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
                    // 背景颜色
                    bgColor: {
                        title: '背景颜色',
                        default: [
                            {
                                item: '#F62C2C'
                            },
                            {
                                item: '#F96E29'
                            }
                        ],
                        color: [
                            {
                                item: '#F62C2C'
                            },
                            {
                                item: '#F96E29'
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
                    itemEdge: {
                        title: '图片边距',
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
                    }
                },
                pageData: {},
                bgColor: [],
                mTOP: 0,
                edge: 0,
                imgStyle: 0,
                imgSrc: '',
                docStyle: 0,
                swiperStyle:0
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
                this.swiperStyle = data.tabConfig.tabVal;
                this.bgColor = data.bgColor.color
                this.mTOP = data.mbConfig.val;
                this.edge = data.lrConfig.val;
                this.imgStyle = data.imgConfig.type
                this.imgSrc = data.swiperConfig.list.length ? data.swiperConfig.list[0].img : ''
                this.docStyle = data.docConfig.type
            }
        }
    }
</script>

<style scoped lang="stylus">
    .mobile-page
        position relative
        width: auto;
        height: 140px;
        .banner
            position absolute
            left 0
            top 0
            width 100%
            height 140px
            img
                width 100%
                height 100%
                border-radius:6px;
                &.doc
                    border-radius:0;
        .bg
            width 100%
            height: 50px;
            background:linear-gradient(90deg,#F62C2C 0%,#F96E29 100%);
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
