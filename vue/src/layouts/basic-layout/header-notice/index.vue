<template>
    <span class="i-layout-header-trigger i-layout-header-trigger-min i-layout-header-trigger-in">
        <Notification
                :wide="isMobile"
                :badge-props="badgeProps"
                class="i-layout-header-notice"
                :class="{ 'i-layout-header-notice-mobile': isMobile }"
                @on-clear="handleClear"
        >
            <Icon slot="icon" custom="i-icon i-icon-notification"/>
            <NotificationTab title="消息" name="message">
                <NotificationItem
                        v-for="(item, index) in messageList"
                        :key="index"
                        :title="item.title"
                        :icon="item.icon"
                        :icon-color="item.iconColor"
                        :time="item.time"
                        :read="item.read"
                />
            </NotificationTab>
            <NotificationTab title="待办" name="need">
                  <NotificationItem
                          v-for="(item, index) in needList"
                          :key="index"
                          :title="item.title"
                          :icon="item.icon"
                          :icon-color="item.iconColor"
                          :time="item.time"
                          :read="item.read"
                          @on-item-click="jumpUrl(item.url)"
                  />
            </NotificationTab>
        </Notification>
    </span>
</template>
<script>
    import { mapState } from 'vuex';
    import { jnoticeRequest } from '@/api/common';
    import Socket from '@/libs/socket';

    export default {
        name: 'iHeaderNotice',
        data () {
            return {
                badgeProps: {
                    offset: [20, 0]
                },
                needList: [],
                messageList: [],
                messageLoading: false,
                newOrderAudioLink: ''
            }
        },
        computed: {
            ...mapState('admin/layout', [
                'isMobile'
            ])
        },
        mounted () {
            this.getNotict();
            this.$store.dispatch('admin/db/get', {
                dbName: 'sys',
                path: 'user.info',
                user: true
            }).then(res => {
                this.newOrderAudioLink = res.newOrderAudioLink;
            })
            Socket.init(this);
            let that = this;
            that.$on('ADMIN_NEW_PUSH', function (data) {
                that.getNotict();
            })

            that.$on('NEW_ORDER', function (data) {
                console.log(data);
                that.$Notice.info({
                    title: '新订单',
                    duration: 8,
                    desc: '您有一个新的订单(' + data.order_id + '),请注意查看'
                });
                if (this.newOrderAudioLink) (new Audio(this.newOrderAudioLink)).play();
                that.messageList.push({
                    title: '新订单提醒',
                    icon: 'md-bulb',
                    iconColor: '#87d068',
                    time: 0,
                    read: 0
                });
            });
            that.$on('NEW_REFUND_ORDER', function (data) {
                that.$Notice.warning({
                    title: '退款订单提醒',
                    duration: 8,
                    desc: '您有一个订单(' + data.order_id + ')申请退款,请注意查看'
                });
                if (window.newOrderAudioLink) (new Audio(window.newOrderAudioLink)).play();
                that.messageList.push({
                    title: '退款订单提醒',
                    icon: 'md-information',
                    iconColor: '#fe5c57',
                    time: 0,
                    read: 0
                });
            });
            that.$on('WITHDRAW', function (data) {
                that.$Notice.warning({
                    title: '提现提醒',
                    duration: 8,
                    desc: '有用户申请提现(' + data.id + '),请注意查看'
                });
                that.messageList.push({
                    title: '退款订单提醒',
                    icon: 'md-people',
                    iconColor: '#f06292',
                    time: 0,
                    read: 0
                });
            });
            that.$on('STORE_STOCK', function (data) {
                that.$Notice.warning({
                    title: '库存预警',
                    duration: 8,
                    desc: '(' + data.id + ')商品库存不足,请注意查看'
                })
                that.messageList.push({
                    title: '库存预警',
                    icon: 'md-information',
                    iconColor: '#fe5c57',
                    time: 0,
                    read: 0
                });
            });
            that.$on('PAY_SMS_SUCCESS', function (data) {
                that.$Notice.info({
                    title: '短信充值成功',
                    duration: 8,
                    desc: '恭喜您充值' + data.price + '元，获得' + data.number + '条短信'
                });
                that.messageList.push({
                    title: '短信充值成功',
                    icon: 'md-bulb',
                    iconColor: '#87d068',
                    time: 0,
                    read: 0
                });
            });
        },
        methods: {
            jumpUrl (url) {
                this.$router.push({ path: url })
            },
            getNotict () {
                jnoticeRequest().then(res => {
                    this.needList = res.data || [];
                }).catch(() => {})
            },
            handleClear (tab) {
                this.clearUnread(tab.name);
            },
            clearUnread (type) {
                console.log(this[`${type}List`]);
                this[`${type}List`] = this[`${type}List`].map(item => {
                    item.read = 1;
                    return item;
                });
                this[`${type}List`] = [];
            }
        }
    }
</script>
