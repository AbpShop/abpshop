<template>
    <Row :gutter="24">
        <Col v-bind="grid" class="ivu-mb" v-for="(item, index) in infoList" :key="index">
            <Card :bordered="false" dis-hover :padding="12">
                <p slot="title">
                    <span v-text="item.title"></span>
                </p>
                <Tag slot="extra" color="green">{{item.date}}</Tag>
                <div>
                    <Numeral :value="item.yesterday"  v-font="30" />
                    <div class="ivu-pt-8" v-height="42">
                        <span v-display="'inline-block'" class="ivu-mr">
                            日同比 <Trend :flag="Number(item.today_ratio)>=0?'up':'down'">{{Number(item.today_ratio)}}%</Trend>
                        </span>
                        <span v-display="'inline-block'">
                            周同比 <Trend :flag="Number(item.week_ratio)>=0?'up':'down'">{{Number(item.week_ratio)}}%</Trend>
                        </span>
                    </div>
                    <Divider style="margin: 8px 0" />
                    <div>
                        <Row>
                            <Col span="12" v-text="item.total_name"></Col>
                            <Col span="12" class="ivu-text-right">{{item.total}}</Col>
                        </Row>
                    </div>
                </div>
            </Card>
        </Col>
<!--        <Col v-bind="grid" class="ivu-mb">-->
<!--            <Card :bordered="false" dis-hover :padding="12">-->
<!--                <p slot="title">-->
<!--                    <span>销售额</span>-->
<!--                </p>-->
<!--                <Tag slot="extra" color="blue">月</Tag>-->
<!--                <div>-->
<!--                    <Numeral value="12000" format="0,0" prefix="¥" v-font="30" />-->
<!--                    <div class="ivu-pt-8" v-height="42">-->
<!--                        <Tooltip content="60% 已达标" style="width: 100%">-->
<!--                            <Progress :percent="60" hide-info />-->
<!--                        </Tooltip>-->
<!--                    </div>-->
<!--                    <Divider style="margin: 8px 0" />-->
<!--                    <div>-->
<!--                        <Row>-->
<!--                            <Col span="12">总销售额</Col>-->
<!--                            <Col span="12" class="ivu-text-right">68 万</Col>-->
<!--                        </Row>-->
<!--                    </div>-->
<!--                </div>-->
<!--            </Card>-->
<!--        </Col>-->
<!--        <Col v-bind="grid" class="ivu-mb">-->
<!--            <Card :bordered="false" dis-hover :padding="12">-->
<!--                <p slot="title">-->
<!--                    <span>订单量</span>-->
<!--                </p>-->
<!--                <Tag slot="extra" color="red">周</Tag>-->
<!--                <div>-->
<!--                    <Numeral value="1680" format="0,0" v-font="30" />-->
<!--                    <div class="ivu-pt-8" v-height="42" ref="orderChart"></div>-->
<!--                    <Divider style="margin: 8px 0" />-->
<!--                    <div>-->
<!--                        <Row>-->
<!--                            <Col span="12">转化率</Col>-->
<!--                            <Col span="12" class="ivu-text-right">60%</Col>-->
<!--                        </Row>-->
<!--                    </div>-->
<!--                </div>-->
<!--            </Card>-->
<!--        </Col>-->
<!--        <Col v-bind="grid" class="ivu-mb">-->
<!--            <Card :bordered="false" dis-hover :padding="12">-->
<!--                <p slot="title">-->
<!--                    <span>新增用户</span>-->
<!--                </p>-->
<!--                <Tooltip slot="extra" content="指标说明" placement="top">-->
<!--                    <Icon type="ios-help-circle-outline" />-->
<!--                </Tooltip>-->
<!--                <div>-->
<!--                    <Numeral value="128" format="0,0" v-font="30">-->
<!--                        <span slot="suffix" v-font="24"> 位</span>-->
<!--                    </Numeral>-->
<!--                    <div class="ivu-pt-8" v-height="42">-->
<!--                        <AvatarList size="small" :list="avatarList" :max="7" :excess-style="excessStyle" />-->
<!--                    </div>-->
<!--                    <Divider style="margin: 8px 0" />-->
<!--                    <div>-->
<!--                        <Row>-->
<!--                            <Col span="12">总用户</Col>-->
<!--                            <Col span="12" class="ivu-text-right">10800 人</Col>-->
<!--                        </Row>-->
<!--                    </div>-->
<!--                </div>-->
<!--            </Card>-->
<!--        </Col>-->
    </Row>
</template>
<script>
    import echarts from 'echarts';
    import { headerApi } from '@/api/index';
    export default {
        data () {
            return {
                infoList: [],
                grid: {
                    xl: 6,
                    lg: 12,
                    md: 12,
                    sm: 12,
                    xs: 24
                },
                excessStyle: {
                    color: '#f56a00',
                    backgroundColor: '#fde3cf'
                },
                avatarList: []
            }
        },
        methods: {
            // 统计
            getStatistics () {
                headerApi().then(async res => {
                    let data = res.data
                    this.infoList = data.info;
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            }
        },
        mounted () {
            this.getStatistics();
        }
    }
</script>
