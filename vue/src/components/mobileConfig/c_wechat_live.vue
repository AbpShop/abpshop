<template>
    <div class="mobile-config">
        <div  v-for="(item,key) in rCom" :key="key">
            <component :is="item.components.name" :configObj="configObj" ref="childData" :configNme="item.configNme" :key="key" @getConfig="getConfig" :index="activeIndex" :num="item.num"></component>
        </div>
        <rightBtn :activeIndex="activeIndex" :configObj="configObj"></rightBtn>
    </div>
</template>

<script>
    import toolCom from '@/components/mobileConfigRight/index.js'
    import rightBtn from '@/components/rightBtn/index.vue';
    import { mapMutations } from 'vuex'
    export default {
        name: 'c_wechat_live',
        componentsName: 'wechat_live',
        cname: '小程序直播',
        props: {
            activeIndex: {
                type: null
            },
            num: {
                type: null
            },
            index: {
                type: null
            }
        },
        components: {
            ...toolCom,
            rightBtn
        },
        data () {
            return {
                // 组件参数配置
                option: {
                    submitBtn: false
                },
                configObj: {}, // 配置对象
                rCom: [
                    {
                        components: toolCom.c_bg_color,
                        configNme: 'playBg'
                    },
                    {
                        components: toolCom.c_bg_color,
                        configNme: 'endBg'
                    },
                    {
                        components: toolCom.c_bg_color,
                        configNme: 'notBg'
                    },
                    {
                        components: toolCom.c_txt_tab,
                        configNme: 'listStyle'
                    },
                    {
                        components: toolCom.c_slider,
                        configNme: 'mbConfig'
                    },
                ] // 当前页面组件
            }
        },
        watch: {
            num (nVal) {
                // debugger;
                let value = JSON.parse(JSON.stringify(this.$store.state.admin.mobildConfig.defaultArray[nVal]))
                this.configObj = value;
            },
            configObj: {
                handler (nVal, oVal) {
                    this.$store.commit('admin/mobildConfig/UPDATEARR', { num: this.num, val: nVal });
                },
                deep: true
            }
        },
        mounted () {
            this.$nextTick(() => {
                let value = JSON.parse(JSON.stringify(this.$store.state.admin.mobildConfig.defaultArray[this.num]))
                this.configObj = value;
            })
        },
        methods: {
            getConfig (data) {

            }
        }
    }
</script>

<style scoped>

</style>
