<template>
    <div class="service-box" :style="{marginTop:mTop+'px'}">
        <div class="img-box">
            <img :src="imgUrl" alt="" v-if="imgUrl">
            <div class="empty-box on" v-else><span class="iconfont-diy icontupian"></span></div>
        </div>
    </div>
</template>

<script>
    import { mapState } from 'vuex';

    export default {
        name: 'home_service',
        cname: '在线客服',
        configName: 'c_home_service',
        icon: 'iconkefu',
        type: 2, // 0 基础组件 1 营销组件 2工具组件
        defaultName: 'customerService', // 外面匹配名称
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
                defaultConfig: {
                    name: 'customerService',
                    timestamp: this.num,
                    logoConfig: {
                        title: '最多可添加1张图片，建议宽度152 * 60px',
                        url: ''
                    },
                    // 页面间距
                    topConfig: {
                        title: '顶部间距',
                        val: 0,
                        min: 0
                    }
                },
                imgUrl: '',
                pageData: {},
                mTop: 0
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
                this.mTop = data.topConfig.val
                this.imgUrl = data.logoConfig.url
            }
        }
    }
</script>

<style scoped lang="stylus">
    .service-box
        width 100%
        display flex
        justify-content flex-end
        .img-box
            width 43px
            height 43px
            img
                width 100%
                height 100%
                border-radius 50%
            .empty-box

                border-radius 50%
                .iconfont-diy
                    font-size 20px

</style>
