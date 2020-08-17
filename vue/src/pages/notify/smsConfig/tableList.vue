<template>
    <div>
        <Card :bordered="false" dis-hover>
            <span>短信状态：</span>
            <RadioGroup type="button" v-model="tableFrom.type" @on-change="selectChange(tableFrom.type)">
                <Radio label="">全部</Radio>
                <Radio label="100">成功</Radio>
                <Radio label="130">失败</Radio>
                <Radio label="131">空号</Radio>
                <Radio label="132">停机</Radio>
                <Radio label="133">关机</Radio>
                <Radio label="134">无状态</Radio>
            </RadioGroup>
            <Table :columns="columns1" :data="tableList"
                   :loading="loading" highlight-row
                   no-userFrom-text="暂无数据"
                   no-filtered-userFrom-text="暂无筛选结果" class="mt25"></Table>
            <div class="acea-row row-right page">
                <Page :total="total" show-elevator show-total @on-change="pageChange"
                      :page-size="tableFrom.limit"/>
            </div>
        </Card>
    </div>
</template>

<script>
    import { smsRecordApi } from '@/api/setting';
    export default {
        name: 'tableList',
        data () {
            return {
                columns1: [
                    {
                        title: 'ID',
                        key: 'id',
                        width: 80
                    },
                    {
                        title: '手机号',
                        key: 'phone',
                        minWidth: 120
                    },
                    {
                        title: '模板内容',
                        key: 'content',
                        width: 500
                    },
                    {
                        title: '模板ID',
                        key: 'template',
                        minWidth: 100
                    },
                    {
                        title: '发送时间',
                        key: 'add_time',
                        minWidth: 150
                    },
                    {
                        title: '状态码',
                        key: 'resultcode',
                        minWidth: 100
                    }
                ],
                tableFrom: {
                    page: 1,
                    limit: 20,
                    type: ''
                },
                total: 0,
                loading: false,
                tableList: []
            }
        },
        created () {
            this.getList();
        },
        methods: {
            // 选择
            selectChange (tab) {
                this.tableFrom.type = tab;
                this.getList();
            },
            // 列表
            getList () {
                this.loading = true;
                smsRecordApi(this.tableFrom).then(async res => {
                    let data = res.data
                    this.tableList = data.data;
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
                this.getList();
            }
        }
    }
</script>
