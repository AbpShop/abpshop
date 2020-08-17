<template>
	<view class="register">
		<view class="shading">
			<view class="pictrue acea-row row-center-wrapper">
				<image :src="logoUrl" v-if="logoUrl"></image>
				<image src="/static/images/logo2.png" v-else></image>
			</view>
		</view>
		<view class="whiteBg" v-if="formItem === 1">
			<view class="title acea-row row-center-wrapper">
				<view class="item" :class="current === index ? 'on' : ''" v-for="(item, index) in navList" @click="navTap(index)"
				 :key="index">
					{{ item }}
				</view>
			</view>
			<view class="list" :hidden="current !== 0">
				<form @submit.prevent="submit">
					<view class="item">
						<view class="acea-row row-middle">
							<image src="/static/images/phone_1.png"></image>
							<input type="text" placeholder="输入手机号码" v-model="account" placeholder-class="placeholder" class="input" />
						</view>
					</view>
					<view class="item">
						<view class="acea-row row-middle">
							<image src="/static/images/code_2.png"></image>
							<input type="password" placeholder="填写登录密码" v-model="password" placeholder-class="placeholder" class="input" />
						</view>
					</view>
				</form>
				<navigator url="/pages/retrieve_password/index" class="forgetPwd">
					<text class="iconfont icon-wenti"></text>忘记密码
				</navigator>
			</view>
			<view class="list" :hidden="current !== 1">
				<view class="item">
					<view class="acea-row row-middle">
						<image src="/static/images/phone_1.png"></image>
						<input type="text" placeholder="输入手机号码" placeholder-class="placeholder" class="input" v-model="account" />
					</view>
				</view>
				<view class="item">
					<view class="align-left acea-row row-middle">
						<image src="/static/images/code_2.png"></image>
						<input type="text" placeholder="填写验证码" class="codeIput" v-model="captcha" placeholder-class="placeholder" />
						<button class="code" :disabled="disabled" :class="disabled === true ? 'on' : ''" @click="code">
							{{ text }}
						</button>
					</view>
				</view>
			</view>
			<view class="logon" @click="loginMobile" :hidden="current !== 1">登录</view>
			<view class="logon" @click="submit" :hidden="current === 1">登录</view>
			<view class="tip">
				没有账号?
				<text @click="formItem = 2" class="font-color">立即注册</text>
			</view>
		</view>
		<view class="whiteBg" v-else>
			<view class="title">注册账号</view>
			<view class="list">
				<view class="item">
					<view class="acea-row row-middle">
						<image src="/static/images/phone_1.png"></image>
						<input type="text" placeholder="输入手机号码" placeholder-class="placeholder" class="input" v-model="account" />
					</view>
				</view>
				<view class="item">
					<view class="align-left acea-row row-middle">
						<image src="/static/images/code_2.png"></image>
						<input type="text" placeholder="填写验证码" class="codeIput" v-model="captcha" placeholder-class="placeholder" />
						<button class="code" :disabled="disabled" :class="disabled === true ? 'on' : ''" @click="code">
							{{ text }}
						</button>
					</view>
				</view>
				<view class="item">
					<view class="acea-row row-middle">
						<image src="/static/images/code_1.png"></image>
						<input type="password" placeholder="填写您的登录密码" placeholder-class="placeholder" class="input" v-model="password" />
					</view>
				</view>
			</view>
			<view class="logon" @click="register">注册</view>
			<view class="tip">
				已有账号?
				<text @click="formItem = 1" class="font-color">立即登录</text>
			</view>
		</view>
		<view class="bottom"></view>
	</view>
