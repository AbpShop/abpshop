<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="交易数据-商品统计" hidden-breadcrumb></PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt">
            <search-from :typeName="typeName" @getTypeNum="getTypeNum" @getSeachTime="getSeachTime"></search-from>
        </Card>
        <cards-data :cardLists="cardLists" v-if="cardLists.length>=0"></cards-data>
        <Card :bordered="false" dis-hover class="dashboard-console-visit">
            <div slot="title">
                <Row type="flex" justify="center" align="middle">
                    <Col span="8">
                        <Avatar icon="ios-podium" size="small" v-color="'#1890ff'" v-bg-color="'#e6f7ff'" />
                        <span class="ivu-pl-8">图表展示</span>
                    </Col>
                    <Col span="16" class="ivu-text-right">
                        <DatePicker v-model="visitDate" type="daterange" placement="bottom-end" placeholder="Select date" style="width: 200px"></DatePicker>
                    </Col>
                </Row>
            </div>
            <Row :gutter="24">
                <Col :xl="24" :lg="24" :md="24" :sm="24" :xs="24">
                    <h4>访问量趋势</h4>
                    <div ref="visitChart" v-height="240"></div>
                </Col>
            </Row>
        </Card>
        <Row :gutter="24">
            <Col span="12">
                <Card :bordered="false" dis-hover class="ivu-mt">
                    <div slot="title">
                        <span class="ivu-pl-8">最近交易数据</span>
                    </div>
                    <Table height="200" :columns="columns1" :data="data2" highlight-row></Table>
                </Card>
            </Col>
            <Col span="12">
                <Card :bordered="false" dis-hover class="ivu-mt">
                    <div slot="title">
                        <span class="ivu-pl-8">交易类型</span>
                    </div>
                    <Table height="200" :columns="columns1" :data="data2" highlight-row></Table>
                </Card>
            </Col>
        </Row>

    </div>
</template>

