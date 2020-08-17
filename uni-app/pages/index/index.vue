<template>
	<view>
		<!-- #ifdef H5 -->
		<view v-for="(item,index) in styleConfig" :key='index'>
			<component :is="item.name" :index="index" :dataConfig="item" @changeBarg="changeBarg" @changeTab='changeTab'
			 :tempArr='tempArr' :iSshowH='iSshowH' @detail='goDetail'></component>
		</view>
		<!-- #endif -->
		<!-- #ifdef MP || APP-PLUS -->
		<block v-for="(item,index) in styleConfig" :key='index'>
			<activeParty v-if='item.name=="activeParty"' :dataConfig="item"></activeParty>
			<articleList v-if='item.name=="articleList"' :dataConfig="item"></articleList>
			<bargain v-if='item.name=="bargain"' :dataConfig="item" @changeBarg="changeBarg"></bargain>
			<blankPage v-if='item.name=="blankPage"' :dataConfig="item"></blankPage>
			<combination v-if='item.name=="combination"' :dataConfig="item"></combination>
			<coupon v-if='item.name=="coupon"' :dataConfig="item"></coupon>
			<customerService v-if='item.name=="customerService"' :dataConfig="item"></customerService>
			<goodList v-if='item.name=="goodList"' :dataConfig="item"  @detail='goDetail'></goodList>
			<guide v-if='item.name=="guide"' :dataConfig="item"></guide>
			<headerSerch v-if='item.name=="headerSerch"' :dataConfig="item"></headerSerch>
			<liveBroadcast v-if='item.name=="liveBroadcast"' :dataConfig="item"></liveBroadcast>
			<menus v-if='item.name=="menus"' :dataConfig="item"></menus>
			<news v-if='item.name=="news"' :dataConfig="item"></news>
			<promotionList v-if='item.name=="promotionList"' :dataConfig="item" @changeTab='changeTab' :tempArr='tempArr' :iSshowH='iSshowH' @detail='goDetail'></promotionList>
			<richText v-if='item.name=="richText"' :dataConfig="item"></richText>
			<seckill v-if='item.name=="seckill"' :dataConfig="item"></seckill>
			<swiperBg v-if='item.name=="swiperBg"' :dataConfig="item"></swiperBg>
			<swipers v-if='item.name=="swipers"' :dataConfig="item"></swipers>
			<tabNav v-if='item.name=="tabNav"' :dataConfig="item"></tabNav>
			<titles v-if='item.name=="titles"' :dataConfig="item"></titles>
		</block>
		<!-- #endif -->
		<view class='loadingicon acea-row row-center-wrapper' v-if="tempArr.length&&styleConfig[styleConfig.length-1].name=='promotionList'">
			<text class='loading iconfont icon-jiazai' :hidden='loading==false'></text>{{loadTitle}}
		</view>
		<!-- #ifdef MP -->
		<authorize @onLoadFun='onLoadFun' :isAuto="isAuto" :isShowAuth="isShowAuth" @authColse="authColse" :isGoIndex="false"></authorize>
		<!-- #endif -->
	</view>
</template>