</template>
<script>
	import sendVerifyCode from "@/mixins/SendVerifyCode";
	import {
		loginH5,
		loginMobile,
		registerVerify,
		register,
		getCodeApi,
		getUserInfo
	} from '@/api/user.js';
	import {
		getLogo
	} from "@/api/public";
	import dayjs from "dayjs";
	import {
		BACK_URL
	} from '@/config/cache';
	export default {
		mixins: [sendVerifyCode],
		data() {
			return {
				navList: ["账号登录", "快速登录"],
				current: 1,
				account: "",
				password: "",
				captcha: "",
				formItem: 1,
				type: "login",
				logoUrl: "",
				keyCode: "",
			}
		},
		onLoad() {
			this.getLogoImage();
			this.getCode();
		},
		methods: {
			// 获取keyCode
			getCode() {
				let that = this
				getCodeApi()
					.then(res => {
						this.keyCode = res.data.key;
					})
					.catch(res => {
						that.$util.Tips({title: res});
					});
			},
			getLogoImage() {
				let that = this;
				getLogo(2).then(res => {
					that.logoUrl = res.data.logo_url;
				});
			},
			loginMobile() {
				let that = this;
				if (!that.account) return that.$util.Tips({
					title: '请填写手机号码'
				});
				if (!/^1(3|4|5|7|8|9|6)\d{9}$/i.test(that.account)) return that.$util.Tips({
					title: '请输入正确的手机号码'
				});
				if (!that.captcha) return that.$util.Tips({
					title: '请填写验证码'
				});
				if (!/^[\w\d]+$/i.test(that.captcha)) return that.$util.Tips({
					title: '请输入正确的验证码'
				});
				loginMobile({
						phone: that.account,
						captcha: that.captcha,
						spread: that.$Cache.get("spread")
					})
					.then(res => {
						let data = res.data;
						let newTime = Math.round(new Date() / 1000);
						that.$store.commit("LOGIN", {
							'token': data.token,
							'time': dayjs(data.expires_time) - newTime
						});
						const backUrl = that.$Cache.get(BACK_URL) || "/pages/index/index";
						that.$Cache.clear(BACK_URL);
						getUserInfo().then(res=>{
							that.$store.commit("SETUID", res.data.uid);
							if (backUrl === '/pages/index/index' || backUrl === '/pages/order_addcart/order_addcart' || backUrl ===
								'/pages/user/index' || backUrl === '/pages/goods_cate/goods_cate') {
							
								uni.switchTab({
									url: backUrl
								});
							
							} else {
								uni.redirectTo({
									url: backUrl
								});
							}
						})
						
						
						
					})
					.catch(res => {
						that.$util.Tips({
							title: res
						});
					});
			},
			register() {
				let that = this;
				if (!that.account) return that.$util.Tips({
					title: '请填写手机号码'
				});
				if (!/^1(3|4|5|7|8|9|6)\d{9}$/i.test(that.account)) return that.$util.Tips({
					title: '请输入正确的手机号码'
				});
				if (!that.captcha) return that.$util.Tips({
					title: '请填写验证码'
				});
				if (!/^[\w\d]+$/i.test(that.captcha)) return that.$util.Tips({
					title: '请输入正确的验证码'
				});
				if (!that.password) return that.$util.Tips({
					title: '请填写密码'
				});
				if (!/^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,16}$/i.test(that.password)) return that.$util.Tips({
					title: '您输入的密码过于简单'
				});
				register({
						account: that.account,
						captcha: that.captcha,
						password: that.password,
						spread: that.$Cache.get("spread")
					})
					.then(res => {
						that.$util.Tips({
							title: res.msg
						});
						that.formItem = 1;
					})
					.catch(res => {
						that.$util.Tips({
							title: res.msg
						});
					});
			},
			async code() {
				let that = this;
				if (!that.account) return that.$util.Tips({
					title: '请填写手机号码'
				});
				if (!/^1(3|4|5|7|8|9|6)\d{9}$/i.test(that.account)) return that.$util.Tips({
					title: '请输入正确的手机号码'
				});
				if (that.formItem == 2) that.type = "register";
				await registerVerify({
						phone: that.account,
						type: that.type,
						key:that.keyCode,
						code:that.captcha
					})
					.then(res => {
						that.$util.Tips({
							title: res.msg
						});
						that.sendCode();
					})
					.catch(res => {
						that.$util.Tips({
							title: res
						});
					});
			},
			navTap: function(index) {
				this.current = index;
			},
			submit() {
				let that = this;
				if (!that.account) return that.$util.Tips({
					title: '请填写账号'
				});
				if (!/^[\w\d]{5,16}$/i.test(that.account)) return that.$util.Tips({
					title: '请输入正确的账号'
				});
				if (!that.password) return that.$util.Tips({
					title: '请填写密码'
				});
				// if (!/^[0-9A-Za-z]{6,16}$/i.test(that.password)) return that.$util.Tips({
				// 	title: '请输入正确的密码'
				// });
				loginH5({
						account: that.account,
						password: that.password
					})
					.then(({data}) => {
						let newTime = Math.round(new Date() / 1000);
						that.$store.commit("LOGIN", {
							'token': data.token,
							'time': dayjs(data.expires_time) - newTime
						});
						const backUrl = that.$Cache.get(BACK_URL) || "/pages/index/index";
						that.$Cache.clear(BACK_URL);
						getUserInfo().then(res=>{
							that.$store.commit("SETUID", res.data.uid);
							if (backUrl === '/pages/index/index' || backUrl === '/pages/order_addcart/order_addcart' || backUrl ===
								'/pages/user/index' || backUrl === '/pages/goods_cate/goods_cate') {
								uni.switchTab({
									url: backUrl
								});
							} else {
								uni.redirectTo({
									url: backUrl
								});
							}
						})
					})
					.catch(e => {
						that.$util.Tips({
							title: e
						});
					});
			}
		}
	}
</script>

<style scoped lang="scss">

</style>
