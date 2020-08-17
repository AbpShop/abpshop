<template>
    <Dropdown placement="right-start" :class="dropdownClasses">
        <li :class="menuItemClasses" v-if="topLevel">
            <i-menu-side-title :menu="menu" hide-title />
        </li>
        <DropdownItem v-else>
            <i-menu-side-title :menu="menu" :selected="openNames.indexOf(menu.path) >= 0" />
            <Icon type="ios-arrow-forward" class="i-layout-menu-side-arrow" />
        </DropdownItem>
        <DropdownMenu slot="list">
            <div class="i-layout-menu-side-collapse-title" v-if="showCollapseMenuTitle">
                <i-menu-side-title :menu="menu" />
            </div>
            <template v-for="(item, index) in menu.children">
                <i-link :to="item.path" :target="item.target" v-if="item.children === undefined || !item.children.length" :key="index">
                    <DropdownItem :divided="item.divided" :class="{ 'i-layout-menu-side-collapse-item-selected': item.path === activePath }">
                        <i-menu-side-title :menu="item" />
                    </DropdownItem>
                </i-link>
                <i-menu-side-collapse v-else :menu="item" :key="index" />
            </template>
        </DropdownMenu>
    </Dropdown>
</template>
<script>
    import iMenuSideTitle from './menu-title';

    import { mapState } from 'vuex';

    export default {
        name: 'iMenuSideCollapse',
        components: { iMenuSideTitle },
        props: {
            menu: {
                type: Object,
                default () {
                    return {}
                }
            },
            // 是否是第一级，区分在于左侧和展开侧
            topLevel: {
                type: Boolean,
                default: false
            }
        },
        computed: {
            ...mapState('admin/layout', [
                'siderTheme',
                'showCollapseMenuTitle'
            ]),
            ...mapState('admin/menu', [
                'activePath',
                'openNames'
            ]),
            dropdownClasses () {
                return {
                    'i-layout-menu-side-collapse-top': this.topLevel,
                    'i-layout-menu-side-collapse-dark': this.siderTheme === 'dark'
                }
            },
            menuItemClasses () {
                return [
                    'ivu-menu-item i-layout-menu-side-collapse-top-item',
                    {
                        'ivu-menu-item-selected ivu-menu-item-active': this.openNames.indexOf(this.menu.path) >= 0 // -active 在高亮时，有背景
                    }
                ]
            }
        }
    }
</script>
