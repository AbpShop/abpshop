<template>
	<view class="box-shadow bdr16 bg-w pd30  flex">
		
		<view class="wh80">
			<navigator url="/pages/shop/index">
			<image class="wh80 bdr8" mode="aspectFill" :src="statics.product02"></image>
			</navigator>
		</view>
		<view class="ws80 pl30">
			<navigator url="/pages/shop/index">
			<view class="ft16 ftw600">蚝运来·竹笼生蚝海鲜小屋</view>
			
			<view class="flex space alcenter mt30">
				<unio2o-star-mini></unio2o-star-mini>
				<view class="ft14">
					<text class="text-notice">距我</text>
					<text class="text-theme">1.2km</text>
				</view>
			</view>
			</navigator>
			<view class="flex alcenter mt30">
				<view class="store-cat">美食</view>
				<view class="store-tuan ml10">抢</view>
				<view class="store-coupon ml10">券</view>
				<view class="store-buy ml10">买</view>
			</view>
			<view class="line mt30 mb30"></view>
			<view class="flex alcenter">
				<view class="store-tag-tuan">抢</view>
				<view class="product-title text-over">6.9元特惠6.9元餐，9.9元休9元餐，9.9元休</view>
			</view>
			<view class="flex alcenter mt20">
				<view class="store-tag-coupon">券</view>
				<view class="product-title text-over">满30减5元优惠券，满50减8…</view>
			</view>
			<view class="flex alcenter mt20">
				<view class="store-tag-buy">买</view>
				<view class="product-title text-over">买单最高可减100元</view>
			</view>
		</view>
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
	
	.store-tag-tuan,.store-tag-coupon,.store-tag-buy{
		width: 40rpx;
		height: 40rpx;
		text-align: center;
		line-height: 40rpx;
		border-radius:20rpx 20rpx 0rpx 20rpx;
		color:#FFFFFF;
		font-size: 24rpx;
		background: #FF9B20;
	}
	.store-tag-coupon{
		background: #FF6D00;
	}
	.store-tag-buy{
		background: #8BCB44;
	}
	
	.product-title{
		width:  calc(100% - 40rpx);
		padding-left: 20rpx;
		font-size: 28rpx;
		color:#333333;
	}
	.store-cat,.store-tuan,.store-coupon,.store-buy{
		padding: 4rpx 8rpx;
		border:2rpx solid #CCCCCC;
		color:#999999;
		font-size: 24rpx;
		border-radius: 4rpx;
	}
	.store-tuan{
		color:#FF9B20;
		border-color:#FF9B20;
	}
	.store-coupon{
		color:#FF6D00;
		border-color: #FF6D00;
	}
	.store-buy{
		color:#8BCB44;
		border-color:#8BCB44;
	}
</style>