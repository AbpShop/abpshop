<template>
	<view class="barg" :style="'background: linear-gradient(180deg, '+ bgColor[0].item +' 0%, '+ bgColor[1].item +' 100%);margin-top:' + mbCongfig +'rpx;'" v-if="bargList.length>0">
		<view class="title" :style="'color:'+titleColor+';'">
			砍价专区·BARGAINING
			<!-- <image src="/static/images/barg001.png" mode=""></image> -->
		</view>
		<view class="barg-swiper">
			<scroll-view scroll-x="true" style="white-space: nowrap; display: flex" show-scrollbar="true">
				<view class="wrapper">
					<block v-for="(item,index) in bargList" :key="index">
						<view class='list-box' :style="'margin-right:'+productGap+'rpx;'" @click="bargDetail(item)">
							<image :src="item.image" class="slide-image"></image>
							<view class="info-txt">
								<view class="price" :style="'color:'+themeColor+';'"><text>￥</text>{{item.price}}</view>
								<view class="txt" :style="'background-color:'+ themeColor +';'">立即砍价</view>
							</view>
						</view>
					</block>
					<navigator url="/pages/activity/goods_bargain/index" class="more-box" hover-class="none">
						<view class="txt">查看更多</view>
						<image src="/static/images/mores.png"></image>
					</navigator>
				</view>
			</scroll-view>
		</view>
	</view>
</template>

<script>
	import {
		getBargainList
	} from '@/api/activity.js';
	export default {
		name: 'bargain',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				bargList: [],
				numConfig: this.dataConfig.numConfig.val,//显示砍价列表数量
				themeColor: this.dataConfig.themeColor.color[0].item,//主题颜色
				titleColor: this.dataConfig.titleColor.color[0].item,//标题颜色
				bgColor: this.dataConfig.bgColor.color,//背景颜色
				mbCongfig: this.dataConfig.mbCongfig.val,
				productGap: this.dataConfig.productGap.val
			};
		},
		created() {},
		mounted() {
			this.getBargainList();
		},
		methods: {
			// 砍价列表
			getBargainList() {
				let limit = this.$config.LIMIT;
				getBargainList({
					page: 1,
					limit: this.numConfig>=limit?limit:this.numConfig
				}).then(res => {
					this.bargList = res.data
				})
			},
			bargDetail(item){
			    this.$emit('changeBarg', item);
			}
		}
	}
</script>

<style lang="scss">
	.barg {
		height: 478rpx;
		margin: 20rpx 20rpx 0 20rpx;
		padding-left: 20rpx;
		background:linear-gradient(180deg,rgba(253,219,178,1) 0%,rgba(253,239,198,1) 100%);
		background-size: 100% 100%;
		box-sizing: border-box;
		border-radius:24rpx;
		
		.title {
			display: flex;
			align-items: center;
			justify-content: center;
			padding-top: 42rpx;
			font-size: 38rpx;
			color: #FF6000;
			font-weight: bold;
	
			image {
				width: 463rpx;
				height: 39rpx;
			}
		}
	
		.barg-swiper {
			margin-top: 43rpx;
			padding-right: 20rpx;
	
			.wrapper {
				display: flex;
			}
	
			.list-box {
				flex-shrink: 0;
				width: 210rpx;
				background-color: #fff;
				border-radius: 16rpx;
				overflow: hidden;
				padding-bottom: 18rpx;
				margin-right: 20rpx;
	
				image {
					width: 100%;
					height: 210rpx;
				}
	
				.info-txt {
					width: 100%;
					display: flex;
					flex-direction: column;
					align-items: center;
					justify-content: center;
					padding-top: 4rpx;
	
					.price {
						font-weight: 700;
						color: $theme-color;
						font-size: 28rpx;
						text{
							font-size: 18rpx;
						}
					}
	
					.txt {
						display: flex;
						align-items: center;
						justify-content: center;
						width: 136rpx;
						height: 33rpx;
						margin-top: 10rpx;
						background: linear-gradient(90deg, $bg-star 0%, $bg-end 100%);
						border-radius: 17px;
						font-size: 18rpx;
						color: #fff;
	
					}
				}
			}
	
			.more-box {
				flex-shrink: 0;
				display: flex;
				flex-direction: column;
				align-items: center;
				justify-content: center;
				width: 80rpx;
				background-color: #fff;
				border-radius: 16rpx;
	
				image {
					width: 24rpx;
					height: 24rpx;
					margin-top: 10rpx;
				}
	
				.txt {
					display: block;
					writing-mode: vertical-lr;
					font-size: 26rpx;
					line-height: 1.2;
				}
			}
		}
	}
</style>
