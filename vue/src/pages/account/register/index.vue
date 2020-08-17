<template>
    <div class="page-account">
        <div v-if="showI18n" class="page-account-header">
            <i-header-i18n />
        </div>
        <div class="page-account-container">
            <div class="page-account-top">
                <div class="page-account-top-logo">
                    <img src="@/assets/images/logo.png" alt="logo">
                </div>
                <div class="page-account-top-desc">iView Admin Pro 企业级中台前端/设计解决方案</div>
            </div>
            <Login ref="form" @on-submit="handleSubmit">
                <Email name="mail" />
                <Poptip trigger="focus" placement="right" width="240">
                    <Password name="password" :rules="passwordRule" placeholder="至少6位密码，区分大小写" @on-change="handleChangePassword" />
                    <div slot="content" class="page-account-register-tip">
                        <div class="page-account-register-tip-title" :class="passwordTip.class">
                            强度：{{ passwordTip.strong }}
                        </div>
                        <Progress :percent="passwordTip.percent" hide-info :stroke-width="6" :stroke-color="passwordTip.color" />
                        <div class="page-account-register-tip-desc">
                            请至少输入 6 个字符。请不要使用容易被猜到的密码。
                        </div>
                    </div>
                </Poptip>
                <Password name="passwordConfirm" :rules="passwordConfirmRule" placeholder="确认密码" />
                <Mobile name="mobile" />
                <Captcha name="captcha" :field="['mobile']" enter-to-submit @on-get-captcha="handleGetCaptcha" />
                <Submit>{{ $t('page.register.submit') }}</Submit>
            </Login>
            <div class="page-account-to-login">
                <router-link :to="{ name: 'login' }">{{ $t('page.register.other') }}</router-link>
            </div>
        </div>
        <i-copyright />
    </div>
</template>
<script>
    import iCopyright from '@/components/copyright';
    import { mapActions } from 'vuex';
    import mixins from '../mixins';

    export default {
        mixins: [ mixins ],
        components: { iCopyright },
        data () {
            // 二次校验密码
            // 因为 iView Pro 的表单控件省去了对数据的绑定，因此需要通过 ref 从 Login 组件中获取数据
            // 下面的 formValidate.password 中的 password，指的是给 <Password> 组件设置的 name="password"
            const validatePassCheck = (rule, value, callback) => {
                if (value !== this.$refs.form.formValidate.password) {
                    callback(new Error('两次输入的密码不匹配！'));
                } else {
                    callback();
                }
            };

            return {
                passwordRule: [
                    {
                        required: true, message: '密码不能为空！', trigger: 'change'
                    },
                    {
                        min: 6, message: '密码不能少于6位！', trigger: 'change'
                    }
                ],
                passwordConfirmRule: [
                    {
                        required: true, message: '确认密码不能为空！', trigger: 'change'
                    },
                    { validator: validatePassCheck, trigger: 'change' }
                ],
                // 密码长度，在密码强度提示时作为判断依据
                passwordLen: 0
            }
        },
        computed: {
            // 密码强度提示文案等
            passwordTip () {
                let strong = '强';
                let className = 'strong';
                let percent = this.passwordLen > 10 ? 10 : this.passwordLen;
                let color = '#19be6b';

                if (this.passwordLen < 6) {
                    strong = '太短';
                    className = 'low';
                    color = '#ed4014';
                } else if (this.passwordLen < 10) {
                    strong = '中';
                    className = 'medium';
                    color = '#ff9900';
                }

                return {
                    strong,
                    class: `page-account-register-tip-${className}`,
                    percent: percent * 10,
                    color
                }
            }
        },
        methods: {
            ...mapActions('admin/account', [
                'register',
                'login'
            ]),
            handleChangePassword (val) {
                this.passwordLen = val.length;
            },
            /**
             * @description 注册
             * 表单校验已有 iView Pro 自动完成，如有需要修改，请阅读 iView Pro 文档
             */
            handleSubmit (valid, values) {
                if (valid) {
                    if (valid) {
                        const { mail, password, mobile, captcha } = values;
                        this.register({
                            mail,
                            password,
                            mobile,
                            captcha
                        })
                            .then(() => {
                                this.$router.replace({ name: 'register-result' });
                        });
                    }
                }
            },
            /**
             * @description 获取验证码
             * */
            handleGetCaptcha () {

            }
        }
    };
</script>
