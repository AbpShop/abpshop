<template>
    <div class="mobile-page">
        <div class="live-wrapper" :style="{marginTop:cSlider+'px'}" :class="{on:listStyle == 0}">
            <div class="live-item" v-for="(item,index) in live" :key="index">
                <span class="iconfont-diy icontupian"></span>
                <div class="label" :style="{background:item.color}">
                    <span class="iconfont-diy" :class="item.icon" style="margin-right: 5px"></span>{{item.title}}
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import { mapState, mapMutations } from 'vuex'
    export default {
        name: 'wechat_live',
        cname: '小程序直播',
        configName: 'c_wechat_live',
        type: 1, // 0 基础组件 1 营销组件 2工具组件
        defaultName: 'liveBroadcast', // 外面匹配名称
        icon: 'iconxiaochengxuzhibo',
        props: {
            index: {
                type: null,
                default: -1
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
                    name: 'liveBroadcast',
                    timestamp: this.num,
                    playBg: {
                        title: '直播中背景色',
                        name: 'playBg',
                        default: [{
                            item: '#fa3838'
                        }],
                        color: [
                            {
                                item: '#fa3838'
                            }
                        ]
                    },
                    endBg: {
                        title: '已结束背景色',
                        name: 'endBg',
                        default: [{
                            item: '#999'
                        }],
                        color: [
                            {
                                item: '#999'
                            }
                        ]
                    },
                    notBg: {
                        title: '未开始背景色',
                        name: 'notBg',
                        default: [{
                            item: '#1aa3f6'
                        }],
                        color: [
                            {
                                item: '#1aa3f6'
                            }
                        ]
                    },
                    listStyle: {
                        title: '列表样式',
                        name: 'listStyle',
                        type: 0,
                        list: [
                            {
                                val: '大图',
                                icon: 'iconPic_big'
                            },
                            {
                                val: '小图',
                                icon: 'iconPic_small'
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
                live: [
                    {
                        title: '直播中',
                        name: 'playBg',
                        type: 2,
                        color: '',
                        icon:'iconzhibozhong'
                    },
                    {
                        title: '已结束',
                        name: 'endBg',
                        type: 0,
                        color: '',
                        icon:'iconyijieshu'
                    },
                    {
                        title: '未开始',
                        name: 'notBg',
                        type: 1,
                        color: '',
                        icon:'iconweikaishi'
                    }
                ],
                cSlider: '',
                confObj: {},
                pageData: {},
                listStyle:0
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
                this.cSlider = data.mbConfig.val;
                this.listStyle = data.listStyle.type
                this.live.forEach((item, index) => {
                    item.color = data[item.name].color[0].item
                })
            }
        }
    }
</script>

<style scoped lang="stylus">
.live-wrapper
    display flex
    overflow hidden
    .live-item
        display flex
        align-items center
        justify-content center
        position relative
        flex-shrink 0
        margin-left 10px
        width 154px
        height 120px
        background #D8D8D8
        border-radius 6px
        .icontupian
            font-size 30px
            color #999
        .label
            position absolute
            left 0
            top 0
            display flex
            align-items center
            justify-content center
            width:60px;
            height:18px;
            background:rgba(250,56,56,1);
            border-radius:6px 0px 6px 0px;
            font-size 12px
            color #fff
            &.gary
                background #999999
            &.blue
                background #1AA3F6
    &.on
        flex-direction column
        .live-item
            width 100%
            height 276px
            margin-bottom 12px
            flex-shrink: 1;
            .label
                width 66px
                height 22px
            .icontupian
                font-size 60px
                color #999
    .iconfont-diy
        font-size 12px
</style>
