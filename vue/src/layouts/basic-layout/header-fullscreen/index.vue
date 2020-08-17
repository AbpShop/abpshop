<template>
    <span class="i-layout-header-trigger i-layout-header-trigger-min" @click="toggleFullscreen">
        <Icon custom="i-icon i-icon-full-screen" v-show="!isFullscreen" />
        <Icon custom="i-icon i-icon-exit-full-screen" v-show="isFullscreen" />
    </span>
</template>
<script>
    import { mapState, mapActions } from 'vuex';

    export default {
        name: 'iHeaderFullscreen',
        computed: {
            ...mapState('admin/layout', [
                'isFullscreen'
            ])
        },
        methods: {
            ...mapActions('admin/layout', [
                'toggleFullscreen'
            ])
        }
    }
</script>
