<template>
	<view v-if="show == true" class="unio2o-buy-role-alert">
		<view  @click="closed()" class="bg"></view>
		<view class="alert-div" :class="show ? 'animated fast zoomInUp':''">
			<view class="alert-main pd40 bg-w bdr16">
				<image class="alert-img" :src="statics.buyAlertImg"></image>
				<image @click="closed()" class="closed-img" :src="statics.closeImg"></image>
				<view class="text-center pt40 ft18 ftw600 text-default">优惠买单说明</view>
				<view class="mt40 ft16 text-default">
					<text>
					•	优惠买单仅限到店支付，请勿提前购买；
					
					•	使用优惠需先在商家购买领取买单抵扣券；
					
					•	如需发票，请您在消费时向商家咨询。
					</text>
				</view>
				
			</view>
		</view>
	
	</view>
</template>

<script>
	export default{
		props:{
			show:{
				type:Boolean,
				default:false
			}
		},
		data(){
			return {
				
			}
		},methods:{
			closed(){
				this.$emit('closed',true);
			}
		}
	}
</script>

<style>
	.unio2o-buy-role-alert{
		width: 100%;
		height: 100vh;
		z-index: 400;
		position: fixed;
		left: 0;
		top: 0;
		
	}
	
	.unio2o-buy-role-alert .bg{
		position: fixed;
		width: 100%;
		height: 100vh;
		background: rgba(0,0,0,.3);
		left: 0;
		top: 0;
		z-index: 401;
	}
	
	.unio2o-buy-role-alert .alert-div{
		position: fixed;
		width: 630rpx;
		left: calc(50% - 315rpx);
		top: 50%;
		transform: translateY(-50%);
		z-index: 402;
	}
	.unio2o-buy-role-alert .alert-main{
		position: relative;
		width: 100%;
	}
	.unio2o-buy-role-alert .alert-img{
		position: absolute;
		width: 120rpx;
		height: 120rpx;
		left: calc(50% - 60rpx);
		top: -60rpx;
	}
	.unio2o-buy-role-alert .closed-img{
		position: absolute;
		width: 88rpx;
		height: 88rpx;
		right: -44rpx;
		top: -44rpx;
	}
</style>