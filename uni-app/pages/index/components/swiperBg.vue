<template>
	<view class="swiperBg" :style="'margin-top:' + marginTop +'rpx;'">
		<!-- 单图模式 -->
		<block v-if="swiperType == 0">
			<view class="item-img" v-for="(item,index) in imgUrls" :key="index" :style="{padding:'0 '+paddinglr+'rpx',marginBottom:itemEdge+'rpx'}"><image :src="item.img" :style="'height:'+ (imageH+10) +'rpx;'"></image></view>
		</block>
		<block v-else>
			<view class="colorBg" :style="'background: linear-gradient(90deg, '+ bgColor[0].item +' 50%, '+ bgColor[1].item +' 100%);'" v-if="swiperType == 2"></view>
			<view class="swiper" :class="[docConfig?'square':'circular',imgConfig?'':'fillet']" :style="'padding: 0 '+ paddinglr +'rpx;'"
			 v-if="imgUrls.length">
				<swiper :style="'height:'+ (imageH+10) +'rpx;'" indicator-dots="true" :autoplay="true" :circular="circular"
				 :interval="interval" :duration="duration" indicator-color="rgba(255,255,255,0.6)" indicator-active-color="#fff">
					<block v-for="(item,index) in imgUrls" :key="index">
						<swiper-item>
							<view @click="goDetail(item)" class='slide-navigator acea-row row-between-wrapper'>
								<image :src="item.img" class="slide-image aa" mode="widthFix"></image>
							</view>
						</swiper-item>
					</block>
				</swiper>
			</view>
		</block>
	</view>
</template>

<script>
	export default {
		name: 'swiperBg',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				indicatorDots: false,
				circular: true,
				autoplay: true,
				interval: 3000,
				duration: 500,
				imgUrls: [], //图片轮播数据
				bgColor: this.dataConfig.bgColor.color, //轮播背景颜色
				marginTop: this.dataConfig.mbConfig.val, //组件上边距
				paddinglr: this.dataConfig.lrConfig.val, //轮播左右边距
				docConfig: this.dataConfig.docConfig.type, //指示点样式
				imgConfig: this.dataConfig.imgConfig.type, //是否为圆角
				imageH: 0,
				swiperType: this.dataConfig.tabConfig.tabVal,
				itemEdge:this.dataConfig.itemEdge.val
			};
		},
		watch: {
			imageH(nVal, oVal) {
				let self = this
				this.imageH = nVal
			}
		},
		created() {
			console.log(this.dataConfig)
			this.imgUrls = this.dataConfig.swiperConfig.list
		},
		mounted() {
			let that = this;
			this.$nextTick(function() {
				uni.getImageInfo({
					src: that.setDomain(that.imgUrls[0].img),
					success: function(res) {
						that.$set(that, 'imageH', res.height);
					},
					fail: function(error) {
						console.log(error, 'error')
					}
				})
			})
		},
		methods: {
			//替换安全域名
			setDomain: function(url) {
				url = url ? url.toString() : '';
				//本地调试打开,生产请注销
				if (url.indexOf("https://") > -1) return url;
				else return url.replace('http://', 'https://');
			},
			goDetail(url){
				let urls = url.info[1].value
				if(urls.indexOf("http") != -1){
					// #ifdef H5
					location.href = urls
					// #endif
				}else{
					if(['/pages/goods_cate/goods_cate','/pages/order_addcart/order_addcart','/pages/user/index'].indexOf(urls) == -1){
						uni.navigateTo({
							url:urls
						})
					}else{
						uni.switchTab({
							url:urls
						})
					}
				}
			}
		}
	}
</script>

<style lang="scss">
	.swiperBg {
		position: relative;
		.colorBg {
			position: absolute;
			left: 0;
			top: 0;
			height: 130rpx;
			width: 100%;
		}

		.swiper {
			z-index: 20;
			position: relative;
			// margin: -130rpx auto 0 auto;
			overflow: hidden;
			// image {
			//   width: 100%;
			//   height: auto;
			//   display: block;
			// }

			/* 设置圆角 */
			&.fillet {
				border-radius: 10rpx;

				image {
					border-radius: 10rpx;
				}
			}

			swiper,
			.swiper-item,
			image {
				width: 100%;
				display: block;
			}

			// 圆形指示点
			&.circular {
				/deep/.uni-swiper-dot {
					width: 10rpx !important;
					height: 10rpx !important;
					background: rgba(0, 0, 0, .4) !important
				}

				/deep/.uni-swiper-dot-active {
					background: #fff !important
				}
			}

			// 方形指示点
			&.square {
				/deep/.uni-swiper-dot {
					width: 20rpx !important;
					height: 5rpx !important;
					border-radius: 3rpx;
					background: rgba(0, 0, 0, .4) !important
				}

				/deep/.uni-swiper-dot-active {
					background: #fff !important
				}
			}
		}
	}
	.item-img image{
		display: block;
		width: 100%;
	}
</style>
