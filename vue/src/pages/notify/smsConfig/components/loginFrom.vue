<template>
    <Row type="flex">
        <Col span="24">
            <div class="index_from page-account-container">
                <div class="page-account-top ">
                    <span class="page-account-top-tit">短信账户登录</span>
                </div>
                <Form ref="formInline" :model="formInline" :rules="ruleInline" @submit.native.prevent @keyup.enter="handleSubmit('formInline')">
                    <FormItem prop="sms_account">
                        <Input type="text" v-model="formInline.sms_account" prefix="ios-contact-outline"
                               placeholder="请输入用户名"/>
                    </FormItem>
                    <FormItem prop="sms_token">
                        <Input type="password" v-model="formInline.sms_token" prefix="ios-lock-outline"
                               placeholder="请输入密码"/>
                    </FormItem>
                    <FormItem>
                        <Button type="primary" long size="large" @click="handleSubmit('formInline')" class="btn">{{$t('page.login.submit') }}</Button>
                    </FormItem>
                </Form>
                <div class="page-account-other">
                    <!--<span @click="changePassword">忘记密码  |</span>-->
                    <span  @click="changeReg">   注册账户</span>
                </div>
            </div>
        </Col>
    </Row>
</template>

<script>
    import { configApi } from '@/api/setting';
    export default {
        name: 'login',
        data () {
            return {
                formInline: {
                    sms_account: '',
                    sms_token: ''
                },
                ruleInline: {
                    sms_account: [
                        { required: true, message: '请输入用户名', trigger: 'blur' }
                    ],
                    sms_token: [
                        { required: true, message: '请输入密码', trigger: 'blur' }
                    ]
                }
            }
        },
        created () {
            var _this = this;
            document.onkeydown = function (e) {
                let key = window.event.keyCode;
                if (key === 13) {
                    _this.handleSubmit('formInline');
                }
            };
        },
        methods: {
            handleSubmit (name) {
                this.$refs[name].validate((valid) => {
                    if (valid) {
                        configApi(this.formInline).then(async res => {
                            this.$Message.success('登录成功!');
                            this.$emit('on-Login');
                        }).catch(res => {
                            this.$Message.error(res.msg);
                        })
                    } else {
                        return false;
                    }
                })
            },
            // 休息密码
            changePassword () {
                this.$emit('on-change')
            },
            changeReg () {
                this.$emit('on-changes')
            }
        }
    }
</script>

<style scoped lang="stylus">
.page-account-top-tit
    font-size 21px
    color #1890FF
.page-account-other
    text-align center
    color #1890FF
    font-size 12px
    span
      cursor pointer
</style>
