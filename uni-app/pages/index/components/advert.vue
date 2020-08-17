<template name='even'>
	<view class="advert">
		<image src="../../../static/images/barg002.png"></image>
	</view>
</template>

<script>
	export default {
		name: 'advert',
		props: {},
		data() {
			return {
			};
		},
		created() {},
		methods: {}
	}
</script>

<style lang="scss">
	.advert{
		margin: 20rpx 20rpx 0 20rpx;
		box-sizing: border-box;
		image{
			width: 100%;
			box-sizing: border-box;
			display: block;
		}
	}
</style>
