<template>
    <div class="page-account">
        <div class="page-account-container page-account-container-result">
            <div class="page-account-top">
                <div class="page-account-top-logo">
                    <img src="@/assets/images/logo.png" alt="logo">
                </div>
                <div class="page-account-top-desc">iView Admin Pro 企业级中台前端/设计解决方案</div>
            </div>
            <Result type="success" :title="title" :desc="desc">
                <div slot="actions">
                    <Button size="large" type="primary" to="https://mail.qq.com" target="_blank">查看邮箱</Button>
                    <Button size="large" to="/">返回首页</Button>
                </div>
            </Result>
        </div>
        <i-copyright />
    </div>
</template>
<script>
    import iCopyright from '@/components/copyright';

    export default {
        components: { iCopyright },
        data () {
            return {
                title: '你的账户：admin 注册成功',
                desc: '激活邮件已发送到你的邮箱中，邮件有效期为24小时。请及时登录邮箱，点击邮件中的链接激活帐户。'
            }
        }
    };
</script>
