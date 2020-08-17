<template>
    <div class="i-layout-menu-head" :class="{ 'i-layout-menu-head-mobile': isMobile }">
        <Menu mode="horizontal" :active-name="headerName" v-if="!isMobile && !isMenuLimit" ref="menu">
            <MenuItem v-for="(item,index) in filterHeader" :to="item.path"  :name="item.path" :key="index">
                <i-menu-head-title :item="item" />
            </MenuItem>
        </Menu>
        <div class="i-layout-header-trigger i-layout-header-trigger-min i-layout-header-trigger-in i-layout-header-trigger-no-height" v-else>
            <Dropdown trigger="click" :class="{ 'i-layout-menu-head-mobile-drop': isMobile }">
                <Icon type="ios-apps" />
                <DropdownMenu slot="list">
                    <i-link v-for="item in filterHeader" :to="item.path"  :key="item.path">
                        <DropdownItem>
                            <i-menu-head-title :item="item" />
                        </DropdownItem>
                    </i-link>
                </DropdownMenu>
            </Dropdown>
        </div>
    </div>
</template>
<script>
    import iMenuHeadTitle from './title';
    import { mapState, mapGetters } from 'vuex';
    import { getStyle } from 'view-design/src/utils/assist';
    import { on, off } from 'view-design/src/utils/dom';
    import { throttle } from 'lodash';

    export default {
        name: 'iMenuHead',
        components: { iMenuHeadTitle },
        computed: {
            ...mapState('admin/layout', [
                'isMobile'
            ]),
            ...mapState('admin/menu', [
                'headerName'
            ]),
            ...mapGetters('admin/menu', [
                'filterHeader'
            ])
        },
        data () {
            return {
                handleResize: () => {},
                isMenuLimit: false,
                menuMaxWidth: 0 // 达到这个值后，menu 就显示不下了
            }
        },
        methods: {
            handleGetMenuHeight () {
                const menuWidth = parseInt(getStyle(this.$el, 'width'));
                const $menu = this.$refs.menu;
                if ($menu) {
                    const menuHeight = parseInt(getStyle(this.$refs.menu.$el, 'height'));
                    if (menuHeight > 64) {
                        if (!this.isMenuLimit) {
                            this.menuMaxWidth = menuWidth;
                        }
                        this.isMenuLimit = true;
                    }
                } else if (menuWidth >= this.menuMaxWidth) {
                    this.isMenuLimit = false;
                }
            }
        },
        watch: {
            filterHeader () {
                this.handleGetMenuHeight();
            },
            isMobile () {
                this.handleGetMenuHeight();
            }
        },
        mounted () {
            this.handleResize = throttle(this.handleGetMenuHeight, 100, { leading: false });
            on(window, 'resize', this.handleResize);
            this.handleGetMenuHeight();
        },
        beforeDestroy () {
            off(window, 'resize', this.handleResize);
        }
    }
</script>
