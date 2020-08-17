<template>
    <div>
        <div class="i-layout-sider-logo" :class="{ 'i-layout-sider-logo-dark': siderTheme === 'dark' }">
            <transition name="fade-quick">
                <i-link to="/" v-show="!hideLogo">
                    <img :src="logoSmall" v-if="menuCollapse">
                    <img :src="logo" v-else-if="siderTheme === 'light'">
                    <img :src="logo" v-else>
                </i-link>
            </transition>
        </div>
        <Menu
                ref="menu"
                class="i-layout-menu-side i-scrollbar-hide"
                :theme="siderTheme"
                :accordion="menuAccordion"
                :active-name="activePath"
                :open-names="openNames"
                width="auto">
            <template v-if="!menuCollapse" v-for="(item, index) in filterSider">
                <i-menu-side-item v-if="item.children === undefined || !item.children.length" :menu="item" :key="index" />
                <i-menu-side-submenu v-else :menu="item" :key="index" />
            </template>
            <template v-else>
                <Tooltip :content="tTitle(item.title)" placement="right" v-if="item.children === undefined || !item.children.length" :key="index">
                    <i-menu-side-item :menu="item" hide-title />
                </Tooltip>
                <i-menu-side-collapse v-else :menu="item" :key="index" top-level />
            </template>
        </Menu>
    </div>
</template>
<script>
    import iMenuSideItem from './menu-item';
    import iMenuSideSubmenu from './submenu';
    import iMenuSideCollapse from './menu-collapse';
    import tTitle from '../mixins/translate-title';

    import { mapState, mapGetters } from 'vuex';

    export default {
        name: 'iMenuSide',
        mixins: [ tTitle ],
        components: { iMenuSideItem, iMenuSideSubmenu, iMenuSideCollapse },
        props: {
            hideLogo: {
                type: Boolean,
                default: false
            }
        },
        data () {
            return {
                logo: require('@/assets/images/logo.png'),
                logoSmall: require('@/assets/images/logo-small.png')
            };
        },
        computed: {
            ...mapState('admin/layout', [
                'siderTheme',
                'menuAccordion',
                'menuCollapse'
            ]),
            ...mapState('admin/menu', [
                'activePath',
                'openNames'
            ]),
            ...mapGetters('admin/menu', [
                'filterSider'
            ])
        },
        watch: {
            '$route': {
                handler () {
                    this.handleUpdateMenuState();
                },
                immediate: true
            },
            // 在展开/收起侧边菜单栏时，更新一次 menu 的状态
            menuCollapse () {
                this.handleUpdateMenuState();
            }
        },
        mounted () {
            this.getLogo();
        },
        methods: {
            handleUpdateMenuState () {
                this.$nextTick(() => {
                    if (this.$refs.menu) {
                        this.$refs.menu.updateActiveName();
                        if (this.menuAccordion) this.$refs.menu.updateOpened();
                    }
                });
            },
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
