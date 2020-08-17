<template>
    <GlobalFooter class="i-copyright" :links="links" :copyright="copyright" />
</template>
<script>
    export default {
        name: 'i-copyright',
        data () {
            return {
                links: [
                    {
                        title: '官网',
                        key: '官网',
                        href: 'https://www.yznt.com',
                        blankTarget: true
                    },
                    {
                        title: '社区',
                        key: '社区',
                        href: 'http://bbs.yznt.com',
                        blankTarget: true
                    },
                    {
                        title: '文档',
                        key: '文档',
                        href: 'https://help.yznt.com',
                        blankTarget: true
                    }
                ],
                copyright: 'Copyright © 2020 AbpShop'
            }
        },
        mounted () {
            this.getVersion();
        },
        methods: {
            getVersion () {
                this.$store.dispatch('admin/db/get', {
                    dbName: 'sys',
                    path: 'user.info',
                    user: true
                }).then(res => {
                    this.copyright += res.version ? '  |  ' + res.version : '';
                })
            }
        }
    }
</script>
<style lang="less">
    .i-copyright{
        flex: 0 0 auto;
    }
</style>
