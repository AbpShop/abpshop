<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="商业授权" hidden-breadcrumb></PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt">
            <div class="auth acea-row row-between-wrapper">
                <div class="acea-row row-middle">
                    <Icon type="ios-bulb-outline" class="iconIos blue"/>
                    <div class="text" v-if="!auth">
                        <div>未授权</div>
                    </div>
                    <div class="text" v-else>
                        <div>我的商业授权</div>
                        <div class="code">授权码：{{ authCode }}</div>
                    </div>
                </div>
                <Button type="primary" @click="toAbpShop(1)" v-if="auth">进入官网</Button>
                <Button type="primary" @click="toAbpShop(2)" v-else>申请授权</Button>
            </div>
        </Card>
    </div>
</template>

<script>
    import { auth } from '@/api/system';

    export default {
        name: 'system_auth',
        data () {
            return {
                authCode: '',
                auth: false
            };
        },
        mounted () {
            this.getAuth();
        },
        methods: {
            getAuth () {
                auth().then(res => {
                    let data = res.data || {};
                    if (data.auth_code && data.auth) {
                        this.authCode = data.auth_code;
                        this.auth = true;
                    }
                })
            },
            toAbpShop (type) {
                if (type) {
                    window.open('http://abpshop.yznt.com');
                } else {
                    window.open('http://abpshop.yznt.com/home/grant/applyauthorize.html');
                }
            }
        }
    }
</script>
<style scoped>
    .auth {
        padding: 9px 16px 9px 10px;
    }

    .auth .iconIos {
        font-size: 40px;
        margin-right: 10px;
        color: #001529;
    }

    .auth .iconIos.blue {
        color: #1890FF;
    }

    .auth .text {
        font-weight: 400;
        color: rgba(0, 0, 0, 1);
        font-size: 18px;
    }

    .auth .text .code {
        font-size: 14px;
        color: rgba(0, 0, 0, 0.5);
    }
</style>
