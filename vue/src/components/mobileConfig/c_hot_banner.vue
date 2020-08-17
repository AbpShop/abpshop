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
    import { mapState, mapMutations, mapActions } from 'vuex'
    export default {
        name: 'c_hot_banner',
        componentsName: 'hot_banner',
        components: {
            ...toolCom,
            rightBtn
        },
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
        data () {
            return {
                configObj: {},
                lockStatus: false,
                rCom: [
                    {
                        components: toolCom.c_tab,
                        configNme: 'tabConfig'
                    },
                    {
                        components: toolCom.c_menu_list,
                        configNme: 'swiperConfig'
                    },
                    {
                        components: toolCom.c_txt_tab,
                        configNme: 'docConfig'
                    },
                    {
                        components: toolCom.c_txt_tab,
                        configNme: 'imgConfig'
                    },
                    {
                        components: toolCom.c_slider,
                        configNme: 'lrConfig'
                    },
                    {
                        components: toolCom.c_slider,
                        configNme: 'mbConfig'
                    },
                    {
                        components: toolCom.c_slider,
                        configNme: 'itemEdge'
                    }
                ]
            }
        },
        watch: {
            num (nVal) {
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
            // 获取组件参数
            getConfig (data) {
                console.log(data, 'getConfig')
                if (data == 0) {
                    let tempobj = {
                        components: toolCom.c_slider,
                        configNme: 'itemEdge'
                    }
                    this.rCom.push(tempobj)
                    this.lockStatus = false
                } else {
                    if (!this.lockStatus) {
                        this.lockStatus = true
                        this.rCom.pop();
                    }
                }
            },
            handleSubmit (name) {
                let obj = {}
                obj.activeIndex = this.activeIndex
                obj.data = this.configObj
                this.add(obj);
            },
            ...mapMutations({
                add: 'admin/mobildConfig/UPDATEARR'
            })
        }
    }
</script>

<style scoped lang="stylus">
    .title-tips
        padding-bottom 10px
        font-size 14px
        color #333
        span
            margin-right 14px
            color #999
</style>
