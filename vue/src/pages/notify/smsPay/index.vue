<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="短信购买" hidden-breadcrumb>
            </PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt">
            <Row :gutter="16">
                <Col span="24" class="ivu-text-left mb20">
                    <Col :xs="12" :sm="6" :md="4" :lg="3" class="mr20">
                        <span class="ivu-text-right ivu-block">短信账户名称：</span>
                    </Col>
                    <Col :xs="11" :sm="13" :md="19" :lg="20">
                        <span>{{account}}</span>
                    </Col>
                </Col>
                <Col span="24" class="ivu-text-left mb20">
                    <Col :xs="12" :sm="6" :md="4" :lg="3" class="mr20">
                        <span class="ivu-text-right ivu-block">当前剩余条数：</span>
                    </Col>
                    <Col :xs="11" :sm="13" :md="19" :lg="20">
                        <span>{{numbers}}</span>
                    </Col>
                </Col>
                <Col span="24" class="ivu-text-left mb20">
                    <Col :xs="12" :sm="6" :md="4" :lg="3" class="mr20">
                        <span class="ivu-text-right ivu-block">选择套餐：</span>
                    </Col>
                    <Col :xs="11" :sm="13" :md="19" :lg="20">
                        <Row :gutter="20">
                            <Col v-for="(item, index) in list" :key="index" :xxl="4" :xl="8" :lg="8" :md="12" :sm="24"
                                 :xs="24">
                                <div class="list-goods-list-item mb15" :class="{active:index === current}"
                                     @click="check(item,index)">
                                    <div class="list-goods-list-item-title" :class="{active:index === current}">¥ <i>{{item.price }}</i></div>
                                    <div class="list-goods-list-item-price" :class="{active:index === current}">
                                        <span>短信条数: {{ item.num }}</span>
                                    </div>
                                </div>
                            </Col>
                        </Row>
                    </Col>
                </Col>
                <Col span="24" class="ivu-text-left mb20" v-if="checkList">
                    <Col :xs="12" :sm="6" :md="4" :lg="3" class="mr20">
                        <span class="ivu-text-right ivu-block">充值条数：</span>
                    </Col>
                    <Col :xs="11" :sm="13" :md="19" :lg="20">
                        <span>{{checkList.num}}</span>
                    </Col>
                </Col>
                <Col span="24" class="ivu-text-left mb20" v-if="checkList">
                    <Col :xs="12" :sm="6" :md="4" :lg="3" class="mr20">
                        <span class="ivu-text-right ivu-block">支付金额：</span>
                    </Col>
                    <Col :xs="11" :sm="13" :md="19" :lg="20">
                        <span class="list-goods-list-item-number">￥{{checkList.price}}</span>
                    </Col>
                </Col>
                <Col span="24" class="ivu-text-left mb20">
                    <Col :xs="12" :sm="6" :md="4" :lg="3" class="mr20">
                        <span class="ivu-text-right ivu-block">付款方式：</span>
                    </Col>
                    <Col :xs="11" :sm="13" :md="19" :lg="20">
                        <span class="list-goods-list-item-pay">微信支付<i v-if="code.invalid">{{'  （ 支付码过期时间：' + code.invalid + ' ）' }}</i></span>
                    </Col>
                </Col>
                <Col span="24">
                    <Col :xs="12" :sm="6" :md="4" :lg="3" class="mr20">&nbsp;</Col>
                    <Col :xs="11" :sm="13" :md="19" :lg="20">
                        <div class="list-goods-list-item-code mr20"><img v-lazy="code.code_url" v-if="code.code_url"></div>
                    </Col>
                </Col>
                <Spin size="large" fix v-if="spinShow"></Spin>
            </Row>
        </Card>
    </div>
</template>

<script>
    import { smsNumberApi, smsPriceApi, payCodeApi, isLoginApi } from '@/api/setting';
    export default {
        name: 'smsPay',
        data () {
            return {
                numbers: '',
                account: '',
                list: [],
                current: 0,
                checkList: {},
                spinShow: false,
                code: {}
            }
        },
        created () {
            this.onIsLogin();
        },
        methods: {
            // 查看是否登录
            onIsLogin () {
                this.spinShow = true;
                isLoginApi().then(async res => {
                    let data = res.data;
                    if (!data.status) {
                        this.$Message.warning('请先登录');
                        this.$router.push('/admin/setting/sms/sms_config/index?url=' + this.$route.path);
                    } else {
                        this.getNumber();
                        this.getPrice();
                    }
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            // 剩余条数
            getNumber () {
                smsNumberApi().then(async res => {
                    let data = res.data;
                    this.numbers = data.number;
                    this.account = data.account;
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            // 支付套餐
            getPrice () {
                this.spinShow = true;
                smsPriceApi().then(async res => {
                    setTimeout(() => {
                        this.spinShow = false;
                    }, 800);
                    let data = res.data;
                    this.list = data.data;
                    this.checkList = this.list[0];
                    this.getCode(this.checkList);
                }).catch(res => {
                    this.spinShow = false;
                    this.$Message.error(res.msg);
                })
            },
            // 选中
            check (item, index) {
                this.spinShow = true;
                this.current = index;
                setTimeout(() => {
                    this.getCode(item);
                    this.checkList = item;
                    this.spinShow = false;
                }, 800);
            },
            // 支付码
            getCode (item) {
                let data = {
                    payType: 'weixin',
                    mealId: item.id,
                    price: item.price
                };
                payCodeApi(data).then(async res => {
                    this.code = res.data;
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            }
        }
    }
</script>

<style lang="less" scoped>
    .active{
        background: #0091FF;
        box-shadow:0px 6px 20px 0px rgba(0, 145, 255, 0.3);
        color: #fff !important;
    }
    .list-goods-list-item{
        border: 1px solid #DADFE6;
        padding: 20px 10px;
        box-sizing: border-box;
        border-radius:3px;
    }
    .list-goods-list{
        &-item{
            text-align: center;
            position: relative;
            cursor: pointer;
            img{
                width: 60%;
            }
            .ivu-tag{
                position: absolute;
                top: 10px;
                right: 10px;
            }
            &-title{
                font-size: 16px;
                font-weight: bold;
                color: #0091FF;
                margin-bottom: 3px;
                i{
                    font-size: 30px;
                    font-style: normal;
                }
            }
            &-desc{
                font-size: 14px;
                color: #808695;
            }
            &-price{
                font-size: 14px;
                color: #000000;
                s{
                    color: #c5c8ce;
                }
            }
            &-number{
                font-size: 14px;
                color: #ED4014;
            }
            &-pay{
                font-size: 14px;
                color: #00C050;
                i{
                    font-size: 12px;
                    font-style: normal;
                    color: #6D7278;
                }
            }
            &-code{
                width: 130px;
                height: 130px;
                img{
                    width: 100%;
                    height: 100%;
                }
            }
        }
    }
</style>
