<template>
	<view class="flex center alcenter">
		<text @touchstart="selectAct"  v-for="(item,index) in  stars" :key="index" 
		:data-num="item" :class="(item <= mynum ? 'text-yellow' :'text-placeholder') + (item > 1 ? ' ml50' :'') "
		 class="iconfont iconbtn_star_c ft32"></text>
	</view>
</template>

<script>
	export default{
		props:{
			num:{
				type:Number,
				default:0
			}
		},
		created(){
			this.mynum = this.num;
		},
		data(){
			return {
				mynum:0,
				stars:[1,2,3,4,5]
			}
		},methods:{
			selectAct(e){
				this.mynum = parseInt(e.currentTarget.dataset.num);
			}
		}
	}
</script>

<style>
	
</style>