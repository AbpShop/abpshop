<template>
	<!-- #ifdef H5 -->
	<view class="header" :style="'background: linear-gradient(90deg, '+ bgColor[0].item +' 50%, '+ bgColor[1].item +' 100%);margin-top:'+ mbConfig +'rpx;'">
		<view class="serch-wrapper acea-row row-middle">
			<view class="logo" v-if="tabConfig">
				<image :src="logoConfig" mode=""></image>
			</view>
			<navigator url="/pages/goods_search/index" class="input acea-row row-middle" :class="[boxStyle?'':'fillet',tabConfig?'':'on',txtStyle?'row-center':'']" hover-class="none"><text class="iconfont icon-xiazai5"></text>
				搜索商品</navigator>
		</view>
	</view>
	<!-- #endif -->
	<!-- #ifdef MP -->
	<view>
		<view class="mp-header" :style="'background: linear-gradient(90deg, '+ bgColor[0].item +' 50%, '+ bgColor[1].item +' 100%);margin-top:'+ mbConfig +'rpx;'">
			<view class="sys-head" :style="{ height: statusBarHeight }"></view>
			<view class="serch-box"  style="height: 43px;">
				<view class="serch-wrapper acea-row row-middle">
					<view class="logo" v-if="tabConfig">
						<image :src="logoConfig" mode=""></image>
					</view>
					<navigator url="/pages/goods_search/index" class="input acea-row row-middle" :class="[boxStyle?'':'fillet',tabConfig?'':'on',txtStyle?'row-center':'']" hover-class="none"><text class="iconfont icon-xiazai5"></text>
						搜索商品</navigator>
				</view>
			</view>
		</view>
		<view :style="'margin-top:'+marTop+'px;'"></view>
	</view>
	<!-- #endif -->
</template>

<script>
	let statusBarHeight = uni.getSystemInfoSync().statusBarHeight + 'px';
	export default {
		name: 'headerSerch',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				statusBarHeight: statusBarHeight,
				marTop:0,
				bgColor: this.dataConfig.bgColor.color,
				boxStyle: this.dataConfig.boxStyle.type,
				logoConfig: this.dataConfig.logoConfig.url,
				mbConfig: this.dataConfig.mbConfig.val,
				tabConfig: this.dataConfig.tabConfig.tabVal,
				txtStyle: this.dataConfig.txtStyle.type,
				hotWords: this.dataConfig.hotWords.list
			};
		},
		mounted(){
			let that = this;
			that.$store.commit('hotWords/setHotWord', that.hotWords);
			// #ifdef MP
			this.$nextTick(function(){
				// 获取小程序头部高度
				let info = uni.createSelectorQuery().in(this).select(".mp-header");
				info.boundingClientRect(function(data) {
					that.marTop = data.height
				}).exec()
			})
			// #endif
		},
		methods: {
			
		}
	}
</script>

<style lang="scss">
	/* #ifdef H5 */
	.header {
		width: 100%;
		height: 100rpx;
		background: linear-gradient(90deg, $bg-star 50%, $bg-end 100%);
		.serch-wrapper {
			padding: 20rpx 50rpx 0 53rpx;
			.logo {
				width: 118rpx;
				height: 42rpx;
				margin-right: 30rpx;
				image {
					width: 100%;
					height: 100%;
				}
			}
			.input {
				width: 500rpx;
				height: 58rpx;
				padding: 0 0 0 30rpx;
				background: rgba(247, 247, 247, 1);
				border: 1px solid rgba(241, 241, 241, 1);
				color: #BBBBBB;
				font-size: 28rpx;
				.iconfont {
					margin-right: 20rpx;
				}
				// 没有logo，直接搜索框
				&.on{
					width: 100%;
				}
				// 设置圆角
				&.fillet{
					border-radius: 29rpx;
				}
				// 文本框文字居中
				&.row-center{
					padding: 0;
				}
			}
		}
	}
	/* #endif */
	/* #ifdef MP */
	.mp-header {
		z-index: 999;
		position: fixed;
		left: 0;
		top: 0;
		width: 100%;
		background: linear-gradient(90deg, $bg-star 50%, $bg-end 100%);
	
		.serch-wrapper {
			height: 100%;
			padding: 0 50rpx 0 53rpx;
			
			.logo {
				width: 118rpx;
				height: 42rpx;
				margin-right: 30rpx;
				image {
					width: 100%;
					height: 100%;
				}
			}
	
			.input {
				width: 305rpx;
				height: 50rpx;
				padding: 0 0 0 30rpx;
				background: rgba(247, 247, 247, 1);
				border: 1px solid rgba(241, 241, 241, 1);
				color: #BBBBBB;
				font-size: 28rpx;
	
				.iconfont {
					margin-right: 20rpx;
				}
				// 没有logo，直接搜索框
				&.on{
					width: 70%;
				}
				// 设置圆角
				&.fillet{
					border-radius: 29rpx;
				}
				// 文本框文字居中
				&.row-center{
					padding: 0;
				}
			}
		}
	}
	/* #endif */
</style>
