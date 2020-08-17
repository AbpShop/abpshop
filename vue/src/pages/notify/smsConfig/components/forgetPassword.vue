<template>
    <Row type="flex" justify="center" align="middle">
        <Col span="20" style="margin-top: 70px;" class="mb20">
            <Steps :current="current">
                <Step title="验证账号信息"></Step>
                <Step title="修改账户密码"></Step>
                <Step title="登录"></Step>
            </Steps>
        </Col>
        <Col span="24">
            <div class="index_from page-account-container">
                <Form ref="formInline" :model="formInline" :rules="ruleInline" @submit.native.prevent>
                    <FormItem>
                        <Input type="text" v-model="formInline.username" prefix="ios-contact-outline"
                               :placeholder="placeholder.username" size="large"/>
                    </FormItem>
                    <FormItem>
                        <Input type="password" v-model="formInline.password" prefix="ios-lock-outline"
                               :placeholder="placeholder.password" size="large"/>
                    </FormItem>
                    <FormItem>
                        <Button type="primary" long size="large" @click="handleSubmit('formInline',current)" class="mb20">提交
                        </Button>
                        <Button long size="large" @click="returns('formInline')" class="btn">返回
                        </Button>
                    </FormItem>
                </Form>
            </div>
        </Col>
    </Row>
</template>

<script>
    export default {
        name: 'forgetPassword',
        data () {
            return {
                current: 0,
                formInline: {
                    username: '',
                    password: ''
                },
                ruleInline: {
                    username: [
                        { required: true, message: '请输入新密码', trigger: 'blur' }
                    ],
                    password: [
                        { required: true, message: '验证新密码', trigger: 'blur' }
                    ]
                },
                placeholder: {
                    username: '请输入用户名',
                    password: '请输入手机号'
                }
            }
        },
        methods: {
            handleSubmit (name, current) {
                this.current = 1;
                this.placeholder = {
                    username: '请输入新密码',
                    password: '请验证新密码'
                }
                this.ruleInline = {
                    username: [{ required: true, message: '请输入用户名', trigger: 'blur' }],
                    password: [{ required: true, message: '请输入密码', trigger: 'blur' }]
                }
            },
            returns () {
                this.$emit('goback');
            }
        }
    }
</script>

<style scoped>

</style>
