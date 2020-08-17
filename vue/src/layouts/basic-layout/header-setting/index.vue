<template>
    <span class="i-layout-header-trigger i-layout-header-trigger-min" @click="showSetting">
        <Icon type="md-more" />

        <Drawer v-model="visible" width="280">
            <Divider size="small">主题风格设置</Divider>

            <div class="i-layout-header-setting-item">
                <div class="i-layout-header-setting-item-radio" :class="{ 'on': siderTheme === 'dark' }" @click="handleChangeSetting('siderTheme', 'dark')">
                    <Tooltip content="暗色侧边栏" placement="top" transfer>
                        <img src="@/assets/svg/nav-theme-dark.svg">
                    </Tooltip>
                </div>
                <div class="i-layout-header-setting-item-radio" :class="{ 'on': siderTheme === 'light' }" @click="handleChangeSetting('siderTheme', 'light')">
                    <Tooltip content="亮色侧边栏" placement="top" transfer>
                        <img src="@/assets/svg/nav-theme-light.svg">
                    </Tooltip>
                </div>
            </div>
            <div class="i-layout-header-setting-item">
                <div class="i-layout-header-setting-item-radio" :class="{ 'on': headerTheme === 'light' }" @click="handleChangeSetting('headerTheme', 'light')">
                    <Tooltip content="亮色顶栏" placement="top" transfer>
                        <img src="@/assets/svg/nav-theme-dark.svg">
                    </Tooltip>
                </div>
                <div class="i-layout-header-setting-item-radio" :class="{ 'on': headerTheme === 'dark' }" @click="handleChangeSetting('headerTheme', 'dark')">
                    <Tooltip content="暗色顶栏" placement="top" transfer>
                        <img src="@/assets/svg/header-theme-dark.svg">
                    </Tooltip>
                </div>
                <div class="i-layout-header-setting-item-radio" :class="{ 'on': headerTheme === 'primary' }" @click="handleChangeSetting('headerTheme', 'primary')">
                    <Tooltip content="主色顶栏" placement="top" transfer>
                        <img src="@/assets/svg/header-theme-primary.svg">
                    </Tooltip>
                </div>
            </div>

            <Divider size="small">导航设置</Divider>

            <div class="i-layout-header-setting-item">
                <span class="i-layout-header-setting-item-desc">固定侧边栏</span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="siderFix" @on-change="(val) => handleChangeSetting('siderFix', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item">
                <span class="i-layout-header-setting-item-desc">固定顶栏</span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="headerFix" @on-change="(val) => handleChangeSetting('headerFix', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item" :class="{ 'i-layout-header-setting-item-disabled': !headerFix }">
                <span class="i-layout-header-setting-item-desc">
                    下滑时隐藏顶栏
                    <Tooltip placement="top" content="需开启固定顶栏" transfer>
                        <Icon type="ios-help-circle-outline" />
                    </Tooltip>
                </span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="headerHide" :disabled="!headerFix" @on-change="(val) => handleChangeSetting('headerHide', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item" :class="{ 'i-layout-header-setting-item-disabled': !headerFix }">
                <span class="i-layout-header-setting-item-desc">
                    置顶顶栏
                    <Tooltip placement="top" content="需开启固定顶栏" transfer>
                        <Icon type="ios-help-circle-outline" />
                    </Tooltip>
                </span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="headerStick" :disabled="!headerFix" @on-change="(val) => handleChangeSetting('headerStick', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item">
                <span class="i-layout-header-setting-item-desc">侧边栏开启手风琴模式</span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="menuAccordion" @on-change="(val) => handleChangeSetting('menuAccordion', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item">
                <span class="i-layout-header-setting-item-desc">显示折叠侧边栏按钮</span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="showSiderCollapse" @on-change="(val) => handleChangeSetting('showSiderCollapse', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item">
                <span class="i-layout-header-setting-item-desc">侧边栏折叠时显示父级菜单名</span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="showCollapseMenuTitle" @on-change="(val) => handleChangeSetting('showCollapseMenuTitle', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item">
                <span class="i-layout-header-setting-item-desc">
                    显示全局面包屑导航
                    <Tooltip placement="top" content="headerMenu 开启时无效" transfer>
                        <Icon type="ios-help-circle-outline" />
                    </Tooltip>
                </span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="showBreadcrumb" @on-change="(val) => handleChangeSetting('showBreadcrumb', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item" :class="{ 'i-layout-header-setting-item-disabled': !showBreadcrumb }">
                <span class="i-layout-header-setting-item-desc">
                    全局面包屑显示图标
                    <Tooltip placement="top" content="需开启全局面包屑导航" transfer>
                        <Icon type="ios-help-circle-outline" />
                    </Tooltip>
                </span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="showBreadcrumbIcon" :disabled="!showBreadcrumb" @on-change="(val) => handleChangeSetting('showBreadcrumbIcon', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item">
                <span class="i-layout-header-setting-item-desc">显示重载页面按钮</span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="showReload" @on-change="(val) => handleChangeSetting('showReload', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item">
                <span class="i-layout-header-setting-item-desc">显示多语言选择</span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="showI18n" @on-change="(val) => handleChangeSetting('showI18n', val)" />
                </span>
            </div>

            <Divider size="small">其它设置</Divider>

            <div class="i-layout-header-setting-item">
                <span class="i-layout-header-setting-item-desc">开启多页签</span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="tabs" @on-change="(val) => handleChangeSetting('tabs', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item" :class="{ 'i-layout-header-setting-item-disabled': !tabs }">
                <span class="i-layout-header-setting-item-desc">
                    多页签显示图标
                    <Tooltip placement="top" content="需开启多页签" transfer>
                        <Icon type="ios-help-circle-outline" />
                    </Tooltip>
                </span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="showTabsIcon" :disabled="!tabs" @on-change="(val) => handleChangeSetting('showTabsIcon', val)" />
                </span>
            </div>
            <div class="i-layout-header-setting-item" :class="{ 'i-layout-header-setting-item-disabled': !tabs }">
                <span class="i-layout-header-setting-item-desc">
                    固定多页签
                    <Tooltip placement="top" content="需开启多页签" transfer>
                        <Icon type="ios-help-circle-outline" />
                    </Tooltip>
                </span>
                <span class="i-layout-header-setting-item-action">
                    <Switch size="small" :value="tabsFix" :disabled="!tabs" @on-change="(val) => handleChangeSetting('tabsFix', val)" />
                </span>
            </div>
            <Alert type="warning">
                <div slot="desc">
                    该功能主要实时预览各种布局效果，更多完整配置在 <strong>setting.js</strong> 中设置。建议在生产环境关闭该布局预览功能。
                </div>
            </Alert>
        </Drawer>
    </span>
</template>
<script>
    import { mapState, mapMutations } from 'vuex';

    export default {
        name: 'iHeaderSetting',
        data () {
            return {
                visible: false
            }
        },
        computed: {
            ...mapState('admin/layout', [
                'siderTheme',
                'headerTheme',
                'headerStick',
                'siderFix',
                'headerFix',
                'headerHide',
                'menuAccordion',
                'showSiderCollapse',
                'tabs',
                'showTabsIcon',
                'tabsFix',
                'showBreadcrumb',
                'showBreadcrumbIcon',
                'showReload',
                'showI18n',
                'showCollapseMenuTitle'
            ])
        },
        methods: {
            ...mapMutations('admin/layout', [
                'updateLayoutSetting'
            ]),
            showSetting () {
                this.visible = true;
            },
            handleChangeSetting (key, value) {
                this.updateLayoutSetting({
                    key,
                    value
                });
            }
        }
    }
</script>
