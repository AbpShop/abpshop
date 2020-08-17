<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" hidden-breadcrumb>
                <div slot="title" class="ivu-mt ivu-mb">
                    <Button icon="ios-arrow-back" size="small"  @click="back" class="mr20" v-if="$route.meta.auth[0] === 'system-config-system_config-list'">返回</Button>
                    <span v-text="$route.meta.title" class="mr20"></span>
                </div>
            </PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt">
            <Form ref="formValidate" :model="formValidate"  :label-width="labelWidth" :label-position="labelPosition" @submit.native.prevent>
                <Row type="flex" :gutter="24">
                    <Col v-bind="grid">
                        <FormItem label="是否显示：">
                            <Select v-model="formValidate.status" placeholder="请选择" clearable  @on-change="userSearchs">
                                <Option value="1">显示</Option>
                                <Option value="0">不显示</Option>
                            </Select>
                        </FormItem>
                    </Col>
                </Row>
                <Row type="flex">
                    <Col v-bind="grid">
                        <Button type="primary" icon="md-add" @click="groupAdd('添加数据')" class="mr20">添加数据</Button>
                    </Col>
                </Row>
            </Form>
            <Table :columns="columns1" :data="tabList" ref="table" class="mt25"
                   :loading="loading" highlight-row
                   no-userFrom-text="暂无数据"
                   no-filtered-userFrom-text="暂无筛选结果" v-if="type != 'a'? true : false">
                <template slot-scope="{ row, index }" :slot='[type]'>
                    <viewer>
                        <div class="tabBox_img">
                            <img v-lazy='row[type]'>
                        </div>
                    </viewer>
                </template>
                <template slot-scope="{ row, index }" slot="status">
                    <i-switch v-model="row.status" :value="row.status" :true-value="1" :false-value="0" @on-change="onchangeIsShow(row)" size="large">
                        <span slot="open">显示</span>
                        <span slot="close">隐藏</span>
                    </i-switch>
                </template>
                <template slot-scope="{ row, index }" slot="action">
                    <a @click="edit(row, '编辑')">编辑</a>
                    <Divider type="vertical"/>
                    <a @click="del(row,'删除这条信息',index)">删除</a>
                </template>
            </Table>
            <div class="acea-row row-right page">
                <Page :total="total" show-elevator show-total @on-change="pageChange"
                      :page-size="formValidate.limit"/>
            </div>
        </Card>
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    import editFrom from '@/components/from/from';
    import { groupDataListApi, groupDataAddApi, groupDataEditApi, groupDataHeaderApi, groupDataSetApi } from '@/api/system';
    export default {
        name: 'list',
        components: { editFrom },
        data () {
            return {
                grid: {
                    xl: 7,
                    lg: 7,
                    md: 12,
                    sm: 24,
                    xs: 24
                },
                formValidate: {
                    status: '',
                    page: 1,
                    limit: 20,
                    gid: 0
                },
                total: 0,
                tabList: [],
                columns1: [],
                FromData: null,
                loading: false,
                titleType: 'group',
                type: 'a'
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
        watch: {
            $route (to, from) {
                this.getList();
                this.getListHeader()
            }
        },
        mounted () {
            this.getListHeader();
            this.getList();
        },
        methods: {
            // 返回
            back () {
                this.$router.push({ path: '/admin/system/config/system_group/index' });
            },
            // 列表
            getList () {
                this.type = 'a';
                this.loading = true;
                this.formValidate.gid = this.$route.params.id;
                this.formValidate.status = this.formValidate.status || '';
                groupDataListApi(this.formValidate).then(async res => {
                    let data = res.data
                    this.type = res.data.type;
                    this.tabList = data.list;
                    this.total = data.count;
                    this.loading = false;
                }).catch(res => {
                    this.loading = false;
                    this.$Message.error(res.msg);
                })
            },
            // 表格头部
            getListHeader () {
                this.loading = true;
                let data = {
                    gid: this.$route.params.id
                }
                groupDataHeaderApi(data).then(async res => {
                    let data = res.data
                    this.columns1 = data.header;
                    this.loading = false;
                }).catch(res => {
                    this.loading = false;
                    this.$Message.error(res.msg);
                })
            },
            pageChange (index) {
                this.formValidate.page = index;
                this.getList();
            },
            // 表格搜索
            userSearchs () {
                this.formValidate.page = 1;
                this.getList();
            },
            // 添加表单
            groupAdd () {
                this.$modalForm(groupDataAddApi({ gid: this.$route.params.id })).then(() => this.getList());
                // groupDataAddApi(data).then(async res => {
                //     this.FromData = res.data;
                //     this.$refs.edits.modals = true;
                // }).catch(res => {
                //     this.$Message.error(res.msg);
                // })
            },
            // 修改是否显示
            onchangeIsShow (row) {
                let data = {
                    id: row.id,
                    status: row.status
                }
                groupDataSetApi(data).then(async res => {
                    this.$Message.success(res.msg);
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            // 编辑
            edit (row) {
                let data = {
                    gid: this.$route.params.id
                };
                this.$modalForm(groupDataEditApi(row.id, data)).then(() => this.getList());
                // groupDataEditApi(row.id, data).then(async res => {
                //     this.FromData = res.data;
                //     this.$refs.edits.modals = true;
                // }).catch(res => {
                //     this.$Message.error(res.msg);
                // })
            },
            // 删除
            del (row, tit, num) {
                let delfromData = {
                    title: tit,
                    num: num,
                    url: `setting/group_data/${row.id}`,
                    method: 'DELETE',
                    ids: ''
                }
                this.$modalSure(delfromData).then((res) => {
                    this.$Message.success(res.msg);
                    this.tabList.splice(num, 1);
                }).catch(res => {
                    this.$Message.error(res.msg);
                });
            }
        }
    }
</script>

<style scoped lang="stylus">
    .tabBox_img
        width 36px
        height 36px
        border-radius:4px
        cursor pointer
        img
            width 100%
            height 100%
</style>
