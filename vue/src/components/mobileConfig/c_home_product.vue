<template>
    <div class="mobile-config pro">
        <div  v-for="(item,key) in rCom" :key="key">
            <component :is="item.components.name" :configObj="configObj" ref="childData" :configNme="item.configNme" :key="key" @getConfig="getConfig" :index="activeIndex" :num="item.num"></component>
        </div>
        <rightBtn :activeIndex="activeIndex" :configObj="configObj"></rightBtn>
    </div>
</template>

<script>
    import toolCom from '@/components/mobileConfigRight/index.js'
    import { mapState, mapMutations, mapActions } from 'vuex'
    import rightBtn from '@/components/rightBtn/index.vue';
    export default {
        name: 'c_home_product',
        componentsName: 'home_product',
        cname: '促销列表',
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
                configObj: {},
                rCom: [
                    {
                        components: toolCom.c_product,
                        configNme: 'tabConfig'
                    },
                    {
                        components: toolCom.c_input_number,
                        configNme: 'numConfig'
                    },
                    {
                        components: toolCom.c_bg_color,
                        configNme: 'themeColor'
                    },
                    {
                        components: toolCom.c_slider,
                        configNme: 'mbConfig'
                    },
                    // toolCom.c_product,
                    // toolCom.c_input_number,
                    // toolCom.c_bg_color,
                    // toolCom.c_slider
                ]
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

<style scoped lang="stylus">
.pro
    padding 0 15px
    .tips
        height 50px
        line-height 50px
        color #999
        font-size 12px
        border-bottom 1px solid rgba(0,0,0,0.05);
.btn-box
    padding-bottom 20px
</style>
