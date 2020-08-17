<template>
    <div  v-if="orderDatalist">
        <Modal v-model="modals"  scrollable :title="`${orderDatalist.userInfo.nickname}订单信息`" width="700" class="order_box">
            <Card :bordered="false" dis-hover class="i-table-no-border">
                <DescriptionList title="收货信息" :col="2">
                    <Description term="用户昵称：">{{orderDatalist.userInfo.nickname}}</Description>
                    <Description term="收货人：">{{ orderDatalist.orderInfo.real_name }}</Description>
                    <Description term="联系电话：">{{ orderDatalist.orderInfo.user_phone }}</Description>
                    <Description term="收货地址：">{{ orderDatalist.orderInfo.user_address }}</Description>
                </DescriptionList>
                <Divider style="margin: 20px 0 !important;"/>
                <DescriptionList title="订单信息" :col="2">
                    <Description term="订单ID：">{{orderDatalist.orderInfo.order_id}}</Description>
                    <Description term="订单状态：" class="fontColor1">{{orderDatalist.orderInfo._status._title}}</Description>
                    <Description term="商品总数：">{{orderDatalist.orderInfo.total_num}}</Description>
                    <Description term="商品总价：">{{orderDatalist.orderInfo.total_price}}</Description>
                    <Description term="交付邮费：">{{orderDatalist.orderInfo.pay_postage}}</Description>
                    <Description term="优惠券金额：">{{orderDatalist.orderInfo.coupon_price}}</Description>
                    <Description term="实际支付：">{{orderDatalist.orderInfo.pay_price}}</Description>
                    <Description term="退款金额：" class="fontColor3" v-if="parseFloat(orderDatalist.orderInfo.refund_price)">{{parseFloat(orderDatalist.orderInfo.refund_price)}}</Description>
                    <Description term="使用积分：" class="fontColor3" v-if="parseFloat(orderDatalist.orderInfo.use_integral)">{{parseFloat(orderDatalist.orderInfo.use_integral)}}</Description>
                    <Description term="退回积分：" class="fontColor3" v-if="parseFloat(orderDatalist.orderInfo.back_integral)">{{parseFloat(orderDatalist.orderInfo.back_integral)}}</Description>
                    <Description term="创建时间：">{{orderDatalist.orderInfo._add_time}}</Description>
                    <Description term="支付方式：">{{orderDatalist.orderInfo._status._payType}}</Description>
                    <Description term="推广人：">{{orderDatalist.userInfo.spread_name+'/'+orderDatalist.userInfo.spread_uid}}</Description>
                    <Description term="门店名称：" v-if="orderDatalist.orderInfo.shipping_type === 2 && orderDatalist.orderInfo.refund_status === 0 && orderDatalist.orderInfo.paid === 1">{{orderDatalist.orderInfo._store_name}}</Description>
                    <Description term="核销码：" v-if="orderDatalist.orderInfo.shipping_type === 2 && orderDatalist.orderInfo.refund_status === 0 && orderDatalist.orderInfo.paid === 1">{{orderDatalist.orderInfo.verify_code}}</Description>
                    <Description term="商家备注：">{{orderDatalist.orderInfo.remark}}</Description>
                </DescriptionList>
                <Divider style="margin: 20px 0 !important;"/>
                <DescriptionList title="物流信息" :col="2" v-if="orderDatalist.orderInfo.delivery_type==='express'">
                    <Description term="快递公司：">{{orderDatalist.orderInfo.delivery_name}}</Description>
                    <Description term="快递单号：">{{orderDatalist.orderInfo.delivery_id}} <Button type="info" size="small" @click="openLogistics">物流查询</Button></Description>
                </DescriptionList>
                <DescriptionList title="配送信息" :col="2" v-if="orderDatalist.orderInfo.delivery_type==='send'">
                    <Description term="送货人姓名：">{{orderDatalist.orderInfo.delivery_name}}</Description>
                    <Description term="送货人电话：">{{orderDatalist.orderInfo.delivery_id}}</Description>
                </DescriptionList>
                <Divider style="margin: 20px 0 !important;" v-if="orderDatalist.userInfo.mark"/>
                <DescriptionList title="备注信息" :col="2" v-if="orderDatalist.userInfo.mark">
                    <Description class="fontColor2">{{orderDatalist.userInfo.mark}}</Description>
                </DescriptionList>
            </Card>
        </Modal>
        <Modal v-model="modal2" scrollable title="物流查询"  width="350" class="order_box2">
            <div class="logistics acea-row row-top">
                <div class="logistics_img"><img src="../../../../assets/images/expressi.jpg"></div>
                <div class="logistics_cent">
                    <span>物流公司：{{orderDatalist.orderInfo.delivery_name}}</span>
                    <span>物流单号：{{orderDatalist.orderInfo.delivery_id}}</span>
                </div>
            </div>
            <div class="acea-row row-column-around trees-coadd">
                <div class="scollhide">
                    <Timeline>
                        <TimelineItem v-for="(item,i) in result" :key="i">
                            <p class="time" v-text="item.time"></p>
                            <p class="content" v-text="item.status"></p>
                        </TimelineItem>
                    </Timeline>
                </div>
            </div>
        </Modal>
    </div>
</template>

<script>
    import { getExpress } from '@/api/order';
    export default {
        name: 'orderDetails',
        data () {
            return {
                modal2: false,
                modals: false,
                grid: {
                    xl: 8,
                    lg: 8,
                    md: 12,
                    sm: 24,
                    xs: 24
                },
                result: []
            }
        },
        props: {
            orderDatalist: Object,
            orderId: Number
        },
        methods: {
            openLogistics () {
                this.getOrderData()
                this.modal2 = true;
            },
            // 获取订单物流信息
            getOrderData () {
                getExpress(this.orderId).then(async res => {
                    this.result = res.data.result;
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            }
        },
        computed: {
        }
    }
</script>

<style scoped lang="stylus">
    .logistics
        align-items: center
        padding: 10px 0px
        .logistics_img
            width 45px
            height 45px
            margin-right: 12px
            img
             width 100%
             height 100%
        .logistics_cent
            span
              display block
              font-size 12px
    .trees-coadd
        width: 100%;
        height: 400px;
        border-radius: 4px;
        overflow: hidden;
        .scollhide
            width: 100%;
            height: 100%;
            overflow: auto;
            margin-left: 18px;
            padding: 10px 0 10px 0;
            box-sizing: border-box;
            .content
              font-size 12px
            .time
              font-size 12px
              color: #2d8cf0
.order_box2
   position absolute
   z-index 999999999
.order_box >>> .ivu-modal-header
   padding 30x 16px !important
.order_box >>> .ivu-card
    font-size 12px !important
.fontColor1 >>> .ivu-description-term
    color red !important
.fontColor1 >>> .ivu-description-detail
    color red !important
    padding-bottom 14px !important
.fontColor2 >>> .ivu-description-detail
    color #733AF9 !important
.order_box >>> .ivu-description-term
    padding-bottom 10px !important
.order_box >>> .ivu-description-detail
    padding-bottom 10px !important
.order_box >>> .ivu-modal-body
    padding: 0 16px !important
.fontColor3 >>> .ivu-description-term
    color #f1a417 !important
.fontColor3 >>> .ivu-description-detail
    color #f1a417 !important
</style>
