<template>
	<view class='richText' :style="'background-color:'+bgColor+';margin:'+ udConfig +'rpx '+ lrConfig +'rpx;'" v-if="description">
		<!-- <view>大法官好地方规划的法规</view> -->
		<jyf-parser :html="description" ref="article" :tag-style="tagStyle"></jyf-parser>
	</view>
</template>


<script>
	import parser from "@/components/jyf-parser/jyf-parser";
	export default {
		name: 'richText',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		components: {
			"jyf-parser": parser
		},
		data() {
			return {
				tagStyle: {
					img: 'width:100%;'
				},
				bgColor:this.dataConfig.bgColor.color[0].item,
				lrConfig:this.dataConfig.lrConfig.val,
				description:this.dataConfig.richText.val,
				udConfig:this.dataConfig.udConfig.val
			};
		},
		created() {},
		methods: {
			
		}
	}
</script>

<style lang="scss">
	.richText{
		padding: 20rpx;
		background-color: #fff;
		margin: 0 20rpx;
		border-radius: 24rpx;
	}
</style>
