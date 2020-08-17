<template>
    <div class="title-box"
         :style="[
            {'textAlign':txtPosition},
            {'fontStyle':txtStyle!='bold'?txtStyle:''},
            {'fontWeight':txtStyle=='bold'?txtStyle:''},
            {'fontSize':fontSize+'px'},
            {'marginTop':mTOP+'px'}
         ]"
    >
        {{titleTxt}}
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    export default {
        name: 'home_title',
        cname: '标题',
        icon: 'iconbiaoti',
        configName: 'c_home_title',
        type: 2, // 0 基础组件 1 营销组件 2工具组件
        defaultName: 'titles', // 外面匹配名称
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
                defaultConfig: {
                    name: 'titles',
                    timestamp: this.num,
                    titleConfig: {
                        title: '标题',
                        value: '标题',
                        max: 10
                    },
                    linkConfig: {
                        title: '链接',
                        value: '',
                        max: 100
                    },
                    titleColor: {
                        title: '背景颜色',
                        default: [
                            {
                                item: '#333'
                            }
                        ],
                        color: [
                            {
                                item: '#333'
                            }
                        ]
                    },
                    textPosition: {
                        title: '文本位置',
                        type: 0,
                        list: [
                            {
                                val: '居左',
                                style: 'left',
                                icon: 'icondoc_left'
                            },
                            {
                                val: '居中',
                                style: 'center',
                                icon: 'icondoc_center'
                            },
                            {
                                val: '居右',
                                style: 'right',
                                icon: 'icondoc_right'
                            }
                        ]
                    },
                    textStyle: {
                        title: '文本样式',
                        type: 0,
                        list: [
                            {
                                val: '正常',
                                style: 'normal',
                                icon: 'icondoc_general'
                            },
                            {
                                val: '斜体',
                                style: 'italic',
                                icon: 'icondoc_skew'
                            },
                            {
                                val: '加粗',
                                style: 'bold',
                                icon: 'icondoc_bold'
                            }
                        ]
                    },
                    fontSize: {
                        title: '文本大小',
                        val: 12,
                        min: 12
                    },
                    mbConfig: {
                        title: '页面间距',
                        val: 0,
                        min: 0
                    }
                },
                titleTxt: '',
                link: '',
                txtPosition: '',
                txtStyle: '',
                fontSize: 0,
                mTOP: 0,
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
                this.titleTxt = data.titleConfig.value
                this.link = data.linkConfig.value
                this.txtPosition = data.textPosition.list[data.textPosition.type].style
                this.txtStyle = data.textStyle.list[data.textStyle.type].style
                this.fontSize = data.fontSize.val
                this.mTOP = data.mbConfig.val;
                // this.imgStyle = data.imgConfig.type
                // this.imgSrc = data.swiperConfig.list[0].img
            }
        }
    }
</script>

<style scoped lang="stylus">
.title-box
    color #282828
</style>
