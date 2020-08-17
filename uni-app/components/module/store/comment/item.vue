<template>
	<view class="flex">
			<view class="comment-face">
				<image :src="statics.memberFace"></image>
			</view>
			<view class="comment-r pl30">
				<view class="flex space alcenter">
					<view>
						<view class="ft14 text-info">A用户昵称</view>
						<view class="ft14 text-notice mt10">2019-11-02</view>
					</view>
					<view class="flex alcenter">
						<unio2o-star-mini></unio2o-star-mini>
						<text class="ml10 ft14 text-theme ftw600">4.0分</text>
					</view>
				</view>
				<view class="mt30 flex alcenter ft14 text-notice">
					<view class="iconfont iconlabel_evaluation"></view>
					<view class="flex alcenter text-over">
						<text class="ml10">服务态度好</text>
						<text class="ml10">店家热情</text>
						<text class="ml10">环境舒适</text>
					</view>
				</view>
				
				<view class="mt20 ft16 text-main">
					第一次去泰国，后面两天骑大象、参拜四面佛、人妖歌舞表演、逛青蛙夜市，整个行程轻松、休闲基本上都可以睡到自然醒，整体来说非常满意，值得推荐！
				</view>
				<view class="mt20 flex  wrap">
					<image @click="showPic" v-for="(item,index) in  commentImg" :key="index" :class=" (index + 1) % 3 == 2 ? 'mr20 ml20' : '' " class="mb20 comment-img" :src="item"></image>
				</view>
				
				<view class="mt20">
					<view class="store-reply pd20">
						<view class="ft14 ftw600 text-main">[商家回复]</view>
						<view class="mt20 ft14 text-info">
							非常感谢您的光临，我们将一如既往地问您提供更好的服务！
						</view>
					</view>
				</view>
			</view>
	</view>
</template>

<script>
	import  unio2oStarMini from '@/components/base/star/mini.vue';
	export default{
		components:{
			unio2oStarMini
		},
		data(){
			return {
				commentImg:[
					this.$config.staticUrl + 'photo/img01@2x.png',
					this.$config.staticUrl + 'photo/img02@2x.png',
					this.$config.staticUrl + 'photo/img03@2x.png',
					this.$config.staticUrl + 'photo/img04@2x.png',
					this.$config.staticUrl + 'photo/img05@2x.png'
				]
			}
		},
		methods:{
			showPic(){
				uni.previewImage({
					urls: this.commentImg
				});
			}
		}
	}
</script>

<style>
	.store-reply{
		width: 100%;
		border:2rpx solid #E6E6E6;
	}
	.comment-img{
		width: 180rpx;
		height: 180rpx;
	}
	.comment-face{
		width: 76rpx;
		height: 76rpx;
	}
	.comment-face image{
		width: 76rpx;
		height: 76rpx;
	}
	.comment-r{
		width:calc(100% - 76rpx);
	}
</style>
