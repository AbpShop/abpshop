<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="文章分类" hidden-breadcrumb></PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt">
            <Form ref="roleData" :model="roleData"  :label-width="labelWidth" :label-position="labelPosition" @submit.native.prevent>
                <Row type="flex" :gutter="24">
                    <Col v-bind="grid">
                        <FormItem label="状态：" prop="status1" label-for="status1">
                            <Select v-model="roleData.status1" placeholder="请选择" element-id="status1">
                                <Option value="">状态</Option>
                                <Option :value="1">显示</Option>
                                <Option :value="0">不显示</Option>
                            </Select>
                        </FormItem>
                    </Col>
                    <Col v-bind="grid">
                        <FormItem label="用户查询：" prop="status2" label-for="status2">
                            <Input search enter-button placeholder="Enter something..." />
                        </FormItem>
                    </Col>
                </Row>
                <Row type="flex">
                    <Col v-bind="grid">
                        <Button type="primary" icon="md-add">添加文章分类</Button>
                    </Col>
                </Row>
            </Form>
            <Table :columns="columns1" :data="data1" class="mt25" highlight-row></Table>
            <div class="acea-row row-right page">
                <!--                <Page :total="orderList.length" show-elevator show-total   @on-change="getList"-->
                <!--                      :page-size="page.pageSize"  />-->
            </div>
        </Card>
    </div>
</template>
<script>
    import { mapState } from 'vuex';
    export default {
        name: 'index',
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
                roleData: {
                    status1: ''
                },
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
                        title: '文章名称',
                        key: 'address'
                    },
                    {
                        title: '关联商品',
                        key: 'age'
                    },
                    {
                        title: '排序',
                        key: 'address'
                    },
                    {
                        title: '浏览量',
                        key: 'address'
                    },
                    {
                        title: '时间',
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
                ]
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
