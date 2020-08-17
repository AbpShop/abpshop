<template>
	<div>
		<div class="storeBox" ref="container">
			<div class="storeBox-box" v-for="(item, index) in storeList" :key="index" @click.stop="checked(item)">
				<div class="store-img"><img :src="item.image" lazy-load="true" /></div>
				<div class="store-cent-left">
					<div class="store-name">{{ item.name }}</div>
					<div class="store-address line1">
						{{ item.address }}{{ ", " + item.detailed_address }}
					</div>
				</div>
				<div class="row-right">
					<div>
						<a class="store-phone" :href="'tel:' + item.phone"><span class="iconfont icon-dadianhua01"></span></a>
					</div>
					<div class="store-distance" @click.stop="showMaoLocation(item)">
						<span class="addressTxt" v-if="item.range">距离{{ item.range }}千米</span>
						<span class="addressTxt" v-else>查看地图</span>
						<span class="iconfont icon-youjian"></span>
					</div>
				</div>
			</div>
			<Loading :loaded="loaded" :loading="loading"></Loading>
		</div>
		<div>
			<iframe v-if="locationShow && !isWeixin" ref="geoPage" width="0" height="0" frameborder="0" style="display:none;"
			 scrolling="no" :src="
          'https://apis.map.qq.com/tools/geolocation?key=' +
            mapKey +
            '&referer=myapp'
        ">
			</iframe>
		</div>
		<div class="geoPage" v-if="mapShow">
			<iframe width="100%" height="100%" frameborder="0" scrolling="no" :src="
          'https://apis.map.qq.com/uri/v1/geocoder?coord=' +
            system_store.latitude +
            ',' +
            system_store.longitude +
            '&referer=' +
            mapKey
        ">
			</iframe>
		</div>
	</div>
</template>

