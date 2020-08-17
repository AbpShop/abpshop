<template>
	<view v-if="titleConfig">
		<navigator :url="linkConfig" hover-class="none" class='title' :class="[(textPosition==0?'left':textPosition==2?'right':''),(textStyle==1?'italics':textStyle==2?'blod':'')]" :style="'font-size:'+fontSize+'rpx;margin-top:'+mbConfig+'rpx;background-color:'+titleColor+';'">
			<div>{{titleConfig}}</div>
		</navigator>
	</view>
</template>

<script>
	export default {
		name: 'titles',
		props: {
			dataConfig: {
				type: Object,
				default: () => {}
			}
		},
		data() {
			return {
				fontSize:this.dataConfig.fontSize.val,
				linkConfig:this.dataConfig.linkConfig.value,
				mbConfig:this.dataConfig.mbConfig.val,
				textPosition:this.dataConfig.textPosition.type,
				textStyle:this.dataConfig.textStyle.type,
				titleColor:this.dataConfig.titleColor.color[0].item,
				titleConfig:this.dataConfig.titleConfig.value
			};
		},
		created() {},
		methods: {}
	}
</script>

<style lang="scss">
	.title{
		font-size: 40rpx;
		color: #282828;
		text-align: center;
		width: 100%;
		
		&.left{
			text-align: left;
		}
		&.right{
			text-align: right;
		}
		&.blod{
			font-weight: bold;
		}
		&.italics{
			font-style: italic;
		}
	}
	
</style>
