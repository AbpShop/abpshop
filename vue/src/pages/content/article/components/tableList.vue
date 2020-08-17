<template>
    <Card :bordered="false" dis-hover class="ivu-mt">
        <Form ref="roleData" :model="roleData"  :label-width="labelWidth" :label-position="labelPosition" @submit.native.prevent>
            <Row type="flex" :gutter="24">
                <Col v-bind="grid">
                    <FormItem label="文章搜索：" prop="status2" label-for="status2">
                        <Input search enter-button placeholder="请输入" />
                    </FormItem>
                </Col>
            </Row>
            <Row type="flex">
                <Col v-bind="grid">
                    <Button type="primary"  icon="md-add">添加文章</Button>
                </Col>
            </Row>
        </Form>
        <Table :columns="columns1" :data="data1" highlight-row class="mt25"></Table>
        <div class="acea-row row-right page">
<!--                            <Page :total="orderList.length" show-elevator show-total   @on-change="getList"-->
<!--                                  :page-size="page.pageSize"  />-->
        </div>
    </Card>
</template>

<script>
    import { mapState } from 'vuex';
    export default {
        name: 'tableList',
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
                        key: 'name',
                        width: 80
                    },
                    {
                        title: '文章图片',
                        key: 'age'
                    },
                    {
                        title: '名称',
                        key: 'address'
                    },
                    {
                        title: '排序',
                        key: 'age'
                    },
                    {
                        title: '时间',
                        key: 'address'
                    },
                    {
                        title: '状态',
                        key: 'address'
                    },
                    {
                        title: '操作',
                        key: 'address'
                    }
                ],
                data1: [
                    {
                        name: 'John Brown',
                        age: 18,
                        address: 'New York No. 1 Lake Park',
                        date: '2016-10-03'
                    },
                    {
                        name: 'Jim Green',
                        age: 24,
                        address: 'London No. 1 Lake Park',
                        date: '2016-10-01'
                    },
                    {
                        name: 'Joe Black',
                        age: 30,
                        address: 'Sydney No. 1 Lake Park',
                        date: '2016-10-02'
                    },
                    {
                        name: 'Jon Snow',
                        age: 26,
                        address: 'Ottawa No. 2 Lake Park',
                        date: '2016-10-04'
                    }
                ],
                roleData: {
                }
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
        }
    }
</script>

<style scoped>

</style>