<script>
	import Loading from "@/components/Loading";
	import {
		storeListApi
	} from "@/api/store";
	import {
		isWeixin
	} from "@/utils/index";
	// #ifdef H5
	import {
		wechatEvevt,
		wxShowLocation
	} from "@/libs/wechat";
	// #endif

	import {
		mapGetters
	} from "vuex";
	// import cookie from "@/utils/store/cookie";
	const LONGITUDE = "user_longitude";
	const LATITUDE = "user_latitude";
	const MAPKEY = "mapKey";
	export default {
		name: "storeList",
		components: {
			Loading
		},
		// computed: mapGetters(["goName"]),
		data() {
			return {
				page: 1,
				limit: 20,
				loaded: false,
				loading: false,
				storeList: [],
				mapShow: false,
				system_store: {},
				// mapKey: cookie.get(MAPKEY),
				locationShow: false,
				user_latitude: 0,
				user_longitude: 0
			};
		},
		onLoad() {
			try {
				this.user_latitude = uni.getStorageSync('user_latitude');
				this.user_longitude = uni.getStorageSync('user_longitude');
			} catch (e) {
				// error
			}
		},
		mounted() {
			if (this.user_latitude && this.user_longitude) {
				this.getList();
			} else {
				this.selfLocation();
			}
			// this.$scroll(this.$refs.container, () => {
			//   !this.loading && this.getList();
			// });
		},
		methods: {
			selfLocation() {
				let self = this
				// if (isWeixin()) {
				// 	wxShowLocation()
				// 		.then(res => {
				// 			console.log(res);
				// 			this.getList();
				// 		})
				// 		.catch(err => {
				// 			this.$dialog.error(err.msg);
				// 			this.getList();
				// 		});
				// } else {
				// 	if (!cookie.get(MAPKEY))
				// 		return this.$dialog.error(
				// 			"暂无法使用查看地图，请配置您的腾讯地图key"
				// 		);
				// 	let loc;
				// 	let _this = this;
				// 	if (cookie.get(MAPKEY)) _this.locationShow = true;
				// 	//监听定位组件的message事件
				// 	window.addEventListener(
				// 		"message",
				// 		function(event) {
				// 			loc = event.data; // 接收位置信息 LONGITUDE
				// 			console.log("location", loc);
				// 			if (loc && loc.module == "geolocation") {
				// 				cookie.set(LATITUDE, loc.lat);
				// 				cookie.set(LONGITUDE, loc.lng);
				// 				_this.getList();
				// 			} else {
				// 				cookie.remove(LATITUDE);
				// 				cookie.remove(LONGITUDE);
				// 				_this.getList();
				// 				//定位组件在定位失败后，也会触发message, event.data为null
				// 				console.log("定位失败");
				// 			}
				// 		},
				// 		false
				// 	);
				// 	// this.$refs.geoPage.contentWindow.postMessage("getLocation", "*");
				// }
				uni.getLocation({
					type: 'wgs84',
					success: function(res) {
						try {
							uni.setStorageSync('user_latitude', res.latitude);
							uni.setStorageSync('user_longitude', res.longitude);
						} catch {}
						self.getList();
					},
					complete:function() {
						self.getList();
					}
				});
			},
			showMaoLocation(e) {
				console.log(e)
				// this.system_store = e;
				// if (isWeixin()) {
				//   let config = {
				//     latitude: parseFloat(this.system_store.latitude),
				//     longitude: parseFloat(this.system_store.longitude),
				//     name: this.system_store.name,
				//     address:
				//       this.system_store.address + this.system_store.detailed_address
				//   };
				//   wechatEvevt("openLocation", config)
				//     .then(res => {
				//       console.log(res);
				//     })
				//     .catch(res => {
				//       if (res.is_ready) {
				//         res.wx.openLocation(config);
				//       }
				//     });
				// } else {
				//   if (!cookie.get(MAPKEY))
				//     return this.$dialog.error(
				//       "暂无法使用查看地图，请配置您的腾讯地图key"
				//     );
				//   this.mapShow = true;
				// }
				uni.openLocation({
					latitude: Number(e.latitude),
					longitude: Number(e.longitude),
					success: function() {
						console.log('success');
						Number
					}
				});
			},
			// 选中门店
			checked(e) {

				uni.$emit("handClick", {
					address: e
				});
				uni.navigateBack();
				// if (this.goName === "orders") {
				//   this.$store.commit("GET_STORE", e);
				//   this.$router.go(-1); //返回上一层
				// }
			},
			// 获取门店列表数据
			getList: function() {
				if (this.loading || this.loaded) return;
				this.loading = true;
				let data = {
					latitude: this.user_latitude || "", //纬度
					longitude: this.user_longitude || "", //经度
					page: this.page,
					limit: this.limit
				};
				storeListApi(data)
					.then(res => {
						this.loading = false;
						this.loaded = res.data.list.length < this.limit;
						this.storeList.push.apply(this.storeList, res.data.list.list);
						this.page = this.page + 1;
					})
					.catch(err => {
						this.$dialog.error(err.msg);
					});
			}
		},
		onReachBottom() {
			this.getList();
		}
	};
</script>

<style>
	.geoPage {
		position: fixed;
		width: 100%;
		height: 100%;
		top: 0;
		z-index: 10000;
	}

	.storeBox {
		width: 100%;
		background-color: #fff;
		padding: 0 30rpx;
	}

	.storeBox-box {
		width: 100%;
		height: auto;
		display: flex;
		align-items: center;
		padding: 23rpx 0;
		justify-content: space-between;
		border-bottom: 1px solid #eee;
	}

	.store-cent {
		display: flex;
		align-items: center;
		width: 80%;
	}

	.store-cent-left {
		width: 45%;
	}

	.store-img {
		width: 120rpx;
		height: 120rpx;
		border-radius: 6rpx;
		margin-right: 22rpx;
	}

	.store-img img {
		width: 100%;
		height: 100%;
	}

	.store-name {
		color: #282828;
		font-size: 30rpx;
		margin-bottom: 22rpx;
		font-weight: 800;
	}

	.store-address {
		color: #666666;
		font-size: 24rpx;
	}

	.store-phone {
		width: 50rpx;
		height: 50rpx;
		color: #fff;
		border-radius: 50%;
		display: block;
		text-align: center;
		line-height: 50rpx;
		background-color: #e83323;
		margin-bottom: 22rpx;
	}

	.store-distance {
		font-size: 22rpx;
		color: #e83323;
	}

	.iconfont {
		font-size: 20rpx;
	}

	.row-right {
		display: flex;
		flex-direction: column;
		align-items: flex-end;
		width: 33.5%;
	}
</style>
