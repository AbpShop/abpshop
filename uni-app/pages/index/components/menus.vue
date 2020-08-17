<template>
	<view class='nav acea-row acea-row' :style="'margin-top:' +mbConfig+'rpx;'" v-if="menus.length">
		<block v-for="(item,index) in menus" :key="index">
			<!-- <navigator class='item' v-if="item.show == '1'" :url='item.url' open-type='switchTab' hover-class='none'>
				<view class='pictrue'>
					<image src='../../../static/images/barg002.png'></image>
				</view>
				<view class="menu-txt">{{item.name}}</view>
			</navigator> -->
			<view class='item' :style="'width:'+ rowStyle +';color:'+titleColor" :url='item.info[1].value' @click="menusTap(item.info[1].value)">
				<view class='pictrue'>
					<image :src='item.img'></image>
				</view>
				<view class="menu-txt">{{item.info[0].value}}</view>
			</view>
		</block>
	</view>
</template>

<script>
	export default {
		name: 'menus',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				menus: this.dataConfig.menuConfig.list,
				rowStyle: this.dataConfig.rowStyle.type ? '20%' : '25%',
				titleColor: this.dataConfig.titleColor.color[0].item,
				mbConfig: this.dataConfig.mbConfig.val
			};
		},
		created() {},
		mounted() {},
		methods: {
			menusTap(url) {
				let urlList = [
					'/pages/order_addcart/order_addcart',
					'/pages/index/index',
					'/pages/goods_cate/goods_cate',
					'/pages/user/index'
				];
				if(urlList.includes(url))
				    uni.switchTab({
				    	url: url
				    })
				else
				    uni.navigateTo({
				    	url: url
				    });
			}
		}
	}
</script>

<style lang="scss">
	.nav {
		.item {
			margin-top: 30rpx;
			width: 20%;
			text-align: center;
			font-size: 24rpx;

			.pictrue {
				width: 82rpx;
				height: 82rpx;
				margin: 0 auto;

				image {
					width: 100%;
					height: 100%;
					border-radius: 50%;
				}
			}

			.menu-txt {
				margin-top: 15rpx;
			}

			&.four {
				width: 25%;

				.pictrue {
					width: 90rpx;
					height: 90rpx;
				}
			}
		}
	}
</style>
