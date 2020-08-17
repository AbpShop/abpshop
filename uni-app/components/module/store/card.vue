<template>
	<view :class="full ? 'bdr16 box-shadow over-hidden bg-w' : '' ">
		<view class="flex space alcenter pd30 bg-w">
			<view class="flex alcenter">
				<image class="store-card-logo box-shadow" :src="statics.storeLogo01"></image>
				<view class="pl20">
					<view class="ft16 ftw600 text-main">华莱士</view>
					<view class="mt10">
						<unio2o-star-mini></unio2o-star-mini>
					</view>
				</view>
			</view>
			<navigator url="/pages/shop/index">
				<view class="btn-look flex center alcenter ft14 ftw600 text-w">
					进店逛逛
				</view>
			</navigator>
		</view>
		<view v-if="full == true" class="line"></view>
		<view v-if="full == true"  class="flex ">
			<view class="flex center alcenter text-info col2  pt30 pb30">
				<text class="iconfont iconbtn_bottom_call ft22 text-default"></text>
				<text class="ft16 ml20">联系商家</text>
			</view>
			<view class="flex center alcenter col2 bdlt  pt30 pb30">
				<text class="iconfont iconbtn_bottom_location ft22 text-default"></text>
				<text class="ft16 ml20">导航到店</text>
			</view>
		</view>
	</view>
</template>

<script>
	import unio2oStarMini from '@/components/base/star/mini.vue';
	export default{
		props:{
			full:{
				type: Boolean,
				default:false
			}
		},
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