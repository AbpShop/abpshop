<template>
	<view class="flex alcenter ">
		<text v-for="(item,index)  in stars" :key="index" :class="item <= num ? 'star-on' : 'text-notice'" class="iconfont iconbtn_star_c scale6"></text>
	</view>
</template>

<script>
	export default{
		props:{
			num:{
				type:Number,
				default:4,
			}
		},
		data(){
			return {
				stars:[1,2,3,4,5]
			}
		}
	}
</script>

<style>
	.star-on{
		color:#FFB70E
	}
</style>