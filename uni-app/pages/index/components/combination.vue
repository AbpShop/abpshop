<template>
	<view class="group-wrapper" :style="'margin-top:'+ mbConfig +'rpx;'" v-if="combinationList.length>0">
		<view class="hd">
			<view class="left">
				<image src="/static/images/group02.gif" class="icon"></image>
				<view class="name">拼团活动</view>
				<!-- <image src="/static/images/group01.png" class="title"></image> -->
				<view class="person">
					<view class="avatar-box">
						<block v-for="item in pinkInfo.avatars">
							<image :src="item" mode=""></image>
						</block>
					</view>
					<view class="num" v-if="pinkInfo.pink_count>0">{{pinkInfo.pink_count}}人拼团成功</view>
				</view>
			</view>
			<navigator class="more" url="/pages/activity/goods_combination/index" hover-class="none">更多 <text class="iconfont icon-jiantou"></text></navigator>
		</view>
		<view class="group-scroll">
			<scroll-view scroll-x="true" style="white-space: nowrap; display: flex" show-scrollbar="false">
				<navigator class="group-item" :style="'margin-right:'+ lrConfig +'rpx;'" v-for="(item,index) in combinationList" :key="index"
				 :url="'/pages/activity/goods_combination_details/index?id='+item.id" hover-class="none">
					<image :src="item.image" mode=""></image>
					<view class="people">{{item.people}}人参团</view>
					<view class="info">
						<view class="name line1">{{item.title}}</view>
						<view class="price-box">
							<text class="tips" :style="'background-color:'+txtColor+';color:'+themeColor+';'">拼团价</text>
							<text class="price" :style="'color:'+themeColor+';'"><text>￥</text>{{item.price}}</text>
						</view>
					</view>
					<view class="bom-btn" :style="'background-color:'+themeColor+';'">参与拼团</view>
				</navigator>
			</scroll-view>
		</view>
	</view>
</template>

<script>
	import {
		pink
	} from '@/api/api.js';
	import {
		getCombinationList
	} from '@/api/activity.js';
	export default {
		name: 'combination',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				pinkInfo: '',
				combinationList: [],
				numConfig:this.dataConfig.numConfig.val,
				txtColor:this.dataConfig.txtColor.color[0].item,
				themeColor:this.dataConfig.themeColor.color[0].item,
				mbConfig:this.dataConfig.mbConfig.val,
				lrConfig:this.dataConfig.lrConfig.val
			};
		},
		created() {},
		mounted() {
			this.pink();
			this.getCombinationList();
		},
		methods: {
			// 拼团列表
			getCombinationList: function() {
				let that = this;
				let limit = that.$config.LIMIT;
				let data = {
					page: 1,
					limit: that.numConfig>=limit?limit:that.numConfig
				};
				getCombinationList(data).then(function(res) {
					that.combinationList = res.data;
				}).catch((res) => {
					return that.$util.Tips({
						title: res
					});
				})
			},
			// 拼团数据（拼团人数头部图片）
			pink: function() {
				pink().then(res => {
					this.pinkInfo = res.data
				})
			}
		}
	}
</script>

<style lang="scss">
	.group-wrapper {
		padding: 26rpx 20rpx;
		background: #fff;
		border-radius: 24rpx;
		margin: 20rpx 20rpx 0 20rpx;

		.hd {
			display: flex;
			align-items: center;
			justify-content: space-between;

			.left {
				display: flex;
				align-items: center;
				.name{
					font-size: 32rpx;
					font-weight: 600;
				}

				.icon {
					width: 36rpx;
					height: 36rpx;
					margin-right: 12rpx;
				}

				.title {
					width: 134rpx;
					height: 33rpx;
				}

				.person {
					display: flex;
					align-items: center;
					margin-left: 40rpx;

					.avatar-box {
						display: flex;
						align-items: center;

						image {
							width: 30rpx;
							height: 30rpx;
							border-radius: 50%;
							margin-right: -10rpx;
						}
					}

					.num {
						margin-left: 18rpx;
						font-size: 26rpx;
						color: #999999;
					}
				}
			}

			.more {
				font-size: 26rpx;
				color: #999;

				.iconfont {
					margin-left: 6rpx;
					font-size: 25rpx;
				}
			}
		}

		.group-scroll {
			width: 100%;
			margin-top: 25rpx;

			.group-item {
				display: inline-block;
				width: 220rpx;
				box-shadow: 0px 2px 6px 2px rgba(0, 0, 0, 0.03);
				border-radius: 16rpx;
				position: relative;

				.people {
					position: absolute;
					width: 140rpx;
					height: 32rpx;
					background: rgba(0, 0, 0, 0.1);
					box-shadow: 2rpx 2rpx 8rpx 0 rgba(0, 0, 0, 0.06);
					border-radius: 16rpx;
					top: 12rpx;
					left: 12rpx;
					font-size: 20rpx;
					color: #fff;
					text-align: center;
					line-height: 32rpx;
				}

				image {
					width: 100%;
					height: 220rpx;
					border-radius: 16rpx 16rpx 0 0;
				}

				.info {
					padding: 2rpx 12rpx 10rpx 12rpx;

					.name {
						font-size: 24rpx;
					}

					.price-box {
						display: flex;
						align-items: center;
						margin-top: 6rpx;

						.tips {
							display: flex;
							align-items: center;
							justify-content: center;
							width: 76rpx;
							height: 30rpx;
							margin-right: 6rpx;
							border-radius: 2px;
							font-size: 18rpx;
						}

						.price {
							font-size: 28rpx;
							font-weight: 700;

							text {
								font-size: 18rpx;
							}
						}
					}

				}

				.bom-btn {
					display: flex;
					align-items: center;
					justify-content: center;
					width: 100%;
					height: 48rpx;
					border-radius: 0px 0px 16rpx 16rpx;
					color: #fff;
					font-size: 24rpx;

				}
			}
		}
	}
</style>
