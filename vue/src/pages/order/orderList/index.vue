<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="订单管理" hidden-breadcrumb>
                <div slot="content">
                    <Tabs v-model="currentTab" @on-click="onClickTab" v-if="tablists">
                        <TabPane :label=" '全部订单（'+tablists.all+'）'" name=" "/>
                        <TabPane :label=" '普通订单（'+tablists.general+'）'" name="1"/>
                        <TabPane :label=" '拼团订单（'+tablists.pink+'）'" name="2"/>
                        <TabPane :label=" '秒杀订单（'+tablists.seckill+'）'" name="3"/>
                        <TabPane :label=" '砍价订单（'+tablists.bargain+'）'" name="4"/>
                    </Tabs>
                </div>
            </PageHeader>
        </div>
        <productlist-details v-if="currentTab === 'article' || 'project' || 'app'" ref="productlist" ></productlist-details>
        <Spin size="large" fix v-if="spinShow"></Spin>
    </div>
</template>

<script>
    import productlistDetails from './orderlistDetails';
    import { mapMutations } from 'vuex';
    export default {
        name: 'list',
        components: {
            productlistDetails
        },
        data () {
            return {
                spinShow: false,
                currentTab: '',
                data: [],
                tablists: null
            }
        },
        mounted () {
            this.getTabs()
        },
        methods: {
            ...mapMutations('admin/order', [
                'onChangeTabs'
                // 'onChangeChart'
            ]),
            // 订单类型  @on-changeTabs="getChangeTabs"
            getTabs () {
                this.spinShow = true;
                this.$store.dispatch('admin/order/getOrderTabs', {
                    data: ''
                }).then(res => {
                    this.tablists = res.data;
                    // this.onChangeChart(this.tablists)
                    this.spinShow = false;
                }).catch(res => {
                    this.spinShow = false;
                    this.$Message.error(res.msg);
                })
                // getOrdes({}).then(async res => {
                //     this.tablists = res.data;
                //     this.onChangeChart(this.tablists)
                //     this.spinShow = false;
                // }).catch(res => {
                //     this.spinShow = false;
                //     this.$Message.error(res.msg);
                // })
            },
            onClickTab () {
                this.onChangeTabs(Number(this.currentTab))
                this.$store.dispatch('admin/order/getOrderTabs', {
                    data: '',
                    type: Number(this.currentTab)
                });
                this.$refs.productlist.getChangeTabs()
                this.$store.dispatch('admin/order/getOrderTabs', { type: this.currentTab });
            }
        }
    }
</script>
<style scoped lang="stylus">
    .product_tabs >>> .ivu-tabs-bar
      margin-bottom 0px !important
    .product_tabs >>> .ivu-page-header-content
      margin-bottom 0px !important
    .product_tabs >>> .ivu-page-header-breadcrumb
        margin-bottom 0px !important
</style>
