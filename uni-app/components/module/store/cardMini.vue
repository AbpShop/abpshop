<template>
	<view class="flex space alcenter pd30 bg-default">
			<view class="flex alcenter">
				<image class="store-card-logo" :src="statics.storeLogo01"></image>
				<view class="pl20">
					<view class="ft16 ftw600 text-main">华莱士</view>
					<view class="mt10">
						<unio2o-star-mini></unio2o-star-mini>
					</view>
				</view>
			</view>
			<view class="iconfont iconbtn_arrowr text-info"></view>
	</view>
</template>

<script>
	import unio2oStarMini from '@/components/base/star/mini.vue';
	export default{
		components:{
			unio2oStarMini
		},
		data(){
			return {
				
			}
		}
	}
</script>

<style>
	.btn-look{
		width:160rpx;
		height:64rpx;
		background:#FF6D00;
		box-shadow:0rpx 8rpx 16rpx 0rpx rgba(255,109,0,0.3);
		border-radius:32rpx;
	}
	.store-card-logo{
		width: 100rpx;
		height: 100rpx;
		border-radius: 8rpx;
	}
</style>