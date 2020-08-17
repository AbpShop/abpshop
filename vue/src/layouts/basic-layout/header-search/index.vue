<template>
    <span v-if="isDesktop" class="i-layout-header-trigger i-layout-header-trigger-min i-layout-header-trigger-in i-layout-header-trigger-nohover">
        <input class="i-layout-header-search" type="text" :placeholder="$t('basicLayout.search.placeholder')">
    </span>
    <span v-else class="i-layout-header-trigger i-layout-header-trigger-min">
        <Dropdown trigger="click" class="i-layout-header-search-drop" ref="dropdown">
            <Icon type="ios-search" />
            <DropdownMenu slot="list">
                <div class="i-layout-header-search-drop-main">
                    <Input size="large" prefix="ios-search" type="text" :placeholder="$t('basicLayout.search.placeholder')" />
                    <span class="i-layout-header-search-drop-main-cancel" @click="handleCloseSearch">{{ $t('basicLayout.search.cancel') }}</span>
                </div>
            </DropdownMenu>
        </Dropdown>
    </span>
</template>
<script>
    import { mapState } from 'vuex';

    export default {
        name: 'iHeaderSearch',
        computed: {
            ...mapState('admin/layout', [
                'isDesktop',
                'headerMenu'
            ])
        },
        methods: {
            handleCloseSearch () {
                this.$refs.dropdown.handleClick();
            }
        }
    }
</script>
