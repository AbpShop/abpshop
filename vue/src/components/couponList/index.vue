<template>
    <div>
        <Modal v-model="isTemplate"
               title="优惠券列表"
               width="60%"
               @on-ok="ok"
               @on-cancel="cancel">
            <Table :columns="columns" :data="couponList" ref="table" class="mt25"
                   :loading="loading" highlight-row @on-selection-change="onSelectTab"
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
            </Table>
            <div class="acea-row row-right page">
                <Page :total="total" show-elevator show-total @on-change="receivePageChange"
                      :page-size="tableFrom.limit"/>
            </div>
        </Modal>
    </div>
</template>

<script>
    import { releasedListApi } from '@/api/marketing';
    import { formatDate } from '@/utils/validate';
    export default {
        name: 'index',
        filters: {
            formatDate (time) {
                if (time !== 0) {
                    let date = new Date(time * 1000);
                    return formatDate(date, 'yyyy-MM-dd hh:mm');
                }
            }
        },
        props: {
            couponids: {
                type: Array
            }
        },
        data () {
            return {
                isTemplate: false,
                loading: false,
                tableFrom: {
                    page: 1,
                    limit: 10
                },
                total: 0,
                ids: [],
                texts: [],
                columns: [
                    {
                        type: 'selection',
                        width: 60,
                        align: 'center'
                    },
                    {
                        title: 'ID',
                        key: 'id',
                        width: 60
                    },
                    {
                        title: '优惠券名称',
                        key: 'title',
                        minWidth: 150
                    },
                    {
                        title: '优惠券类型',
                        key: 'type',
                        minWidth: 80
                    },
                    {
                        title: '面值',
                        key: 'coupon_price',
                        minWidth: 100
                    },
                    {
                        title: '最低消费额',
                        key: 'use_min_price',
                        minWidth: 100
                    },
                    {
                        title: '发布数量',
                        slot: 'count',
                        minWidth: 120
                    },
                    {
                        title: '有效期限',
                        slot: 'start_time',
                        minWidth: 120
                    },
                    {
                        title: '状态',
                        slot: 'status',
                        minWidth: 80
                    }
                ],
                couponList: []
            }
        },
        mounted () {
        },
        methods: {
            cancel () {
                this.isTemplate = false
            },
            tableList () {
                this.loading = true;
                releasedListApi(this.tableFrom).then(res => {
                    let data = res.data;
                    this.couponList = data.list;
                    this.couponList.map((item) => {
                        if (this.couponids.indexOf(item.id) !== -1) {
                            item._checked = true;
                        }
                        return item;
                    });
                    this.total = data.count;
                    this.loading = false;
                })
            },
            // 全选
            onSelectTab (selection) {
                let data = [];
                let texts = [];
                selection.map((item) => {
                    data.push(item.id);
                    texts.push(item.title);
                });
                this.ids = data;
                this.texts = texts;
            },
            ok () {
                this.$emit('nameId', this.ids, this.texts);
            },
            receivePageChange (index) {
                this.tableFrom.page = index;
                this.tableList();
            }
        }
    }
</script>

<style scoped>

</style>
