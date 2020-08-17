<template>
    <div class="mobile-page paddingBox">
        <div class="home_pink" :style="{marginTop:mTop+'px'}">
            <div class="title-wrapper">
                <div class="left">
<!--                    -->
                    <img class="icon" :src="imgUrl" alt="">
                    <span>拼团活动</span>
                    <div class="avatar-wrapper">
                        <img src="@/assets/images/ren1.png" alt="">
                        <img src="@/assets/images/ren2.png" alt="">
                    </div>
                    <p class="num">1234人拼团成功</p>
                </div>
                <div class="right">更多</div>
            </div>
            <div class="list-wrapper">
                <div class="item" v-for="(item,index) in list" :key="index" :style="{marginRight:listRight+'px'}">
                    <div class="img-box">
                        <img v-if="item.img" :src="item.img" alt="">
                        <div v-else class="empty-box"><span class="iconfont-diy icontupian"></span></div>
                        <div class="num">{{item.num}}参团</div>
                    </div>
                    <div class="info">
                        <div class="title line1">{{item.name}}</div>
                        <div class="price">
                            <span class="label" :style="{background:txtBg,color:txtColor}">拼团价</span>
                            <p class="num" :style="{color:txtColor}">
                                <span>￥</span>
                                {{item.price}}
                            </p>
                        </div>
                    </div>
                    <div class="btn" :style="{background:txtColor}">参与拼团</div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import { mapState } from 'vuex'
    export default {
        name: 'home_pink',
        cname: '拼团',
        icon: 'iconpintuan',
        configName: 'c_home_pink',
        type:1,// 0 基础组件 1 营销组件 2工具组件
        defaultName:'combination', // 外面匹配名称
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
                    name: 'combination',
                    timestamp: this.num,
                    numConfig: {
                        val: 3
                    },
                    txtColor: {
                        title: '文字背景色',
                        name: 'themeColor',
                        default: [{
                            item: 'rgba(255,68,68,0.1)'
                        }],
                        color: [
                            {
                                item: 'rgba(255,68,68,0.1)'
                            }

                        ]
                    },
                    themeColor: {
                        title: '主题风格',
                        name: 'themeColor',
                        default: [{
                            item: '#E93323'
                        }],
                        color: [
                            {
                                item: '#E93323'
                            }

                        ]
                    },
                    // 页面间距
                    mbConfig: {
                        title: '页面间距',
                        val: 0,
                        min: 0
                    },
                    // 左右间距
                    lrConfig: {
                        title: '左右边距',
                        val: 10,
                        min: 10
                    },
                    imgConfig: {
                        title: '最多可添加1张图片，建议宽度18 * 18px',
                        url: 'static/images/group02.gif'
                    }
                },
                list: [
                    {
                        img: '',
                        name: '小米家用电饭煲',
                        price: '234',
                        num: '1234'
                    },
                    {
                        img: '',
                        name: '小米家用电饭煲',
                        price: '234',
                        num: '1234'
                    },
                    {
                        img: '',
                        name: '小米家用电饭煲',
                        price: '234',
                        num: '1234'
                    }
                ],
                txtColor: '',
                listRight: '',
                mTop: '',
                txtBg: '',
                pageData: {},
                imgUrl: ''
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
                this.txtColor = data.themeColor.color[0].item;
                this.listRight = data.lrConfig.val;
                this.mTop = data.mbConfig.val;
                this.txtBg = data.txtColor.color[0].item;
                this.imgUrl = data.imgConfig.url
            }
        }
    }
</script>

<style scoped lang="stylus">
.home_pink
    padding 10px 12px
    background #fff
    .title-wrapper
        display flex
        align-items center
        justify-content space-between
        .left
            display flex
            align-items center
            span
                margin-left 5px
                font-size 16px
            .icon
                width 18px
                height 18px
                border-radius 50%
            .avatar-wrapper
                display flex
                align-items center
                margin-left 14px
                img
                    width 15px
                    height 15px
                    margin-left -5px
                    border 1px solid #fff
                    border-radius 50%
            .num
                margin-left 3px
                color #999
                font-size 13px
    .list-wrapper
        display flex
        margin-top 10px
        overflow hidden
        .item
            flex-shrink 0
            width 110px
            background #fff
            .img-box
                position relative
                width 100%
                height 110px
                img,.box
                    width 100%
                    height 100%
                    border-radius:8px 8px 0px 0px;
                .box
                    background #D8D8D8
                .num
                    position absolute
                    left 6px
                    top 6px
                    width:70px;
                    height:16px;
                    line-height 16px
                    text-align center
                    background:rgba(0,0,0,0.1);
                    box-shadow:1px 1px 4px 0px rgba(0,0,0,0.06);
                    border-radius:8px;
                    color #fff
                    font-size 12px
            .info
                padding 5px 7px
                .title
                    font-size 12px
                    color #282828
                .price
                    display flex
                    align-items center
                    .label
                        display inline-block
                        height 20px
                        line-height 20px
                        padding 0 3px
                        margin-right 3px
                        font-size:9px;
                        font-weight:400;
                        text-shadow:1px 1px 4px rgba(0,0,0,0.06);
                        color #FF4444
                    .num
                        color #FF4444
                        font-size 16px
                        font-weight bold
                        span
                            font-size 12px
            .btn
                width:110px;
                height:24px;
                box-shadow:1px 1px 4px 0px rgba(0,0,0,0.06);
                border-radius:0px 0px 8px 8px;
                text-align center
                line-height 24px
                color #fff

</style>
