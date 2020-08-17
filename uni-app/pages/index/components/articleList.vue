<template>
	<view class="articleList" :style="'background-color:'+bgColor+';margin-top:'+ mbConfig +'rpx;'" v-if="articleList.length">
		<view v-if="listStyle">
			<navigator :url='"/pages/news_details/index?id="+item.id' hover-class='none' class="item acea-row row-between-wrapper"
			 :style="'margin-bottom:'+itemConfig+'rpx;'" v-for="(item,index) in articleList" :key='index'>
				<view class="pictrue">
					<image :src="item.image_input[0]"></image>
				</view>
				<view class="text">
					<view class="name line2">{{item.title}}</view>
					<view class="time">{{item.add_time}}</view>
				</view>
			</navigator>
		</view>
		<view v-else>
			<navigator :url='"/pages/news_details/index?id="+item.id' hover-class='none' class="item acea-row row-between-wrapper"
			 :style="'margin-bottom:'+itemConfig+'rpx;'" v-for="(item,index) in articleList" :key='index'>
				<view class="text">
					<view class="name line2">{{item.title}}</view>
					<view class="time">{{item.add_time}}</view>
				</view>
				<view class="pictrue">
					<image :src="item.image_input[0]"></image>
				</view>
			</navigator>
		</view>
	</view>
</template>

<script>
	import {
		getArticleList
	} from '@/api/api.js';
	export default {
		name: 'articleList',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				articleList: [],
				numConfig: this.dataConfig.numConfig.val,
				selectConfig: this.dataConfig.selectConfig.activeValue,
				listStyle: this.dataConfig.listStyle.type,
				bgColor: this.dataConfig.bgColor.color[0].item,
				itemConfig: this.dataConfig.itemConfig.val,
				mbConfig: this.dataConfig.mbConfig.val
			}
		},
		created() {},
		mounted() {
			this.getCidArticle();
		},
		methods: {
			getCidArticle: function() {
				let that = this;
				let limit = this.$config.LIMIT;
				getArticleList(that.selectConfig || 0, {
					page: 1,
					limit: this.numConfig >= limit ? limit : this.numConfig
				}).then(res => {
					that.articleList = res.data;
				});
			},
		}
	}
</script>

<style lang="scss">
	.articleList {
		padding: 30rpx 20rpx;
		background-color: #fff;
		margin-top: 20rpx;

		.item {
			margin-bottom: 30rpx;

			.text {
				width: 420rpx;

				.name {
					font-size: 30rpx;
					color: #282828;
					height: 82rpx;
				}

				.time {
					font-size: 24rpx;
					color: #999;
					margin-top: 40rpx;
				}
			}

			.pictrue {
				width: 250rpx;
				height: 156rpx;
				border-radius: 6rpx;

				image {
					width: 100%;
					height: 100%;
					border-radius: 6rpx;
				}
			}
		}
	}
</style>