<script>
	// #ifdef H5
	import mConfig from './components/index.js';
	import {
		getShare,
	} from '@/api/public.js';
	// #endif 
	// #ifdef MP || APP-PLUS
	import authorize from '@/components/Authorize';
	import activeParty from './components/activeParty';
	import headerSerch from './components/headerSerch';
	import swipers from './components/swipers';
	import coupon from './components/coupon';
	import articleList from './components/articleList';
	import bargain from './components/bargain';
	import blankPage from './components/blankPage';
	import combination from './components/combination';
	import customerService from './components/customerService';
	import goodList from './components/goodList';
	import guide from './components/guide';
	import liveBroadcast from './components/liveBroadcast';
	import menus from './components/menus';
	import news from './components/news';
	import promotionList from './components/promotionList';
	import richText from './components/richText';
	import seckill from './components/seckill';
	import swiperBg from './components/swiperBg';
	import tabNav from './components/tabNav';
	import titles from './components/titles';
	
	
	// #endif
	import {
		mapGetters
	} from "vuex";
	import {
		getDiy,
		getIndexData
	} from '@/api/api.js';
	import {
		getGroomList
	} from '@/api/store.js';
	import {
		goShopDetail
	} from '@/libs/order.js';
	import {
		toLogin
	} from '@/libs/login.js';
	export default {
		computed: mapGetters(['isLogin', 'uid']),
		components: {
			// #ifdef H5
			...mConfig,
			// #endif
			// #ifdef MP
			authorize,
			activeParty,
			headerSerch,
			swipers,
			coupon,
			articleList,
			bargain,
			blankPage,
			combination,
			customerService,
			goodList,
			guide,
			liveBroadcast,
			menus,
			news,
			promotionList,
			richText,
			seckill,
			swiperBg,
			tabNav,
			titles
			// #endif
		},
		data() {
			return {
				styleConfig: [],
				tempArr: [],
				goodType: 3,
				loading: false,
				loadend: false,
				loadTitle: '下拉加载更多', //提示语
				page: 1,
				limit: this.$config.LIMIT,
				iSshowH: false,
				numConfig: 0
			}
		},
		onLoad() {
			uni.getLocation({
				type: 'wgs84',
				success: function(res) {
					try {
						uni.setStorageSync('user_latitude', res.latitude);
						uni.setStorageSync('user_longitude', res.longitude);
					} catch {}
				}
			});
			this.diyData();
			this.getIndexData();
			// #ifdef H5
			this.setOpenShare();
			// #endif
		},
		onShow() {},
		mounted() {},
		methods: {
			onLoadFun(){
				
			},
			// 对象转数组
			objToArr(data) {
				let obj = Object.keys(data);
				let m = obj.map(key => data[key]);
				return m
			},
			diyData() {
				let that = this;
				getDiy().then(res => {
					that.styleConfig = that.objToArr(res.data);
					that.objToArr(res.data).forEach((item) => {
						if (item.name == 'promotionList') {
							that.numConfig = item.numConfig.val;
							that.getGroomList();
						}
					})
				})
			},
			getIndexData() {
				// getIndexData().then(res => {
				// 	console.log(res.data);
				// })
			},
			changeBarg(item) {
				if (!this.isLogin) {
					// #ifdef H5 || APP-PLUS
					toLogin();
					// #endif 
					// #ifdef MP
					this.$set(this, 'isAuto', true);
					this.$set(this, 'isShowAuth', true)
					// #endif
				} else {
					uni.navigateTo({
						url: `/pages/activity/goods_bargain_details/index?id=${item.id}&bargain=${this.uid}`
					})
				}
			},
			// 促销列表的点击事件；
			changeTab(type) {
				this.goodType = type;
				this.tempArr = [];
				this.page = 1;
				this.loadend = false;
				let onloadH = true
				this.getGroomList(onloadH)
			},
			// 精品推荐
			getGroomList(onloadH) {
				let that = this
				let type = that.goodType;
				if (that.loadend) return false;
				if (that.loading) return false;
				if (onloadH) {
					that.$set(that, 'iSshowH', true);
				}
				getGroomList(type, {
					page: that.page,
					limit: that.limit
				}).then(({
					data
				}) => {
					that.$set(that, 'iSshowH', false);
					let maxPage = Math.ceil(this.numConfig / this.limit);
					let list = data.list,
						loadend = list.length < that.limit || that.page >= maxPage;
					let tempArr = that.$util.SplitArray(list, that.tempArr);
					that.$set(that, 'tempArr', tempArr.slice(0, this.numConfig));
					that.loadend = loadend;
					that.loadTitle = loadend ? '我也是有底线的' : '下拉加载更多';
					that.page = that.page + 1;
					that.loading = false;
				}).catch(res => {
					that.loading = false;
					that.loadTitle = '下拉加载更多';
				})
			},
			goDetail(item) {
				if (!this.isLogin) {
					// #ifdef H5 || APP-PLUS
					toLogin();
					// #endif 
					// #ifdef MP
					this.$set(this, 'isAuto', true);
					this.$set(this, 'isShowAuth', true)
					// #endif
				} else {
					goShopDetail(item, this.uid).then(res => {
						uni.navigateTo({
							url: `/pages/goods_details/index?id=${item.id}`
						})
					})
				}
			},
			// #ifdef H5
			// 微信分享；
			setOpenShare: function() {
				let that = this;
				if (that.$wechat.isWeixin()) {
					getShare().then(res => {
						let data = res.data.data;
						let configAppMessage = {
							desc: data.synopsis,
							title: data.title,
							link: location.href,
							imgUrl: data.img
						};
						that.$wechat.wechatEvevt(["updateAppMessageShareData", "updateTimelineShareData"], configAppMessage);
					})
				}
			},
			// #endif
		},
		onReachBottom: function() {
			this.getGroomList();
		}
	}
</script>

<style>

</style>
