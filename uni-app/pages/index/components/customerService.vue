<template>
	<view style="touch-action: none;">
		<!-- #ifdef H5 -->
		<view class="customerService" :style="'top:'+topConfig" @touchmove.stop.prevent="setTouchMove">
			<navigator class="pictrue" url="/pages/customer_list/chat" hover-class="none">
				<image :src="logoConfig"></image>
			</navigator>
		</view>
		<!-- #endif -->
		<!-- #ifdef MP -->
		<view class="customerService" :style="'top:'+topConfig" @touchmove.stop.prevent="setTouchMove">
			<button class="pictrue" open-type='contact' hover-class='none'>
				<image :src="logoConfig"></image>
			</button>
		</view>
		<!-- #endif -->
	</view>
</template>

<script>
	export default {
		name: 'customerService',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				logoConfig: this.dataConfig.logoConfig.url,
				topConfig: this.dataConfig.topConfig.val+'%'
			};
		},
		created() {},
		methods: {
			setTouchMove(e) {
				var that = this;
				if (e.touches[0].clientY < 545 && e.touches[0].clientY > 66) {
					that.topConfig = e.touches[0].clientY+'px'
				}
			},
		}
	}
</script>

<style lang="scss">
	.customerService {
		position: fixed;
		right: 20rpx;
		z-index: 999;
		.pictrue {
			width: 86rpx;
			height: 86rpx;
			
			border-radius: 50%;

			image {
				width: 100%;
				height: 100%;
			}
		}
	}
</style>
