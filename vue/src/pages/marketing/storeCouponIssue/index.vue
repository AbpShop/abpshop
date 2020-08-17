<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="已发布管理" hidden-breadcrumb></PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt">
            <Form ref="tableFrom" :model="tableFrom"  :label-width="labelWidth" :label-position="labelPosition" @submit.native.prevent>
                <Row type="flex" :gutter="24">
                    <Col v-bind="grid">
                        <FormItem label="是否有效：">
                            <Select v-model="tableFrom.status" placeholder="请选择" clearable  @on-change="userSearchs">
                                <Option value="1">正常</Option>
                                <Option value="0">未开启</Option>
                                <Option value="-1">已失效</Option>
                            </Select>
                        </FormItem>
                    </Col>
                    <Col v-bind="grid">
                        <FormItem label="优惠券名称："  label-for="coupon_title">
                            <Input search enter-button  v-model="tableFrom.coupon_title" placeholder="请输入优惠券名称" @on-search="userSearchs"/>
                        </FormItem>
                    </Col>
                </Row>
            </Form>
            <Table :columns="columns1" :data="tableList" ref="table"
                   :loading="loading" highlight-row
                   no-userFrom-text="暂无数据"
                   no-filtered-userFrom-text="暂无筛选结果">
                <template slot-scope="{ row, index }" slot="count">
                    <span v-if="row.is_permanent">不限量</span>
                    <div v-else>
                        <span class="fa">发布：{{row.total_count}}</span>
                        <span class="sheng">剩余：{{row.remain_count}}</span>
                    </div>
                </template>
                <template slot-scope="{ row, index }" slot="start_time">
                   <div v-if="row.start_time">
                       {{row.start_time | formatDate}} - {{row.end_time | formatDate}}
                   </div>
                   <span v-else>不限时</span>
                </template>
                <template slot-scope="{ row, index }" slot="status">
                    <Tag color="blue" v-show="row.status===1">正常</Tag>
                    <Tag color="gold" v-show="row.status===0">未开启</Tag>
                    <Tag color="red" v-show="row.status=== -1">已失效</Tag>
                </template>
                <template slot-scope="{ row, index }" slot="action">
                    <a @click="receive(row)">领取记录</a>
                    <Divider type="vertical"/>
                    <a @click="edit(row)" v-if="row.status!==-1">修改状态</a>
                    <Divider type="vertical"  v-if="row.status!==-1"/>
                    <a @click="couponDel(row,'删除发布的优惠券',index)">删除</a>
                </template>
            </Table>
            <div class="acea-row row-right page">
                <Page :total="total" show-elevator show-total @on-change="pageChange"
                      :page-size="tableFrom.limit"/>
            </div>
        </Card>
        <!-- 领取记录 -->
        <Modal v-model="modals2" scrollable  footer-hide closable title="领取记录" :mask-closable="false"  width="700">
            <Table :columns="columns2" :data="receiveList" ref="table" class="mt25"
                   :loading="loading2" highlight-row
                   no-userFrom-text="暂无数据"
                   no-filtered-userFrom-text="暂无筛选结果">
                <template slot-scope="{ row, index }" slot="avatar">
                    <viewer>
                        <div class="tabBox_img">
                            <img v-lazy="row.avatar">
                        </div>
                    </viewer>
                </template>
            </Table>
            <div class="acea-row row-right page">
                <Page :total="total2" show-elevator show-total @on-change="receivePageChange"
                      :page-size="receiveFrom.limit"/>
            </div>
        </Modal>
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    import { releasedListApi, releasedissueLogApi, releaseStatusApi, delCouponReleased } from '@/api/marketing';
    import { formatDate } from '@/utils/validate';
    export default {
        name: 'storeCouponIssue',
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
                modals2: false,
                grid: {
                    xl: 7,
                    lg: 7,
                    md: 12,
                    sm: 24,
                    xs: 24
                },
                loading: false,
                columns1: [
                    {
                        title: 'ID',
                        key: 'id',
                        width: 80
                    },
                    {
                        title: '优惠券名称',
                        key: 'title',
                        minWidth: 150
                    },
                    {
                        title: '领取日期',
                        slot: 'start_time',
                        minWidth: 250
                    },
                    {
                        title: '发布数量',
                        slot: 'count',
                        minWidth: 100
                    },
                    {
                        title: '状态',
                        slot: 'status',
                        minWidth: 90
                    },
                    {
                        title: '操作',
                        slot: 'action',
                        fixed: 'right',
                        minWidth: 200
                    }
                ],
                tableFrom: {
                    status: '',
                    coupon_title: '',
                    page: 1,
                    limit: 15
                },
                tableList: [],
                total: 0,
                FromData: null,
                receiveList: [],
                loading2: false,
                columns2: [
                    {
                        title: '用户名',
                        key: 'nickname',
                        minWidth: 150
                    },
                    {
                        title: '用户头像',
                        slot: 'avatar',
                        minWidth: 100
                    },
                    {
                        title: '领取时间',
                        key: 'add_time',
                        minWidth: 140
                    }
                ],
                total2: 0,
                receiveFrom: {
                    page: 1,
                    limit: 15
                },
                rows: {}
            }
        },
        created () {
            this.getList();
        },
        computed: {
            ...mapState('admin/layout', [
                'isMobile'
            ]),
            labelWidth () {
                return this.isMobile ? undefined : 100;
            },
            labelPosition () {
                return this.isMobile ? 'top' : 'right';
            }
        },
        methods: {
            // 失效
            couponInvalid (row, tit, num) {
                this.delfromData = {
                    title: tit,
                    num: num,
                    url: `marketing/coupon/status/${row.id}`,
                    method: 'PUT',
                    ids: ''
                };
                this.$refs.modelSure.modals = true;
            },
            // 领取记录
            receive (row) {
                this.modals2 = true;
                this.rows = row;
                this.getReceivelist(row)
            },
            getReceivelist (row) {
                this.loading2 = true;
                releasedissueLogApi(row.id).then(async res => {
                    let data = res.data
                    this.receiveList = data.list;
                    this.total2 = res.data.count;
                    this.loading2 = false;
                }).catch(res => {
                    this.loading2 = false;
                    this.$Message.error(res.msg);
                })
            },
            // 领取记录改变分页
            receivePageChange (index) {
                this.receiveFrom.page = index;
                this.getReceivelist(this.rows)
            },
            // 删除
            couponDel (row, tit, num) {
                let delfromData = {
                    title: tit,
                    num: num,
                    success: delCouponReleased(row.id)
                };
                this.$modalSure(delfromData).then((res) => {
                    this.$Message.success(res.msg);
                    this.tableList.splice(num, 1)
                }).catch(res => {
                    this.$Message.error(res.msg);
                });
            },
            // 列表
            getList () {
                this.loading = true;
                this.tableFrom.status = this.tableFrom.status || '';
                releasedListApi(this.tableFrom).then(async res => {
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
            // 修改状态
            edit (row) {
                this.$modalForm(releaseStatusApi(row.id)).then(() => this.getList());
                // releaseStatusApi(row.id).then(async res => {
                //     this.FromData = res.data;
                //     this.$refs.edits.modals = true;
                // }).catch(res => {
                //     this.$Message.error(res.msg);
                // })
            },
            // 表格搜索
            userSearchs () {
                this.tableFrom.page = 1;
                this.getList();
            }
        }
    }
</script>

<style scoped lang="stylus">
    .fa
        color #0a6aa1
        display block
    .sheng
       color #ff0000
       display block
    .tabBox_img
        width 36px
        height 36px
        border-radius:4px
        cursor pointer
        img
            width 100%
            height 100%

</style>
