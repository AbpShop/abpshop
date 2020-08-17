<template>
    <div class="mobile-config pro">
        <div  v-for="(item,key) in rCom" :key="key">
            <component :is="item.components.name" :configObj="configObj" ref="childData" :configNme="item.configNme" :key="key" @getConfig="getConfig" :index="activeIndex" :num="item.num"></component>
        </div>
        <rightBtn :activeIndex="activeIndex" :configObj="configObj"></rightBtn>
    </div>
</template>

<script>
    import { getCategory,getProduct } from '@/api/diy'
    import toolCom from '@/components/mobileConfigRight/index.js'
    import { mapState, mapMutations, mapActions } from 'vuex'
    import rightBtn from '@/components/rightBtn/index.vue';
    export default {
        name: 'c_home_goods_list',
        componentsName: 'home_goods_list',
        cname: '商品列表',
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
                        components: toolCom.c_tab,
                        configNme: 'tabConfig'
                    }
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
            },
            'configObj.tabConfig.tabVal': {
                handler (nVal, oVal) {
                    var arr = [this.rCom[0]]
                    if (nVal == 0) {
                        let tempArr = [
                            {
                                components: toolCom.c_select,
                                configNme: 'selectConfig'
                            },
                            {
                                components: toolCom.c_txt_tab,
                                configNme: 'goodsSort'
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
                                components: toolCom.c_txt_tab,
                                configNme: 'itemStyle'
                            },
                            {
                                components: toolCom.c_slider,
                                configNme: 'mbConfig'
                            },
                        ]
                        this.rCom = arr.concat(tempArr)
                    } else {
                        let tempArr = [

                            {
                                components: toolCom.c_goods,
                                configNme: 'goodsList'
                            },
                            {
                                components: toolCom.c_bg_color,
                                configNme: 'themeColor'
                            },
                            {
                                components: toolCom.c_txt_tab,
                                configNme: 'itemStyle'
                            },
                            {
                                components: toolCom.c_slider,
                                configNme: 'mbConfig'
                            },
                        ]
                        this.rCom = arr.concat(tempArr)
                    }
                },
                deep: true
            }
        },
        mounted () {
            this.$nextTick(() => {
                let value = JSON.parse(JSON.stringify(this.$store.state.admin.mobildConfig.defaultArray[this.num]))
                this.configObj = value;
                this.getCategory()
            })
        },
        methods: {
            getConfig (data) {
                console.log(data,'getConfig')
                if(!data.name && data == 1){
                    this.configObj.goodsList.list = []
                    return
                }
                if(!data.name && data == 0 && !this.configObj.selectConfig.activeValue){
                    this.configObj.goodsList.list = []
                    return
                }
                getProduct({
                    id:this.configObj.selectConfig.activeValue,
                    page:1,
                    limit:this.configObj.numConfig.val,
                    priceOrder:this.configObj.goodsSort.type ==2?'1':'',
                    salesOrder:this.configObj.goodsSort.type ==1?'1':''
                }).then(res=>{
                    this.configObj.goodsList.list = res.data;
                })
            },
            getCategory () {
                getCategory().then(res => {
                    let data = [];
                    res.data.map(item => {
                        data.push({ title: item.title,pid:item.pid, activeValue: item.id.toString() });
                    });
                    this.configObj.selectConfig.list = data;
                })
            }
        }
    }
</script>

<style scoped lang="stylus">
    .pro
        padding 15px 15px 0
        .tips
            height 50px
            line-height 50px
            color #999
            font-size 12px
            border-bottom 1px solid rgba(0,0,0,0.05);
    .btn-box
        padding-bottom 20px
</style>
