/**
 * iView Admin Pro 业务配置
 * */
// 请求接口地址 如果没有配置自动获取当前网址路径
const VUE_APP_API_URL = process.env.VUE_APP_API_URL || `${location.origin}/adminapi`;
const VUE_APP_WS_URL = process.env.VUE_APP_WS_URL || `ws:${location.hostname}:20003`;

const Setting = {
    /**
     * 基础配置
     * */
    // 网页标题的后缀
    titleSuffix: 'AbpShop',
    // 路由模式，可选值为 history 或 hash
    routerMode: 'history',
    // 页面切换时，是否显示模拟的进度条
    showProgressBar: true,
    // 接口请求地址
    apiBaseURL: VUE_APP_API_URL,
    // socket连接
    wsSocketUrl: VUE_APP_WS_URL,
    // 接口请求返回错误时，弹窗的持续时间，单位：秒
    modalDuration: 3,
    // 接口请求返回错误时，弹窗的类型，可选值为 Message 或 Notice
    errorModalType: 'Message',
    // Cookies 默认保存时间，单位：天
    cookiesExpires: 1,
    /**
     * 多语言配置
     * */
    i18n: {
        // 默认语言
        default: 'zh-CN',
        // 是否根据用户电脑配置自动设置语言（仅第一次有效）
        auto: false
    },
    /**
     * 布局配置
     * */
    // 侧边菜单宽度，单位 px，不可动态修改，需与 setting.less 的 @menuSideWidth 保持一致
    menuSideWidth: 200,
    layout: {
        // 侧边栏风格，可选值为 dark 或 light
        siderTheme: 'light',
        // 顶栏风格，可选值为 light、dark 或 primary
        headerTheme: 'primary',
        // 顶栏是否置顶，开启后会覆盖侧边栏，需开启 headerFix
        headerStick: true,
        // 是否开启多 Tabs 页签
        tabs: true,
        // 多 Tabs 页签是否显示图标，开启 tabs 时有效
        showTabsIcon: true,
        // 是否固定多 Tabs 多页签
        tabsFix: true,
        // 是否固定侧边栏
        siderFix: false,
        // 是否固定顶栏
        headerFix: true,
        // 是否在下滑时隐藏顶栏，需开启 headerFix，如果开启了 tabsFix，Tabs 也会被隐藏
        headerHide: false,
        // 是否显示顶部菜单栏
        // 一般来说，侧边的菜单栏足以满足大部分业务，如需动态切换侧边栏，可开启此选项启用顶部一级菜单，此时侧边栏将作为二级菜单
        headerMenu: false,
        // 侧边菜单栏是否开启手风琴模式
        menuAccordion: true,
        // 是否显示折叠侧边栏按钮，移动端下会自动强制开启
        showSiderCollapse: true,
        // 侧边菜单栏是否默认折起
        menuCollapse: false,
        // 侧边菜单折起时，是否在子菜单前显示父级菜单名称
        showCollapseMenuTitle: true,
        // 是否显示重载按钮
        showReload: true,
        // 是否显示搜索
        showSearch: false,
        // 是否显示通知
        showNotice: true,
        // 是否显示全屏
        showFullscreen: true,
        // 在手机访问时，是否在顶部显示小尺寸 logo
        showMobileLogo: true,
        // 是否显示全局面包屑，开启 headerMenu 时不可用
        showBreadcrumb: true,
        // 全局面包屑是否显示图标，开启 showBreadcrumb 时有效
        showBreadcrumbIcon: false,
        // 是否显示日志入口，开启与否，不影响日志记录，如不希望用户看到可关闭
        showLog: true,
        // 是否显示多语言
        showI18n: false,
        // 是否支持动态修改布局配置，移动端下会自动强制关闭
        enableSetting: false,
        // 退出登录时，是否二次确认
        logoutConfirm: true
    },
    /**
     * 多页 Tabs
     * */
    page: {
        // 默认打开的页签
        opened: ['home/index']
    },
    /**
     * 功能配置
     * */
    // 相同路由，不同参数间进行切换，是否强力更新
    sameRouteForceUpdate: false,
    // 是否使用动态侧边菜单
    dynamicSiderMenu: true
};

export default Setting;
