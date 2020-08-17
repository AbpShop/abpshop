<template>
    <div class="page-account">
        <div class="container" :class="[ fullWidth > 768 ? 'containerSamll':'containerBig']">
            <div class="index_from page-account-container">
                <div class="page-account-top ">
                    <div class="page-account-top-logo">
                        <img :src="login_logo" alt="logo">
                    </div>
                </div>
                <Form ref="formInline" :model="formInline" :rules="ruleInline"
                      @keyup.enter="handleSubmit('formInline')">
                    <FormItem prop="username">
                        <Input type="text" v-model="formInline.username" prefix="ios-contact-outline"
                               placeholder="请输入用户名" size="large"/>
                    </FormItem>
                    <FormItem prop="password">
                        <Input type="password" v-model="formInline.password" prefix="ios-lock-outline"
                               placeholder="请输入密码" size="large"/>
                    </FormItem>
                    <FormItem prop="code">
                        <div class="code">
                            <Input type="text" v-model="formInline.code" prefix="ios-keypad-outline"
                                   placeholder="请输入验证码" size="large"/>
                            <img :src="imgcode" class="pictrue" @click="captchas"/>
                        </div>
                    </FormItem>
                    <FormItem>
                        <Button type="primary" long size="large" @click="handleSubmit('formInline')" class="btn">{{
                            $t('page.login.submit') }}
                        </Button>
                    </FormItem>
                </Form>
            </div>
        </div>
        <Modal v-model="modals" scrollable footer-hide closable title="请完成安全校验" :mask-closable="false" :z-index="2"
               width="342">
            <div class="captchaBox">
                <div id="captcha" style="position: relative" ref="captcha"></div>
                <div id="msg"></div>
            </div>
        </Modal>
    </div>
