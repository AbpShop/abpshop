<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="积分日志" hidden-breadcrumb></PageHeader>
        </div>
        <cards-data :cardLists="cardLists" v-if="cardLists.length>=0"></cards-data>
        <Card :bordered="false" dis-hover class="ivu-mt">
            <Form ref="tableFrom" :model="tableFrom"  :label-width="labelWidth" :label-position="labelPosition" @submit.native.prevent>
                <Row :gutter="24" type="flex">
                    <Col :xl="6" :lg="10" :md="10" :sm="24" :xs="24">
                        <FormItem label="搜索：" label-for="store_name">
                            <Input search enter-button placeholder="请输入用户ID,订单ID,标题,备注" v-model="tableFrom.nickname" @on-search="userSearchs"/>
                        </FormItem>
                    </Col>
                    <Col :xl="6" :lg="10" :md="10" :sm="24" :xs="24">
                        <FormItem label="选择时间："  label-for="user_time">
                            <DatePicker :editable="false" clearable @on-change="onchangeTime" v-model="timeVal" :value="timeVal"  format="yyyy/MM/dd" type="daterange" placement="bottom-end" placeholder="选择时间" v-width="'100%'"></DatePicker>
                        </FormItem>
                    </Col>
                    <Col :xl="4" :lg="4" :md="4" :sm="24" :xs="24">
                        <Button v-auth="['export-userPoint']" class="export" icon="ios-share-outline" @click="exports">导出</Button>
                    </Col>
                </Row>
            </Form>
            <Table :columns="columns1" :data="tableList" ref="table"
                   :loading="loading" highlight-row
                   no-userFrom-text="暂无数据"
                   no-filtered-userFrom-text="暂无筛选结果">
            </Table>
            <div class="acea-row row-right page">
                <Page :total="total" :current="tableFrom.page" show-elevator show-total @on-change="pageChange"
                      :page-size="tableFrom.limit"/>
            </div>
        </Card>
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    import { integralListApi, integralStatisticsApi, userPointApi } from '@/api/marketing';
    import { formatDate } from '@/utils/validate';
    import cardsData from '@/components/cards/cards';
    export default {
        name: 'userPoint',
        components: { cardsData },
        filters: {
            formatDate (time) {
                if (time !== 0) {
                    let date = new Date(time * 1000);
                    return formatDate(date, 'yyyy-MM-dd hh:mm');
                }
            }
        },
        data () {
            return {
                cardLists: [],
                loading: false,
                delfromData: {},
                columns1: [
                    {
                        title: 'ID',
                        key: 'id',
                        width: 80
                    },
                    {
                        title: '标题',
                        key: 'title',
                        minWidth: 130
                    },
                    {
                        title: '积分余量',
                        key: 'balance',
                        minWidth: 100
                    },
                    {
                        title: '明细数字',
                        key: 'number',
                        minWidth: 100
                    },
                    {
                        title: '备注',
                        key: 'mark',
                        minWidth: 100
                    },
                    {
                        title: '用户微信昵称',
                        key: 'nickname',
                        minWidth: 150
                    },
                    {
                        title: '添加时间',
                        key: 'add_time',
                        minWidth: 100
                    }
                ],
                tableList: [],
                grid: {
                    xl: 7,
                    lg: 10,
                    md: 12,
                    sm: 24,
                    xs: 24
                },
                tableFrom: {
                    start_time: '',
                    end_time: '',
                    nickname: '',
                    page: 1,
                    limit: 15
                },
                timeVal: [],
                total: 0
            }
        },
        computed: {
            ...mapState('admin/layout', [
                'isMobile'
            ]),
            labelWidth () {
                return this.isMobile ? undefined : 80;
            },
            labelPosition () {
                return this.isMobile ? 'top' : 'left';
            }
        },
        created () {
            this.getList();
            this.getStatistics();
        },
        methods: {
            // 拼团统计
            getStatistics () {
                integralStatisticsApi().then(async res => {
                    let data = res.data
                    this.cardLists = data.res;
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            // 具体日期
            onchangeTime (e) {
                this.timeVal = e;
                this.tableFrom.start_time = e[0];
                this.tableFrom.end_time = e[1];
                this.tableFrom.page = 1;
                this.getList();
            },
            // 列表
            getList () {
                this.loading = true;
                integralListApi(this.tableFrom).then(async res => {
                    let data = res.data
                    this.tableList = data.list;
                    this.total = res.data.count;
                    this.loading = false;
                }).catch(res => {
                    this.loading = false;
                    this.$Message.error(res.msg);
                })
            },
            pageChange (index) {
                this.tableFrom.page = index;
                this.getList();
            },
            // 表格搜索
            userSearchs () {
                this.tableFrom.page = 1;
                this.getList();
            },
            // 导出
            exports () {
                let formValidate = this.tableFrom;
                let data = {
                    start_time: formValidate.start_time,
                    end_time: formValidate.end_time,
                    nickname: formValidate.nickname
                };
                userPointApi(data).then(res => {
                    location.href = res.data[0];
                }).catch(res => {
                    this.$Message.error(res.msg)
                })
            }
        }
    }
</script>

<style scoped lang="stylus">
    .tab_data >>> .ivu-form-item-content
        display flex!important
</style>
