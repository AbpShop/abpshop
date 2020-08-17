<template>
    <span class="i-layout-menu-side-title">
        <span class="i-layout-menu-side-title-icon" :class="{ 'i-layout-menu-side-title-icon-single': hideTitle }" v-if="menu.icon || menu.custom">
            <Icon :type="menu.icon" v-if="menu.icon" />
            <Icon :custom="menu.custom" v-else-if="menu.custom" />
            <!--<img :src="menu.img" v-else-if="menu.img" />-->
        </span>
        <span class="i-layout-menu-side-title-icon-null" :class="{ 'i-layout-menu-side-title-icon-single': hideTitle }" v-else >
            <Icon :custom="null" />
        </span>
        <span class="i-layout-menu-side-title-text" :class="{ 'i-layout-menu-side-title-text-selected': selected }" v-if="!hideTitle">{{ tTitle(menu.title) }}</span>
    </span>
</template>
<script>
    import tTitle from '../mixins/translate-title';

    export default {
        name: 'iMenuSideTitle',
        mixins: [ tTitle ],
        props: {
            menu: {
                type: Object,
                default () {
                    return {}
                }
            },
            hideTitle: {
                type: Boolean,
                default: false
            },
            // 用于侧边栏收起 Dropdown 当前高亮
            selected: {
                type: Boolean,
                default: false
            }
        }
    }
</script>
