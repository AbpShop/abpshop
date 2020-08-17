<template>
    <div class="mobile-page" :style="{marginTop:mTOP+'px'}">
        <div class="list-wrapper">
            <div class="item" :class="{on:listStyle == 0}" v-for="(item,index) in list" :key="index" :style="{background:bgColor,marginBottom:itemEdge+'px'}">
                <div class="empty-box on"><span class="iconfont-diy icontupian"></span></div>
                <div class="info">
                    <div class="title">{{item.title}}</div>
                    <div class="time">{{item.time}}</div>
                </div>
            </div>

        </div>
    </div>
</template>

<script>
    import { categoryList } from '@/api/diy'
    import { mapState } from 'vuex';
    export default {
        name: 'home_new_list',
        cname: '新闻列表',
        icon: 'iconwenzhangliebiao',
        configName: 'c_new_list',
        type: 0, // 0 基础组件 1 营销组件 2工具组件
        defaultName: 'articleList', // 外面匹配名称
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
                list: [
                    {
                        title: '文章标题文章标题文章标题文章 标题文章标题',
                        time: '2020-12-20-10 19:35'
                    },
                    {
                        title: '文章标题文章标题文章标题文章 标题文章标题',
                        time: '2020-12-20-10 19:35'
                    },
                    {
                        title: '文章标题文章标题文章标题文章 标题文章标题',
                        time: '2020-12-20-10 19:35'
                    }
                ],
                // 默认初始化数据禁止修改
                defaultConfig: {
                    name: 'articleList',
                    timestamp: this.num,
                    numConfig: {
                        val: 3
                    },
                    selectConfig: {
                        title: '文章分类',
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
                    listStyle: {
                        cname: 'listStyle',
                        title: '文本位置',
                        type: 0,
                        list: [
                            {
                                val: '居左',
                                icon: 'icondoc_left'
                            },
                            {
                                val: '居右',
                                icon: 'icondoc_right'
                            }
                        ]
                    },
                    bgColor: {
                        title: '背景颜色',
                        default: [
                            {
                                item: '#F5F5F5'
                            }
                        ],
                        color: [
                            {
                                item: '#F5F5F5'
                            }
                        ]
                    },
                    itemConfig: {
                        title: '文章间距',
                        val: 0,
                        min: 0
                    },
                    mbConfig: {
                        title: '页面间距',
                        val: 0,
                        min: 0
                    }
                },
                mTOP: 0,
                bgColor: [],
                itemEdge: 0,
                listStyle: 0,
                itemStyle:0
            }
        },
        created () {

        },
        mounted () {
            this.$nextTick(() => {
                this.pageData = this.$store.state.admin.mobildConfig.defaultArray[this.num]
                this.setConfig(this.pageData)
                //this.categoryList()
            })
        },
        methods: {
            categoryList () {
                categoryList().then(res => {
                    this.pageData.selectConfig.list = res.data
                    this.pageData.selectConfig.list.map(item => {
                        item.id.toString();
                        // return item;
                    });
                    this.$store.commit('admin/mobildConfig/UPDATEARR', { num: this.num, val: this.pageData })
                })
            },
            setConfig (data) {
                this.bgColor = data.bgColor.color[0].item
                this.mTOP = data.mbConfig.val;
                this.itemEdge = data.itemConfig.val;
                this.listStyle = data.listStyle.type
                // this.imgStyle = data.imgConfig.type
                // this.imgSrc = data.swiperConfig.list[0].img
            }
        }
    }
</script>

<style scoped lang="stylus">
.list-wrapper
    .item
        display flex
        align-items center
        justify-content space-between
        background #FCFCFC
        padding 10px
        &.on
            flex-flow row-reverse
        .img-box
            width:125px;
            height:78px;
            background #E8E8E8
        .info
            display flex
            flex-direction column
            justify-content space-between
            width 210px
            height:78px;
            .title
                color #282828
                font-size 15px
            .time
                color #999999
                font-size 12px
        .empty-box
            width:125px;
            height:78px;
</style>
