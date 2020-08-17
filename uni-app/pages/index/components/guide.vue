<template>
	<view class="lines" :style="'padding:0 '+ lrEdge +'rpx;margin-top:'+ mbConfig +'rpx;'" v-if="heightConfig">
		<view class="item" :style="'border-bottom-width:'+ heightConfig +'rpx;border-bottom-color:'+ lineColor +';border-bottom-style:'+ lineStyle +';'"></view>
	</view>
</template>

<script>
	export default {
		name: 'guide',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				heightConfig:this.dataConfig.heightConfig.val,
				lineColor:this.dataConfig.lineColor.color[0].item,
				lineStyle:this.dataConfig.lineStyle.type,
				lrEdge:this.dataConfig.lrEdge.val,
				mbConfig:this.dataConfig.mbConfig.val
			};
		},
		created() {},
		methods: {
			
		}
	}
</script>

<style lang="scss">
	.lines{
		padding: 0 20rpx;
		margin-top: 20rpx;
		.item{
			width: 100%;
			box-sizing: border-box;
			border-bottom-color: red;
			border-bottom-width: 1px;
			// dashed
			border-bottom-style: dotted;
		}
	}
</style>
