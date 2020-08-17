<template>
	<view class="index-product-wrapper" :style="{marginTop:mbConfig+'rpx',background:themeColor}" v-if="tempArr.length">
		<!-- 单列 -->
		<block v-if="itemStyle == 0">
			<view class="list-box animated listA" :class='tempArr.length > 0?"fadeIn on":""'>
				<view class="item" v-for="(item,index) in tempArr" :key="index" @click="goDetail(item)">
					<view class="pictrue">
						<span class="pictrue_log pictrue_log_class" v-if="item.activity && item.activity.type === '1'">秒杀</span>
						<span class="pictrue_log pictrue_log_class" v-if="item.activity && item.activity.type === '2'">砍价</span>
						<span class="pictrue_log pictrue_log_class" v-if="item.activity && item.activity.type === '3'">拼团</span>
						<image :src="item.image" mode=""></image>
					</view>
					<view class="text-info" style="display: flex; flex-direction: column; justify-content: space-between;">
						<div>
							<view class="title line2">{{item.store_name}}</view>
							<view class="old-price"><text>¥</text>{{item.ot_price}}</view>
						</div>
						<view class="price">
							<text>￥</text>{{item.price}}
							<view class="txt" v-if="item.checkCoupon">券</view>
						</view>
					</view>
				</view>
			</view>
		</block>
		<!-- 两列 -->
		<block v-if="itemStyle == 1">
			<view class="list-box animated" :class='tempArr.length > 0?"fadeIn on":""'>
				<view class="item" v-for="(item,index) in tempArr" :key="index" @click="goDetail(item)">
					<view class="pictrue">
						<span class="pictrue_log pictrue_log_class" v-if="item.activity && item.activity.type === '1'">秒杀</span>
						<span class="pictrue_log pictrue_log_class" v-if="item.activity && item.activity.type === '2'">砍价</span>
						<span class="pictrue_log pictrue_log_class" v-if="item.activity && item.activity.type === '3'">拼团</span>
						<image :src="item.image" mode=""></image>
					</view>
					<view class="text-info">
						<view class="title line1">{{item.store_name}}</view>
						<view class="old-price"><text>¥</text>{{item.ot_price}}</view>
						<view class="price">
							<text>￥</text>{{item.price}}
							<view class="txt" :style="'border-color:'+themeColor+';'" v-if="item.checkCoupon">券</view>
						</view>
					</view>
				</view>
			</view>
		</block>
		<!-- 单列 -->
		<block v-if="itemStyle == 2">
			<view class="list-box animated listB" :class='tempArr.length > 0?"fadeIn on":""'>
				<view class="item" v-for="(item,index) in tempArr" :key="index" @click="goDetail(item)">
					<view class="pictrue">
						<span class="pictrue_log pictrue_log_class" v-if="item.activity && item.activity.type === '1'">秒杀</span>
						<span class="pictrue_log pictrue_log_class" v-if="item.activity && item.activity.type === '2'">砍价</span>
						<span class="pictrue_log pictrue_log_class" v-if="item.activity && item.activity.type === '3'">拼团</span>
						<image :src="item.image" mode=""></image>
					</view>
					<view class="text-info" style="display: flex; flex-direction: column; justify-content: space-between;">
						<div>
							<view class="title line1">{{item.store_name}}</view>
							<view class="old-price"><text>¥</text>{{item.ot_price}}</view>
						</div>
						<view class="price">
							<text>￥</text>{{item.price}}
							<view class="txt" v-if="item.checkCoupon">券</view>
						</view>
					</view>
				</view>
			</view>
		</block>
	</view>
</template>

<script>
	import {
		getProductslist
	} from '@/api/store.js';
	export default {
		name: 'goodList',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				tempArr: [],
				// imgStyle:this.dataConfig.imgStyle.type,
				mbConfig:this.dataConfig.mbConfig.val,
				numConfig:this.dataConfig.numConfig.val>10?10:this.dataConfig.numConfig.val,
				themeColor:this.dataConfig.themeColor.color[0].item,
				itemStyle:this.dataConfig.itemStyle.type,
				sortType:this.dataConfig.goodsSort.type
			};
		},
		created() {
			console.log(this.dataConfig,'this.dataConfi')
		},
		mounted(){
			this.productslist();
		},
		methods: {
			productslist(){
				let limit = this.$config.LIMIT;
				getProductslist({page:1,limit:this.numConfig>=limit?limit:this.numConfig,priceOrder:this.sortType == 2?'desc':'',salesOrder:this.sortType == 1?'desc':''}).then(res=>{
					this.tempArr = res.data;
				})
			},
			goDetail(item){
				this.$emit('detail',item);
			}
		}
	}
</script>

<style lang="scss">
	.index-product-wrapper {
		margin: 30rpx 20rpx 0 20rpx;
	
		.list-box {
			display: flex;
			flex-wrap: wrap;
			justify-content: space-between;
	
			.item {
				width: 345rpx;
				margin-bottom: 20rpx;
				background-color: #fff;
				border-radius: 20rpx;
				overflow: hidden;
				position: relative;
				&.on{
					border-radius: 0;
				}
				
				.pictrue_log{
					width: 92rpx;
					height: 44rpx;
					font-size: 26rpx;
					line-height: 44rpx;
				}
	
				image {
					width: 100%;
					height: 346rpx;
					display: block;
				}
	
				.text-info {
					padding: 10rpx 20rpx 15rpx;
	
					.title {
						color: #222222;
					}
	
					.old-price {
						margin-top: 4rpx;
						font-size: 26rpx;
						color: #AAAAAA;
						text-decoration: line-through;
	
						text {
							margin-right: 2px;
							font-size: 20rpx;
						}
					}
	
					.price {
						display: flex;
						align-items: flex-end;
						color: $theme-color;
						font-size: 36rpx;
						font-weight: 550;
	
						text {
							padding-bottom: 4rpx;
							font-size: 26rpx;
							font-weight: normal;
						}
	
						.txt {
							display: flex;
							align-items: center;
							justify-content: center;
							width: 28rpx;
							height: 28rpx;
							margin-left: 15rpx;
							margin-bottom: 10rpx;
							border: 1px solid $theme-color;
							border-radius: 4rpx;
							font-size: 20rpx;
							font-weight: normal;
						}
					}
				}
			}
	
			&.on {
				display: flex;
			}
			&.listA{
				.item{
					display: flex;
					width: 100%;
					.pictrue{
						width: 220rpx;
						height: 220rpx;
					}
					.text-info{
						   width: 490rpx;
					}	
				}
			}
			&.listB{
				justify-content: inherit;
				.item{
					width: 220rpx;
					margin-right: 16rpx;
					image{
						height: 220rpx;
					}
				}
				&:nth-child(3n){
					margin-right: 0;
				}
			}
		}
	}
</style>