<script>
    import searchFrom from '../../../components/searchFrom/searchFrom';
    import cardsData from '../../../components/cards/cards';
    import { getOrdes } from '@/api/order';
    import { mapState } from 'vuex';
    import echarts from 'echarts';
    function getDate (d) {
        const date = new Date(d);
        const hour = date.getHours() < 10 ? '0' + date.getHours() : date.getHours();
        const mins = date.getMinutes() < 10 ? '0' + date.getMinutes() : date.getMinutes();
        return `${hour}:${mins}`;
    }
    export default {
        name: 'order',
        data () {
            return {
                typeStatus: 0,
                typeName: [],
                visitDate: '',
                xData: [],
                y1Data: [],
                y2Data: [],
                tablists: null,
                cardLists: [
                    {
                        className: 'layui-bg-blue',
                        col: 4,
                        count: 3,
                        field: '件',
                        name: '订单数量'
                    },
                    {
                        className: 'layui-bg-blue',
                        col: 4,
                        count: 3,
                        field: '件',
                        name: '订单数量'
                    }
                ], // 请求接口数据
                columns1: [
                    {
                        title: 'Name',
                        key: 'name'
                    },
                    {
                        title: 'Age',
                        key: 'age'
                    },
                    {
                        title: 'Address',
                        key: 'address'
                    }
                ],
                data2: [
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
                    },
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
        components: {
            searchFrom,
            cardsData
        },
        computed: {
            ...mapState('admin/order', [
                'orderStatus',
                'orderTime'
            ])
        },
        mounted () {
            this.getTabs();
            this.handleGetData();
            this.handleSetVisitChart();
        },
        methods: {
            // 订单类型  @on-changeTabs="getChangeTabs"
            getTabs () {
                getOrdes({}).then(async res => {
                    if (res.status === 200) {
                        this.tablists = res.data;
                        this.typeName = [
                            {
                                'name': '全部',
                                'num': this.tablists.all,
                                'label': ''
                            },
                            {
                                'name': '未支付',
                                'num': this.tablists.unpaid,
                                'label': 0
                            },
                            {
                                'name': '未发货',
                                'num': this.tablists.unshipped,
                                'label': 1
                            },
                            {
                                'name': '待收货',
                                'num': this.tablists.untake,
                                'label': 2
                            },
                            {
                                'name': '待评价',
                                'num': this.tablists.unevaluate,
                                'label': 3
                            },
                            {
                                'name': '交易完成',
                                'num': this.tablists.complete,
                                'label': 4
                            },
                            {
                                'name': '退款中',
                                'num': this.tablists.refunding,
                                'label': -1
                            },
                            {
                                'name': '已退款',
                                'num': this.tablists.refund,
                                'label': -2
                            }
                        ]
                    } else {
                        this.$Message.error(res.msg);
                    }
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            // 点击订单类型
            onChangeType (type) {
                console.log(type)
            },
            // 点击时间
            getSeachTime (tme) {
                console.log(tme)
            },
            // 点击订单状态
            getTypeNum (status) {
                this.typeStatus = status
                console.log(this.typeStatus)
            },
            // 点击订单状态
            getData () {
                // 调图标数据函数
                console.log(this.orderTime)
                console.log(this.orderStatus)
            },
            // 图表
            handleGetData () {
                const date = (new Date()).getTime();
                this.xData = [
                    getDate(date),
                    getDate(date - 60000 * 5),
                    getDate(date - 60000 * 10),
                    getDate(date - 60000 * 15),
                    getDate(date - 60000 * 20),
                    getDate(date - 60000 * 25),
                    getDate(date - 60000 * 30),
                    getDate(date - 60000 * 35),
                    getDate(date - 60000 * 40),
                    getDate(date - 60000 * 45),
                    getDate(date - 60000 * 50)
                ].reverse();
                this.y1Data = [45, 169, 400, 285, 316, 148, 150, 234, 158, 100, 266];
                this.y2Data = [15, 39, 152, 94, 102, 86, 39, 38, 95, 30, 86];
            },
            handleSetVisitChart () {
                this.visitChart = echarts.init(this.$refs.visitChart);
                this.visitChart.setOption(
                    {
                        xAxis: {
                            type: 'category',
                            axisLine: {
                                lineStyle: {
                                    color: '#D7DDE4'
                                }
                            },
                            axisTick: {
                                alignWithLabel: true,
                                lineStyle: {
                                    color: '#D7DDE4'
                                }
                            },
                            axisLabel: {
                                textStyle: {
                                    color: '#7F8B9C'
                                }
                            },
                            splitLine: {
                                show: false,
                                lineStyle: {
                                    color: '#F5F7F9'
                                }
                            },
                            data: this.xData,
                            boundaryGap: false
                        },
                        yAxis: {
                            axisLine: {
                                show: false
                            },
                            axisTick: {
                                show: false
                            },
                            axisLabel: {
                                textStyle: {
                                    color: '#7F8B9C'
                                }
                            },
                            splitLine: {
                                show: true,
                                lineStyle: {
                                    color: '#F5F7F9'
                                }
                            },
                            type: 'value'
                        },
                        legend: {
                            data: ['浏览量（PV）', '访客数（UV）'],
                            x: 'right'
                        },
                        series: [
                            {
                                data: this.y1Data,
                                name: '浏览量（PV）',
                                type: 'line',
                                tooltip: true,
                                smooth: true,
                                symbol: 'none',
                                areaStyle: {
                                    normal: {
                                        opacity: 0.2
                                    }
                                }
                            },
                            {
                                data: this.y2Data,
                                name: '访客数（UV）',
                                type: 'line',
                                tooltip: true,
                                smooth: true,
                                symbol: 'none',
                                areaStyle: {
                                    normal: {
                                        opacity: 0.2
                                    }
                                }
                            }
                        ],
                        color: ['#1495EB', '#00CC66', '#F9D249', '#ff9900', '#9860DF'],
                        grid: {
                            left: 20,
                            right: 20,
                            bottom: 20,
                            top: 40,
                            containLabel: true
                        },
                        tooltip: {
                            trigger: 'axis'
                        }
                    }
                );
            },
            handleResize () {
                this.visitChart.resize();
            }
        },
        beforeDestroy () {
            if (this.visitChart) {
                this.visitChart.dispose();
                this.visitChart = null;
            }
        }
    }
</script>

<style scoped>

</style>
