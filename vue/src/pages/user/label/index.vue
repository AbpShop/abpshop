<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" :title="$route.meta.title" hidden-breadcrumb></PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt">
            <Row type="flex">
                <Col v-bind="grid">
                    <Button type="primary"  icon="md-add" @click="add">添加标签</Button>
                </Col>
            </Row>
            <Table :columns="columns1" :data="labelLists" ref="table" class="mt25"
                   :loading="loading" highlight-row
                   no-userFrom-text="暂无数据"
                   no-filtered-userFrom-text="暂无筛选结果">
                <template slot-scope="{ row, index }" slot="icons">
                    <viewer>
                        <div class="tabBox_img">
                            <img v-lazy="row.icon">
                        </div>
                    </viewer>
                </template>
                <template slot-scope="{ row, index }" slot="action">
                    <a @click="edit(row.id)">修改</a>
                    <Divider type="vertical" />
                    <a @click="del(row,'删除分组',index)">删除</a>
                </template>
            </Table>
            <div class="acea-row row-right page">
                <Page :total="total" show-elevator show-total @on-change="pageChange"
                      :page-size="labelFrom.limit"/>
            </div>
        </Card>
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    import { userLabelApi, userLabelAddApi } from '@/api/user';
    export default {
        name: 'user_label',
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
                        title: 'ID',
                        key: 'id',
                        minWidth: 120
                    },
                    {
                        title: '标签名称',
                        key: 'label_name',
                        minWidth: 600
                    },
                    {
                        title: '操作',
                        slot: 'action',
                        fixed: 'right',
                        minWidth: 120
                    }
                ],
                labelFrom: {
                    page: 1,
                    limit: 15
                },
                labelLists: [],
                total: 0
            }
        },
        computed: {
            ...mapState('admin/layout', [
                'isMobile'
            ]),
            labelWidth () {
                return this.isMobile ? undefined : 75;
            },
            labelPosition () {
                return this.isMobile ? 'top' : 'right';
            }
        },
        created () {
            this.getList();
        },
        methods: {
            // 添加
            add () {
                this.$modalForm(userLabelAddApi(0)).then(() => this.getList());
            },
            // 分组列表
            getList () {
                this.loading = true;
                userLabelApi(this.labelFrom).then(async res => {
                    let data = res.data;
                    this.labelLists = data.list;
                    this.total = data.count;
                    this.loading = false;
                }).catch(res => {
                    this.loading = false;
                    this.$Message.error(res.msg);
                })
            },
            pageChange (index) {
                this.labelFrom.page = index;
                this.getList();
            },
            // 修改
            edit (id) {
                this.$modalForm(userLabelAddApi(id)).then(() => this.getList());
            },
            // 删除
            del (row, tit, num) {
                let delfromData = {
                    title: tit,
                    num: num,
                    url: `user/user_label/del/${row.id}`,
                    method: 'DELETE',
                    ids: ''
                };
                this.$modalSure(delfromData).then((res) => {
                    this.$Message.success(res.msg);
                    this.labelLists.splice(num, 1);

                    this.getList();
                }).catch(res => {
                    this.$Message.error(res.msg);
                });
            }
        }
    }
</script>

<style scoped>

</style>
