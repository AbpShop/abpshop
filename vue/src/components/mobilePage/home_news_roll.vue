<template>
    <div class="news-box" :style="{marginTop:slider+'px'}">
        <div class="item" v-for="(item,index) in list" :key="index">
            <div class="img-box"><img :src="imgUrl" alt=""></div>
            <div class="right-box" :style="{textAlign:textStyle}">{{item.chiild[0].val}}</div>
        </div>
    </div>
</template>

<script>
    import { mapState } from 'vuex';

    export default {
        name: 'home_news_roll',
        cname: '新闻播报',
        configName: 'c_news_roll',
        type: 0, // 0 基础组件 1 营销组件 2工具组件
        defaultName: 'news', // 外面匹配名称
        icon: 'iconxinwenbobao',
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
                    name: 'news',
                    timestamp: this.num,
                    txtStyle: {
                        title: '文本位置',
                        name: 'txtStyle',
                        type: 0,
                        list: [
                            {
                                val: '居左',
                                icon: 'icondoc_left',
                                style: 'left'
                            },
                            {
                                val: '居中',
                                icon: 'icondoc_center',
                                style: 'center'
                            },
                            {
                                val: '居右',
                                icon: 'icondoc_right',
                                style: 'right'
                            }
                        ]
                    },
                    listConfig: {
                        title: '最多可添加10个版块；鼠标拖拽左侧圆点可调整版块顺序',
                        max: 10,
                        list: [
                            {
                                chiild: [
                                    {
                                        title: '标题',
                                        val: '标题',
                                        max: 20,
                                        pla: '选填，不超过四个字'
                                    },
                                    {
                                        title: '链接',
                                        val: '链接',
                                        max: 99,
                                        pla: '选填，不超过四个字'
                                    }
                                ]
                            }
                        ]
                    },
                    // 页面间距
                    mbConfig: {
                        title: '页面间距',
                        val: 0,
                        min: 0
                    },
                    logoConfig: {
                        title: '最多可添加1张图片，建议宽度130 * 36px',
                        url: require('@/assets/images/news.png')
                    }
                },
                tabVal: '',
                bgColor: [],
                rollStyle: '',
                txtPosition: '',
                slider: '',
                pageData: {},
                list: [],
                imgUrl: '',
                textStyle: '',
                slider: 0
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
                this.list = data.listConfig.list
                this.imgUrl = data.logoConfig.url
                this.textStyle = data.txtStyle.list[data.txtStyle.type].style
                this.slider = data.mbConfig.val;
            }
        }
    }
</script>

<style scoped lang="stylus">
.news-box
   .item
        display flex
        align-items center
        height 30px
        .img-box
            width 65px
            height 18px
        .right-box
            flex 1
            padding 0 20px 0 10px
            overflow: hidden;
            text-overflow:ellipsis;
            white-space: nowrap;
            background-image url("~@/assets/images/right.png");
            background-size 20px 20px
            background-position right center
            background-repeat no-repeat
</style>
