<template>
    <Breadcrumb class="i-layout-header-breadcrumb" v-if="!isLimit" ref="breadcrumb">
        <BreadcrumbItem>
            <i-menu-head-title :item="topItem" :hide-icon="!showBreadcrumbIcon" />
        </BreadcrumbItem>
        <BreadcrumbItem v-for="(item,index) in items" :key="index">
            <i-menu-head-title :item="item" :hide-icon="!showBreadcrumbIcon" />
        </BreadcrumbItem>
        <BreadcrumbItem>
            <i-menu-head-title :item="siderMenuObject[activePath]" :hide-icon="!showBreadcrumbIcon" />
        </BreadcrumbItem>
    </Breadcrumb>
</template>
<script>
    import { mapState } from 'vuex';
    import { flattenSiderMenu } from '@/libs/system';
    import iMenuHeadTitle from '../menu-head/title';
    import { on, off } from 'view-design/src/utils/dom';
    import { findComponentUpward, getStyle } from 'view-design/src/utils/assist';
    import { throttle } from 'lodash';

    export default {
        name: 'iHeaderBreadcrumb',
        components: { iMenuHeadTitle },
        computed: {
            ...mapState('admin/layout', [
                'showBreadcrumbIcon',
                'menuCollapse'
            ]),
            ...mapState('admin/menu', [
                'openNames',
                'activePath',
                'header',
                'headerName'
            ]),
            siderMenuObject () {
                let obj = {};
                if (this.allSiderMenu.length > 0) {
                    this.allSiderMenu.forEach(item => {
                        if ('path' in item) {
                            obj[item.path] = item;
                        }
                    });
                }

                return obj;
            },
            items () {
                let items = [...this.openNames];
                let newItems = [];
                items.forEach(i => {
                    newItems.push(this.siderMenuObject[i]);
                });
                return newItems;
            },
            // 第一级，默认是 menu/header.js 中的第一项
            topItem () {
                return this.header.find(item => item.name === this.headerName);
            }
        },
        data () {
            return {
                // 得到所有侧边菜单，并转为平级，查询图标及显示对应内容
                allSiderMenu: [],
                handleResize: () => {},
                isLimit: false,
                maxWidth: 560,
                breadcrumbWidth: 0
            }
        },
        async created () {
            // const db = await this.$store.dispatch('admin/db/database', {
            //     user: true
            // });
            // const menuSider = db.get('menus').value();
            let menuSider = this.$store.state.admin.menus.menusName;
            this.allSiderMenu = flattenSiderMenu(menuSider, []);
        },
        methods: {
            handleCheckWidth () {
                const $header = findComponentUpward(this, 'Header');
                if ($header) {
                    const headerWidth = parseInt(getStyle($header.$el, 'width'));
                    this.$nextTick(() => {
                        this.isLimit = headerWidth - this.maxWidth <= this.breadcrumbWidth;
                    });
                }
            },
            handleGetWidth () {
                this.isLimit = false;
                this.$nextTick(() => {
                    const $breadcrumb = this.$refs.breadcrumb;
                    if ($breadcrumb) {
                        this.breadcrumbWidth = parseInt(getStyle($breadcrumb.$el, 'width'));
                    }
                });
            }
        },
        watch: {
            topItem: {
                handler () {
                    this.handleGetWidth();
                    this.handleCheckWidth();
                },
                deep: true
            },
            items: {
                handler () {
                    this.handleGetWidth();
                    this.handleCheckWidth();
                },
                deep: true
            },
            activePath: {
                handler () {
                    this.handleGetWidth();
                    this.handleCheckWidth();
                },
                deep: true
            }
        },
        mounted () {
            this.handleResize = throttle(this.handleCheckWidth, 100, { leading: false });
            on(window, 'resize', this.handleResize);
            this.handleGetWidth();
            this.handleCheckWidth();
        },
        beforeDestroy () {
            off(window, 'resize', this.handleResize);
        }
    }
</script>
