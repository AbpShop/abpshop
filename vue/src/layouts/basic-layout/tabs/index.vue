<template>
    <div class="i-layout-tabs" :class="classes" :style="styles">
        <div class="i-layout-tabs-main">
            <Tabs
                    type="card"
                    :value="current"
                    :animated="false"
                    closable
                    @on-click="handleClickTab"
                    @on-tab-remove="handleClickClose"
            >
                <TabPane
                        v-for="page in opened"
                        :key="page.fullPath"
                        :label="(h) => tabLabel(h, page)"
                        :name="page.fullPath" />
            </Tabs>
            <Dropdown class="i-layout-tabs-close" @on-click="handleClose">
                <div class="i-layout-tabs-close-main">
                    <Icon type="ios-arrow-down" />
                </div>
                <DropdownMenu slot="list">
                    <DropdownItem name="left">
                        <Icon type="md-arrow-back" />
                        {{ $t('basicLayout.tabs.left') }}
                    </DropdownItem>
                    <DropdownItem name="right">
                        <Icon type="md-arrow-forward" />
                        {{ $t('basicLayout.tabs.right') }}
                    </DropdownItem>
                    <DropdownItem name="other">
                        <Icon type="md-close" />
                        {{ $t('basicLayout.tabs.other') }}
                    </DropdownItem>
                    <DropdownItem name="all">
                        <Icon type="md-close-circle" />
                        {{ $t('basicLayout.tabs.all') }}
                    </DropdownItem>
                </DropdownMenu>
            </Dropdown>
        </div>
    </div>
</template>
<script>
    import { mapState, mapGetters, mapActions } from 'vuex';
    import menuSider from '@/menu/sider';
    import tTitle from '../mixins/translate-title';

    import Setting from '@/setting';

    import { getAllSiderMenu } from '@/libs/system';

    export default {
        name: 'iTabs',
        mixins: [ tTitle ],
        computed: {
            ...mapState('admin/page', [
                'opened',
                'current'
            ]),
            ...mapState('admin/layout', [
                'showTabsIcon',
                'tabsFix',
                'headerFix',
                'headerStick',
                'isMobile',
                'menuCollapse'
            ]),
            ...mapGetters('admin/menu', [
                'hideSider'
            ]),
            classes () {
                return {
                    'i-layout-tabs-fix': this.tabsFix
                }
            },
            isHeaderStick () {
                return this.hideSider;
            },
            styles () {
                let style = {};
                if (this.tabsFix && !this.headerFix) {
                    style.top = `${64 - this.scrollTop}px`;
                }

                const menuWidth = this.isHeaderStick ? 0 : this.menuCollapse ? 80 : Setting.menuSideWidth;
                if (!this.isMobile && this.tabsFix) {
                    style.width = `calc(100% - ${menuWidth}px)`;
                    style.left = `${menuWidth}px`;
                }

                return style;
            }
        },
        data () {
            return {
                // 得到所有侧边菜单，并转为平级，查询图标用
                allSiderMenu: getAllSiderMenu(menuSider),
                scrollTop: 0
            }
        },
        methods: {
            ...mapActions('admin/page', [
                'close',
                'closeLeft',
                'closeRight',
                'closeOther',
                'closeAll'
            ]),
            tabLabel (h, page) {
                const title = h('span', this.tTitle(page.meta.title) || '未命名');
                let slot = [];

                if (this.showTabsIcon) {
                    const fullPathWithoutQuery = page.fullPath.indexOf('?') >= 0 ? page.fullPath.split('?')[0] : page.fullPath;
                    const currentMenu = this.allSiderMenu.find(menu => menu.path === fullPathWithoutQuery) || {};

                    let icon;
                    if (currentMenu.icon) {
                        icon = h('Icon', {
                            props: {
                                type: currentMenu.icon
                            }
                        });
                    } else if (currentMenu.custom) {
                        icon = h('Icon', {
                            props: {
                                custom: currentMenu.custom
                            }
                        });
                    } else if (currentMenu.img) {
                        icon = h('img', {
                            attrs: {
                                src: currentMenu.img
                            }
                        });
                    }

                    if (icon) slot.push(icon);
                    slot.push(title);
                } else {
                    slot.push(title);
                }

                return h('div', {
                    class: 'i-layout-tabs-title'
                }, slot);
            },
            handleClickTab (tabName) {
                const page = this.opened.find(page => page.fullPath === tabName);
                const { name, params, query } = page;

                if (page) this.$router.push({ name, params, query }, () => {});
            },
            handleClickClose (tagName) {
                this.close({
                    tagName
                });
            },
            handleScroll () {
                if (this.tabsFix && !this.headerFix) {
                    const scrollTop = document.body.scrollTop + document.documentElement.scrollTop;
                    this.scrollTop = scrollTop > 64 ? 64 : scrollTop;
                }
            },
            handleClose (name) {
                const params = {
                    pageSelect: this.current
                };
                switch (name) {
                case 'left':
                    this.closeLeft(params);
                    break;
                case 'right':
                    this.closeRight(params);
                    break;
                case 'other':
                    this.closeOther(params);
                    break;
                case 'all':
                    this.closeAll();
                    break;
                }
            }
        },
        mounted () {
            document.addEventListener('scroll', this.handleScroll, { passive: true });
            this.handleScroll();
        },
        beforeDestroy () {
            document.removeEventListener('scroll', this.handleScroll);
        }
    }
</script>
