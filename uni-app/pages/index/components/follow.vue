<template>
	<view>
		<!-- #ifdef H5 -->
		<view class="follow acea-row row-between-wrapper" :style="'background:'+ bgColor +';margin-top:'+ mbConfig +'rpx;'">
			<view class="picTxt acea-row row-middle">
				<view class="pictrue">
					<image :src="imgConfig"></image>
				</view>
				<view class="name line1">{{titleConfig}}</view>
			</view>
			<view class="notes acea-row row-center-wrapper" :style="'color:'+ themeColor +';border-color:'+ themeColor +';'" @click="followTap">关注</view>
		</view>
		<view class="followCode" v-if="followCode">
			<view class="pictrue"><img :src="followUrl" /></view>
			<view class="mask" @click="closeFollowCode"></view>
		</view>
		<!-- #endif -->
	</view>
</template>

<script>
	// #ifdef H5
	import {
		follow
	} from '@/api/api.js';
	export default {
		name: 'follow',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				followCode: false,
				followUrl:'',
				bgColor:this.dataConfig.bgColor.color[0].item,
				imgConfig:this.dataConfig.imgConfig.url,
				mbConfig:this.dataConfig.mbConfig.val,
				themeColor:this.dataConfig.themeColor.color[0].item,
				titleConfig:this.dataConfig.titleConfig.value
			};
		},
		created() {},
		methods: {
			followTap(){
				this.followCode = true;
				this.getFollow();
			},
			closeFollowCode(){
				this.followCode = false
			},
			getFollow(){
				follow().then(res=>{
					 this.followUrl = res.data.path;
				}).catch(res=>{
					console.log(res.msg);
				})
			}
		}
	}
	// #endif
</script>

<style lang="scss">
	.follow{
		padding: 0 20rpx;
		height: 140rpx;
		background:rgba(0,0,0,0.02);
		.picTxt{
		   .pictrue{
			   width: 92rpx;
			   height: 92rpx;
			   border-radius: 50%;
			   image{
				   width: 100%;
				   height: 100%;
				   border-radius: 50%;
			   }
		   }
		   .name{
			   font-size:32rpx;
			   color: #000;
			   margin-left: 32rpx;
			   width: 400rpx;
		   }
		}
		.notes{
			font-size: 28rpx;
			color: #02A0E8;
			width:120rpx;
			height:52rpx;
			border:2rpx solid rgba(2,160,232,1);
			opacity:1;
			border-radius:6rpx;
		}
	}
	.followCode {
		.pictrue {
			width: 500rpx;
			height: 720rpx;
			border-radius: 12px;
			left: 50%;
			top: 50%;
			margin-left: -250rpx;
			margin-top: -360rpx;
			position: fixed;
			z-index: 10000;
	
			img {
				width: 100%;
				height: 100%;
			}
		},
		.mask{
			z-index: 9999;
		}
	}
</style>
