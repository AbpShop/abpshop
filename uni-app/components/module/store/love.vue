<template>
	<view class="box-shadow bdr16 bg-w ">
		<navigator url="/pages/shop/index">
			<view class="pd30  flex">
				<view class="wh80">
					<image class="wh80 bdr8" mode="aspectFill" :src="statics.product02"></image>
				</view>
				<view class="ws80 pl30">

					<view class="ft16 ftw600">蚝运来·竹笼生蚝海鲜小屋</view>

					<view class="flex space alcenter mt30">
						<unio2o-star-mini></unio2o-star-mini>
						<view class="ft14">
							<text class="text-notice">距我</text>
							<text class="text-theme">1.2km</text>
						</view>
					</view>

					<view class="flex alcenter mt30">
						<view class="store-cat">美食</view>
						<view class="store-tuan ml10">抢</view>
						<view class="store-coupon ml10">券</view>
						<view class="store-buy ml10">买</view>
					</view>

				</view>

			</view>
		</navigator>
		<view class="line"></view>
		<view class="flex">
			<view class="col2 pt20 pb30 text-center">
				<text class="ft16 text-info ftw600">取消收藏</text>
			</view>
			<view class="col2  bdlt pt20 pb30 text-center">
				<text class="ft16 text-theme ftw600">分享好友</text>
			</view>
		</view>
	</view>
</template>

<script>
	import unio2oStarMini from '@/components/base/star/mini.vue';
	export default {
		components: {
			unio2oStarMini
		},
		data() {
			return {

			}
		}
	}
</script>

<style>
	.store-cat,
	.store-tuan,
	.store-coupon,
	.store-buy {
		padding: 4rpx 8rpx;
		border: 2rpx solid #CCCCCC;
		color: #999999;
		font-size: 24rpx;
		border-radius: 4rpx;
	}

	.store-tuan {
		color: #FF9B20;
		border-color: #FF9B20;
	}

	.store-coupon {
		color: #FF6D00;
		border-color: #FF6D00;
	}

	.store-buy {
		color: #8BCB44;
		border-color: #8BCB44;
	}
</style>
