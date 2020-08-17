<template>
    <span class="i-layout-header-trigger i-layout-header-trigger-min">
        <Dropdown :trigger="isMobile ? 'click' : 'hover'" class="i-layout-header-user" :class="{ 'i-layout-header-user-mobile': isMobile }" @on-click="handleClick">
            <Avatar size="small" :src="info.avatar" v-if="infor.head_pic" />
            <span class="i-layout-header-user-name" v-if="!isMobile">{{ infor.account }}</span>
            <DropdownMenu slot="list">
                <i-link to="/admin/system/user">
                    <DropdownItem>
                        <Icon type="ios-contact-outline" />
                        <span>{{ $t('basicLayout.user.center') }}</span>
                    </DropdownItem>
                </i-link>
                <!--<i-link to="/setting/account">-->
                    <!--<DropdownItem>-->
                        <!--<Icon type="ios-settings-outline" />-->
                        <!--<span>{{ $t('basicLayout.user.setting') }}</span>-->
                    <!--</DropdownItem>-->
                <!--</i-link>-->
                <DropdownItem divided name="logout">
                    <Icon type="ios-log-out" />
                    <span>{{ $t('basicLayout.user.logOut') }}</span>
                </DropdownItem>
            </DropdownMenu>
        </Dropdown>
    </span>
</template>
<script>
    import { mapState, mapActions } from 'vuex';

    export default {
        name: 'iHeaderUser',
        data () {
            return {
                infor: ''
            }
        },
        computed: {
            ...mapState('admin/user', [
                'info'
            ]),
            ...mapState('admin/layout', [
                'isMobile',
                'logoutConfirm'
            ])
        },
        methods: {
            ...mapActions('admin/account', [
                'logout'
            ]),
            handleClick (name) {
                if (name === 'logout') {
                    this.logout({
                        confirm: this.logoutConfirm,
                        vm: this
                    });
                }
            }
        },
        async mounted () {
            const db = await this.$store.dispatch('admin/db/database', {
                user: true
            });
            this.infor = db.get('user_info').value();
        }
    }
</script>