</template>
<script>
    import { AccountLogin, loginInfoApi } from '@/api/account';
    import mixins from '../mixins';
    import Setting from '@/setting';
    import util from '@/libs/util';
    import '../../../assets/js/canvas-nest.min';
    import '../../../assets/js/jigsaw.js';

    export default {
        mixins: [mixins],
        data () {
            return {
                fullWidth: document.documentElement.clientWidth,
                swiperOption: {
                    pagination: '.swiper-pagination',
                    autoplay: true
                },
                modals: false,
                autoLogin: true,
                imgcode: '',
                formInline: {
                    username: '',
                    password: '',
                    code: ''
                },
                ruleInline: {
                    username: [
                        { required: true, message: '请输入用户名', trigger: 'blur' }
                    ],
                    password: [
                        { required: true, message: '请输入密码', trigger: 'blur' }
                    ],
                    code: [
                        { required: true, message: '请输入验证码', trigger: 'blur' }
                    ]
                },
                errorNum: 0,
                jigsaw: null,
                login_logo: '',
                swiperList: [],
                defaultSwiperList: require('@/assets/images/sw.jpg')
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
            window.addEventListener('resize', this.handleResize)
        },
        watch: {
            fullWidth (val) {
                // 为了避免频繁触发resize函数导致页面卡顿，使用定时器
                if (!this.timer) {
                    // 一旦监听到的screenWidth值改变，就将其重新赋给data里的screenWidth
                    this.screenWidth = val
                    this.timer = true
                    let that = this
                    setTimeout(function () {
                        // 打印screenWidth变化的值
                        that.timer = false
                    }, 400)
                }
            },
            $route (n) {
                this.imgcode = Setting.apiBaseURL + '/captcha_pro?' + Date.parse(new Date());
            }
        },
        mounted: function () {
            this.$nextTick(() => {
                // /* eslint-disable */
                let that = this;
                this.jigsaw = jigsaw.init({
                    el: this.$refs.captcha,
                    onSuccess () {
                        that.modals = false;
                        that.closeModel();
                    },
                    onFail: this.closefail,
                    onRefresh () {
                    }
                });
                if (this.screenWidth < 768) {
                    document.getElementsByTagName('canvas')[0].removeAttribute('class', 'index_bg');
                } else {
                    document.getElementsByTagName('canvas')[0].className = 'index_bg';
                }
                this.swiperData();
            });
            this.imgcode = Setting.apiBaseURL + '/captcha_pro?' + Date.parse(new Date());
        },
        methods: {
            swiperData () {
                loginInfoApi().then(res => {
                    let data = res.data || {};
                    this.login_logo = data.login_logo ? data.login_logo : require('@/assets/images/logo.png');
                    this.swiperList = data.slide.length ? data.slide : [{ slide: this.defaultSwiperList }];
                }).catch(res => {
                    this.$Message.error(res.msg)
                })
            },
            // 关闭模态框
            closeModel () {
                let msg = this.$Message.loading({
                    content: '登录中...',
                    duration: 0
                });
                AccountLogin({
                    account: this.formInline.username,
                    pwd: this.formInline.password,
                    imgcode: this.formInline.code
                }).then(async res => {
                    msg();
                    let expires = this.getExpiresTime(res.data.expires_time);
                    // 记录用户登陆信息
                    util.cookies.set('uuid', res.data.user_info.id, {
                        expires: expires
                    });
                    util.cookies.set('token', res.data.token, {
                        expires: expires
                    });
                    util.cookies.set('expires_time', res.data.expires_time, {
                        expires: expires
                    });
                    const db = await this.$store.dispatch('admin/db/database', {
                        user: true
                    });
                    // 保存菜单信息
                    db.set('menus', res.data.menus).set('unique_auth', res.data.unique_auth).set('user_info', res.data.user_info).write();
                    // 记录用户信息
                    this.$store.dispatch('admin/user/set', {
                        name: res.data.user_info.account,
                        avatar: res.data.user_info.head_pic,
                        access: res.data.unique_auth,
                        logo: res.data.logo,
                        logoSmall: res.data.logo_square,
                        version: res.data.version
                    });
                    if (this.jigsaw) this.jigsaw.reset();
                    return this.$router.replace({ path: this.$route.query.redirect || '/admin/' });
                }).catch(res => {
                    msg();
                    let data = res === undefined ? {} : res;
                    this.errorNum++;
                    this.imgcode = Setting.apiBaseURL + '/captcha_pro?' + Date.parse(new Date());
                    this.$Message.error(data.msg || '登录失败');
                    if (this.jigsaw) this.jigsaw.reset();
                });
            },
            getExpiresTime (expiresTime) {
                let nowTimeNum = Math.round(new Date() / 1000);
                let expiresTimeNum = expiresTime - nowTimeNum;
                return parseFloat(parseFloat(parseFloat(expiresTimeNum / 60) / 60) / 24);
            },
            closefail () {
                if (this.jigsaw) this.jigsaw.reset();
                this.$Message.error('校验错误');
            },
            handleResize (event) {
                this.fullWidth = document.documentElement.clientWidth
                if (this.fullWidth < 768) {
                    document.getElementsByTagName('canvas')[0].removeAttribute('class', 'index_bg');
                } else {
                    document.getElementsByTagName('canvas')[0].className = 'index_bg';
                }
            },
            captchas: function () {
                this.imgcode = Setting.apiBaseURL + '/captcha_pro?' + Date.parse(new Date());
            },
            handleSubmit (name) {
                this.$refs[name].validate((valid) => {
                    if (valid) {
                        if (this.errorNum >= 2) {
                            this.modals = true;
                        } else {
                            this.closeModel();
                        }
                    }
                })
            }
        },
        beforeCreate () {
            if (this.fullWidth < 768) {
                document.getElementsByTagName('canvas')[0].removeAttribute('class', 'index_bg');
            } else {
                document.getElementsByTagName('canvas')[0].className = 'index_bg';
            }
        },
        beforeDestroy: function () {
            window.removeEventListener('resize', this.handleResize);
            document.getElementsByTagName('canvas')[0].removeAttribute('class', 'index_bg');
        }
    };
</script>
<style scoped lang="stylus">
    .page-account {
        display: flex;
    }

    .page-account .code {
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .page-account .code .pictrue {
        height: 40px;
    }

    .swiperPross {
        border-radius: 6px 0px 0px 6px;
    }

    .swiperPross, .swiperPic, .swiperPic img {
        width: 510px;
        height: 100%;
    }

    .swiperPic img {
        width: 100%;
        height: 100%;
    }

    .container {
        height: 400px !important;
        padding: 0 !important;
        /*overflow: hidden;*/
        border-radius: 6px;
        z-index: 1;
        display: flex;
    }

    .containerSamll {
        /*width: 56% !important;*/
        background: #fff !important;
    }

    .containerBig {
        width: auto !important;
        background: #f7f7f7 !important;
    }

    .index_from {
        padding: 0 40px 32px 40px;
        height: 400px;
        box-sizing: border-box;
    }

    .page-account-top {
        padding: 20px 0 !important;
        box-sizing: border-box !important;
        display: flex;
        justify-content: center;
    }

    .page-account-container {
        border-radius: 0px 6px 6px 0px;
    }

    .btn {
        background: linear-gradient(90deg, rgba(25, 180, 241, 1) 0%, rgba(14, 115, 232, 1) 100%) !important;
    }

    .captchaBox {
        width: 310px;
    }

    input {
        display: block;
        width: 290px;
        line-height: 40px;
        margin: 10px 0;
        padding: 0 10px;
        outline: none;
        border: 1px solid #c8cccf;
        border-radius: 4px;
        color: #6a6f77;
    }

    #msg {
        width: 100%;
        line-height: 40px;
        font-size: 14px;
        text-align: center;
    }

    a:link, a:visited, a:hover, a:active {
        margin-left: 100px;
        color: #0366D6;
    }

    .index_from >>> .ivu-input-large
        font-size:14px!important

</style>
