<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" :title="$route.meta.title" hidden-breadcrumb></PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt">
            <div class="acea-row row-between-wrapper">
                <Row type="flex">
                    <Col v-bind="grid">
                        <div class="button acea-row row-middle">
                            <Button type="primary"  icon="md-add" @click="add">添加</Button>
                        </div>
                    </Col>
                </Row>
            </div>
            <Table :columns="columns1" :data="list" ref="table" class="mt25"
                   :loading="loading" highlight-row
                   no-userFrom-text="暂无数据"
                   no-filtered-userFrom-text="暂无筛选结果">
                <template slot-scope="{ row, index }" slot="region">
                    <div class="font-blue">{{row.type?'首页':'小程序首页'}}</div>
                </template>
                <template slot-scope="{ row, index }" slot="action">
                    <a @click="edit(row)">编辑</a>
                    <div  v-if="row.id !=1" style="display: inline-block">
                        <Divider type="vertical" />
                        <a @click="del(row,index)">删除</a>
                    </div>
                    <div style="display: inline-block" v-if="row.status != 1">
                        <Divider type="vertical" />
                        <a @click="setStatus(row,index)">设为首页</a>
                    </div>
                </template>

            </Table>
        </Card>
    </div>
</template>

<script>
    import { diyList, diyDel, setStatus } from '@/api/diy'
    import { mapState } from 'vuex';
    export default {
        name: 'devise_list',
        data () {
            return {
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
                        title: '页面ID',
                        key: 'id',
                        minWidth: 120
                    },
                    {
                        title: '页面名称',
                        key: 'name',
                        minWidth: 300
                    },
                    {
                        title: '页面类型',
                        slot: 'region',
                        minWidth: 120
                    },
                    {
                        title: '添加时间',
                        key: 'add_time',
                        minWidth: 120
                    },
                    {
                        title: '更新时间',
                        key: 'update_time',
                        minWidth: 120
                    },
                    {
                        title: '操作',
                        slot: 'action',
                        fixed: 'right',
                        minWidth: 300
                    }
                ],
                list: []
            }
        },
        created () {
            this.getList()
        },
        methods: {
            // 获取列表
            getList () {
                this.loading = true
                diyList().then(res => {
                    this.loading = false
                    this.list = res.data.list
                })
            },
            // 编辑
            edit (row) {
                // console.log(row,'row')
                this.$router.push({ path: '/admin/setting/pages/diy', query: { id: row.id, name: row.name, type: row.type } });
            },
            // 添加
            add () {
                this.$router.push({ path: '/admin/setting/pages/diy', query: { id: 0, name: '首页', type: 1 } });
            },
            // 删除
            del (row) {
                let delfromData = {
                    title: '删除',
                    num: 2000,
                    success: diyDel(row.id)
                };
                this.$modalSure(delfromData).then((res) => {
                    this.getList()
                }).catch(res => {
                    this.$Message.error(res.msg);
                });
            },
            // 使用模板
            setStatus (row) {
                setStatus(row.id).then(res => {
                    this.$Message.success(res.msg);
                    this.getList()
                })
            }
        }
    }
</script>

<style scoped>

</style>
