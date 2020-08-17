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
    import rightBtn from '@/components/rightBtn/index.vue';
    import { mapState, mapMutations, mapActions } from 'vuex'
    export default {
        name: 'c_home_pink',
        cname: '拼团',
        componentsName: 'home_pink',
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
        data () {
            return {
                configObj: {},
                rCom: [
                    {
                        components: toolCom.c_input_number,
                        configNme: 'numConfig'
                    },
                    {
                        components: toolCom.c_upload_img,
                        configNme: 'imgConfig'
                    },
                    {
                        components: toolCom.c_bg_color,
                        configNme: 'txtColor'
                    },
                    {
                        components: toolCom.c_bg_color,
                        configNme: 'themeColor'
                    },
                    {
                        components: toolCom.c_slider,
                        configNme: 'lrConfig'
                    },
                    {
                        components: toolCom.c_slider,
                        configNme: 'mbConfig'
                    }
                    // toolCom.c_input_number,
                    // toolCom.c_bg_color,
                    // toolCom.c_slider
                ]
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

            },
        }
    }
</script>

<style scoped>

</style>
