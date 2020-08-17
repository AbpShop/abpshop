<template>
  <view class="not-defined">
    <!-- <img src="@/static/img/404.png" /> -->

    <view class="content">
      <h3 class="title">页面未找到</h3>
      <span
        >抱歉！您访问的页面不存在，请返回上一级或点击下方按钮返回首页...</span
      >
    </view>

    <view class="btn" @click="$Route.replace({ path: '/' })">
      返回首页
    </view>
  </view>
</template>

<script>
export default {
  name: "NotDefined",
  mounted() {
  	console.log(this.$Route)
  }
};
</script>

<style scoped lang="scss">
.not-defined img {
  width: 100%;
  margin-top: 18%;
}

.content {
  padding: 0 1rem;
  text-align: center;
  color: #44405e;
  font-size: 15px;
}

.title {
  margin-bottom: 0.6rem;
  color: #302c48;
  font-size: 20px;
}

.btn {
  color: #fff;
  background-color: #ef4c4c;
  font-size: 16px;
  padding: 0.16rem;
  border-radius: 25px;
  text-align: center;
  width: 2.4rem;
  margin: 0 auto;
  margin-top: 1rem;
}
</style>
