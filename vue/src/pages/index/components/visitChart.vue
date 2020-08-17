<template>
    <div v-resize="handleResize">
        <Row :gutter="24">
            <Col san="24" class="ivu-mb">
                <Card :bordered="false" dis-hover class="dashboard-console-visit">
                    <div slot="title">
                        <Row type="flex" justify="center" align="middle">
                            <Col span="8">
                                <Avatar icon="ios-podium" size="small" v-color="'#1890ff'" v-bg-color="'#e6f7ff'" />
                                <span class="ivu-pl-8">订单</span>
                            </Col>
                            <Col span="16" class="ivu-text-right">
                                <RadioGroup v-model="visitDate" type="button" class="ivu-mr-8" @on-change="handleChangeVisitType">
                                    <Radio label="thirtyday">30天</Radio>
                                    <Radio label="week">周</Radio>
                                    <Radio label="month">月</Radio>
                                    <Radio label="year">年</Radio>
                                </RadioGroup>
                            </Col>
                        </Row>
                    </div>
                    <h4>订单量趋势</h4>
                    <echarts-from ref="visitChart" :series="series" :infoList="infoList" v-if="infoList"></echarts-from>
                </Card>
            </Col>
        </Row>
    </div>
</template>
<script>
    import { orderApi } from '@/api/index';
    import echartsFrom from '@/components/echarts/index';
    export default {
        components: { echartsFrom },
        data () {
            return {
                infoList: null,
                visitDate: 'thirtyday',
                series: []
            }
        },
        methods: {
            // 统计
            getStatistics () {
                let data = {
                    cycle: this.visitDate
                };
                orderApi(data).then(async res => {
                    this.infoList = res.data || {};
                    this.series = this.infoList.series || [];
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            // 时间改变
            handleChangeVisitType () {
                this.getStatistics();
            },
            // 监听页面宽度变化，刷新表格
            handleResize () {
                if (this.infoList) this.$refs.visitChart.handleResize();
            }
        },
        created () {
            this.getStatistics();
        }
    }
</script>
<style lang="less" scoped>
    .dashboard-console-visit{
        ul{
            li{
                list-style-type: none;
                margin-top: 12px;
            }
        }
    }
</style>
