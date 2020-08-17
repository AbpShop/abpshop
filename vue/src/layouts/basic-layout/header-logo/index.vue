<template>
    <i-link class="i-layout-header-logo" :class="{ 'i-layout-header-logo-stick': !isMobile }" to="/">
        <img :src="logoSmall" v-if="isMobile">
        <img :src="logo" v-else-if="headerTheme === 'light'">
        <img :src="logo" v-else>
    </i-link>
</template>
<script>
    import { mapState } from 'vuex';
    export default {
        name: 'iHeaderLogo',
        computed: {
            ...mapState('admin/layout', [
                'isMobile',
                'headerTheme'
            ])
        },
        data () {
            return {
                logo: require('@/assets/images/logo.png'),
                logoSmall: require('@/assets/images/logo-small.png')
            };
        },
        mounted () {
            this.getLogo();
        },
        methods: {
            getLogo () {
                this.$store.dispatch('admin/db/get', {
                    dbName: 'sys',
                    path: 'user.info',
                    user: true
                }).then(res => {
                    this.logo = res.logo ? res.logo : this.logo;
                    this.logoSmall = res.logoSmall ? res.logoSmall : this.logoSmall;
                });
            }
        }
    }
</script>
