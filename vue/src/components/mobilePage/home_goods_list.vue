<template>
    <div class="mobile-page paddingBox" :style="{marginTop:slider+'px',background:activeColor}">
        <div class="home_product">
            <!-- 单列 -->
            <template v-if="itemStyle == 0">
                <div class="list-wrapper itemA">
                    <div class="item" v-for="(item,index) in list" :index="index">
                        <div class="img-box">
                            <img v-if="item.image" :src="item.image" alt="">
                            <div v-else class="empty-box"><span class="iconfont-diy icontupian"></span></div>
                            <div class="label" v-if="item.type == 1">砍价</div>
                        </div>
                        <div class="info">
                            <div class="hd">
                                <div class="title line2">{{item.store_name}}</div>
                                <div class="old-price">¥{{item.ot_price}}</div>
                            </div>
                            <div class="price">
                                <div class="num">
                                    ￥{{item.price}}
                                </div>
                                <div class="label">券</div>
                            </div>
                        </div>
                    </div>
                </div>
            </template>
            <!-- 单列 -->
            <template v-if="itemStyle == 1">
                <div class="list-wrapper">
                    <div class="item" v-for="(item,index) in list" :index="index">
                        <div class="img-box">
                            <img v-if="item.image" :src="item.image" alt="">
                            <div v-else class="empty-box"><span class="iconfont-diy icontupian"></span></div>
                            <div class="label" v-if="item.type == 1">砍价</div>
                        </div>
                        <div class="info">
                            <div class="hd">
                                <div class="title line2">{{item.cate_name}}</div>
                                <div class="old-price">¥{{item.ot_price}}</div>
                            </div>
                            <div class="price">
                                <div class="num">
                                    ￥{{item.price}}
                                </div>
                                <div class="label">券</div>
                            </div>
                        </div>
                    </div>
                </div>
            </template>
            <!-- 三列 -->
            <template v-if="itemStyle == 2">
                <div class="list-wrapper itemB">
                    <div class="item" v-for="(item,index) in list" :index="index">
                        <div class="img-box">
                            <img v-if="item.image" :src="item.image" alt="">
                            <div v-else class="empty-box"><span class="iconfont-diy icontupian"></span></div>
                            <div class="label" v-if="item.type == 1">砍价</div>
                        </div>
                        <div class="info">
                            <div class="hd">
                                <div class="title line2">{{item.cate_name}}</div>
                                <div class="old-price">¥{{item.ot_price}}</div>
                            </div>
                            <div class="price">
                                <div class="num">
                                    ￥{{item.price}}
                                </div>
                                <div class="label">券</div>
                            </div>
                        </div>
                    </div>
                </div>
            </template>
        </div>
    </div>
</template>

<script>

    import { mapState } from 'vuex'
    export default {
        name: 'home_goods_list',
        cname: '商品列表',
        configName: 'c_home_goods_list',
        icon: 'iconcuxiaoliebiao',
        type: 0, // 0 基础组件 1 营销组件 2工具组件
        defaultName: 'goodList', // 外面匹配名称
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
                    name: 'goodList',
                    timestamp: this.num,
                    tabConfig: {
                        tabVal: 0,
                        type: 1,
                        tabList: [
                            {
                                name: '自动选择',
                                icon: 'iconzidongxuanze'
                            },
                            {
                                name: '手动选择',
                                icon: 'iconshoudongxuanze'
                            }
                        ]
                    },
                    selectConfig: {
                        title: '商品分类',
                        activeValue: '',
                        list: [
                            {
                                activeValue: '',
                                title: ''
                            },
                            {
                                activeValue: '',
                                title: ''
                            }
                        ]
                    },
                    goodsSort: {
                        title: '商品排序',
                        name: 'goodsSort',
                        type: 0,
                        list: [
                            {
                                val: '综合',
                                icon: 'iconComm_whole'
                            },
                            {
                                val: '销量',
                                icon: 'iconComm_number'
                            },
                            {
                                val: '价格',
                                icon: 'iconComm_Price'
                            }
                        ]
                    },
                    numConfig: {
                        val: 6
                    },
                    themeColor: {
                        title: '背景颜色',
                        name: 'themeColor',
                        default: [{
                            item: '#fff'
                        }],
                        color: [
                            {
                                item: '#fff'
                            }
                        ]
                    },
                    itemStyle: {
                        title: '显示类型',
                        name: 'itemSstyle',
                        type: 0,
                        list: [
                            {
                                val: '单列',
                                icon: 'icondanlie'
                            },
                            {
                                val: '两列',
                                icon: 'iconlianglie'
                            },
                            {
                                val: '三列',
                                icon: 'iconsanlie'
                            }
                        ]
                    },
                    mbConfig: {
                        title: '页面间距',
                        val: 0,
                        min: 0
                    },
                    lrConfig: {
                        title: '商品间距',
                        val: 0,
                        min: 0
                    },
                    goodsList: {
                        max: 20,
                        list: []
                    }
                },
                navlist: [],
                imgStyle: '',
                txtColor: '',
                slider: '',
                tabCur: 0,
                list: [
                    {
                        img: '',
                        name: '小米便携式蓝牙音响',
                        price: '59',
                        type: 1,
                        old: 135
                    },
                    {
                        img: '',
                        name: '小米便携式蓝牙音响',
                        price: '59',
                        type: 0,
                        old: 135
                    },
                    {
                        img: '',
                        name: '小米便携式蓝牙音响',
                        price: '59',
                        type: 1,
                        old: 135
                    },
                    {
                        img: '',
                        name: '小米便携式蓝牙音响',
                        price: '59',
                        type: 0,
                        old: 135
                    }
                ],
                activeColor: '',
                pageData: {},
                itemStyle: 0
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
                this.itemStyle = data.itemStyle.type
                this.activeColor = data.themeColor.color[0].item
                this.slider = data.mbConfig.val
                this.list = data.goodsList.list
            }
        }
    }
