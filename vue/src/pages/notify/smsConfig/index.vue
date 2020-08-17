<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="短信账户" hidden-breadcrumb v-if="!isShowList"></PageHeader>
            <PageHeader hidden-breadcrumb v-if="isShowList" class="conBox">
                <div slot="content">
                    <Avatar class="dashboard-workplace-header-avatar" :src="imgUrl" />
                    <div class="dashboard-workplace-header-tip">
                        <p class="dashboard-workplace-header-tip-title">{{smsAccount}}，祝您每一天开心！</p>
                        <p class="dashboard-workplace-header-tip-desc">
                            <!--<Icon type="md-create" color="#2A7EFB"/>-->
                            <!--<a href="#">修改密码</a>-->
                            <!--<Divider type="vertical" />-->
                            <a href="#" @click="signOut">退出登录</a>
                        </p>
                    </div>
                </div>
                <div slot="extra" class="dashboard-workplace-header-extra">
                    <Row type="flex" justify="center" align="middle" :gutter="12">
                        <Col span="8">
                            <p>
                                <Avatar icon="md-apps" size="small" v-color="'#40a9ff'" v-bg-color="'#e6f7ff'" />
                                <span>剩余条数</span>
                            </p>
                            <p>
                                <Numeral :value="numbers" format="'0,'" />
                            </p>
                        </Col>
                        <Col span="8">
                            <p>
                                <Avatar icon="md-checkbox-outline" size="small" v-color="'#ffa940'" v-bg-color="'#fff7e6'" />
                                <span>已发送</span>
                            </p>
                            <p>
                                <Numeral :value="sendTotal" format="'0,'" />
                            </p>
                        </Col>
                        <Col span="8">
                            <p>
                                <Avatar icon="md-clipboard" size="small" v-color="'#73d13d'" v-bg-color="'#f6ffed'" />
                                <span>总条数</span>
                            </p>
                            <p>
                                <Numeral :value="amount" format="'0,'" />
                            </p>
                        </Col>
                    </Row>
                </div>
            </PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt">
            <login-from @on-change="onChangePasssword" v-if="isShowLogn" @on-changes="onChangeReg" @on-Login="onLogin"></login-from>
            <forget-password v-if="isShow" @goback="goback"></forget-password>
            <register-from v-if="isShowReg" @on-change="logoup"></register-from>
            <table-list v-if="isShowList"></table-list>
            <Spin size="large" fix v-if="spinShow"></Spin>
        </Card>
    </div>
</template>

<script>
    import loginFrom from './components/loginFrom';
    import forgetPassword from './components/forgetPassword';
    import registerFrom from './components/register';
    import tableList from './tableList';
    import { isLoginApi, logoutApi, smsNumberApi } from '@/api/setting';
    export default {
        name: 'smsConfig',
        components: { loginFrom, forgetPassword, registerFrom, tableList },
        data () {
            return {
                imgUrl: require('@/assets/images/ren.png'),
                spinShow: false,
                isShowLogn: false,
                isShow: false,
                isShowReg: false,
                isShowList: false,
                smsAccount: '',
                amount: 0,
                numbers: 0,
                sendTotal: 0
            }
        },
        created () {
            this.onIsLogin();
        },
        methods: {
            // 剩余条数
            getNumber () {
                smsNumberApi().then(async res => {
                    let data = res.data;
                    this.numbers = data.number;
                    this.sendTotal = data.send_total;
                    this.amount = data.number + data.send_total;
                    this.smsAccount = data.account;
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            // 查看是否登录
            onIsLogin () {
                this.spinShow = true;
                isLoginApi().then(async res => {
                    let data = res.data;
                    this.isShowLogn = !data.status;
                    this.isShowList = data.status;
                    this.spinShow = false;
                    if (data.status) {
                        this.getNumber();
                    }
                }).catch(res => {
                    this.spinShow = false;
                    this.$Message.error(res.msg);
                })
            },
            // 退出登录
            signOut () {
                logoutApi().then(async res => {
                    this.isShowLogn = true;
                    this.isShowList = false;
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            // 忘记密码
            onChangePasssword () {
                this.isShowLogn = false;
                this.isShow = true;
            },
            // 立即注册
            onChangeReg () {
                this.isShowLogn = false;
                this.isShow = false;
                this.isShowReg = true;
            },
            // 立即登录
            logoup () {
                this.isShowLogn = true;
                this.isShow = false;
                this.isShowReg = false;
            },
            // 登录跳转
            onLogin () {
                let url = this.$route.query.url;
                if (url) {
                    this.$router.replace(url);
                } else {
                    this.isShowLogn = false;
                    this.isShow = false;
                    this.isShowReg = false;
                    this.isShowList = true;
                    this.getNumber();
                }
            },
            // 返回
            goback () {
                this.isShowLogn = true;
                this.isShow = false;
            }
        }
    }
</script>

<style lang="less" scoped>
    .page-account-top-tit{
        font-size: 21px;
        color: #1890FF;
    }
    .dashboard-workplace{
        &-header{
            &-avatar{
                width: 64px;
                height: 64px;
                border-radius: 50%;
                margin-right: 16px;
            }
            &-tip{
                display: inline-block;
                vertical-align: middle;
                &-title{
                    font-size: 20px;
                    font-weight: bold;
                    margin-bottom: 12px;
                }
                &-desc{
                    color: #808695;
                }
            }
            &-extra{
                width: 100% !important;
                .ivu-col{
                    p{
                        text-align: right;
                    }
                    p:first-child{
                        span:first-child{
                            margin-right: 4px;
                        }
                        span:last-child{
                            color: #808695;
                        }
                    }
                    p:last-child{
                        font-size: 22px;
                    }
                }
            }
        }
    }
    @aaa: ~'>>>';
    .conBox{
        @{aaa} .ivu-page-header-extra{
            width: auto !important;
            min-width:300px;
        }
    }
</style>