</script>

<style scoped lang="stylus">
    .paddingBox
        padding-bottom 0
    .home_product
        .hd_nav
            display flex
            height 65px
            padding 0 5px
            .item
                display flex
                flex-direction column
                justify-content center
                width 25%
                .title
                    font-size 16px
                    color #282828
                .label
                    width:62px;
                    height:18px;
                    line-height 18px
                    text-align center
                    background:transparent;
                    border-radius:8px;
                    color #999999
                    font-size 12px
                &.active
                    .title
                        color #FF4444
                    .label
                        color #fff
                        background:linear-gradient(270deg,rgba(255,84,0,1) 0%,rgba(255,0,0,1) 100%);
        .list-wrapper
            display flex
            flex-wrap wrap
            justify-content space-between
            .item
                width 170px
                margin-bottom 10px
                .img-box
                    position relative
                    width 100%
                    height 173px
                    img,.box
                        width 100%
                        height 100%
                        border-radius:10px 10px 0px 0px;
                     .empty-box
                         background  #E8E8E8
                         border-radius:10px 10px 0px 0px;
                    .box
                        background #D8D8D8
                    .label
                        position absolute
                        left 0
                        top 0
                        width:46px;
                        height:22px;
                        background:linear-gradient(270deg,rgba(255,84,0,1) 0%,rgba(255,0,0,1) 100%);
                        border-radius:10px 0px 10px 0px;
                        color #fff
                        font-size 13px
                        text-align center
                        line-height 22px
                .info
                    padding 7px 10px
                    background #fff
                    border-radius: 0px 0px 10px 10px;
                    .title
                        font-size 14px
                        color #282828
                    .old-price
                        color #aaa
                        font-size 13px
                        text-decoration: line-through;
                    .price
                        display flex
                        align-items center
                        .num
                            font-size 18px
                            color #E93323
                            span
                                font-size 12px
                        .label
                            width:16px;
                            height:18px;
                            margin-left 5px
                            text-align center
                            line-height 18px
                            font-size 11px
                            color #E93323
                            border 1px solid #E93323

            &.itemA
                /*background #fff*/
                .item
                    display flex
                    width 100%
                    .img-box
                        position relative
                        width 110px
                        height 110px
                        img,.box,.empty-box
                            border-radius 10px

                    .info
                        display flex
                        justify-content space-between
                        flex-direction column
                        flex 1
                        margin-left 5px
                        border-radius 0
                        padding: 5px 10px;
            &.itemB
                justify-content inherit
                .item
                    width 110px
                    margin-right 8px
                    &:nth-child(3n)
                        margin-right 0
                    .img-box
                        position relative
                        width 100%
                        height 110px
                        img,.box,.empty-box
                            border-radius:10px;
</style>
