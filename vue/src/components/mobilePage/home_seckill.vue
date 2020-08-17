<template>
  <div class="mobile-page paddingBox">
    <div class="seckill-box" :style="{ marginTop: mTOP + 'px' }">
      <div class="hd">
        <div class="left">
          <img :src="imgUrl" alt="" />
          <p>限时秒杀</p>
          <div class="time">
            <span :style="{ background: bgColor, color: themeColor }">00</span>
            <em>:</em>
            <span :style="{ background: bgColor, color: themeColor }">00</span>
            <em>:</em>
            <span :style="{ background: bgColor, color: themeColor }">00</span>
          </div>
        </div>
        <div class="right">
          更多
        </div>
      </div>
      <div class="list-wrapper">
        <div
          class="list-item"
          v-for="(item, index) in list"
          :index="index"
          :style="{ marginRight: listRight + 'px' }"
        >
          <div class="img-box">
            <img :src="item.img" alt="" v-if="item.img" />
            <div class="empty-box"><span class="iconfont-diy icontupian"></span></div>
            <div
              class="discount"
              :style="{ borderColor: themeColor, color: themeColor }"
            >
              {{ item.discount }}折起
            </div>
          </div>
          <div class="title line1">{{ item.name }}</div>
          <div class="price">
            <span class="label" :style="{ background: themeColor }">抢</span>
            <span class="num-label" :style="{ color: themeColor }">￥</span>
            <span class="num" :style="{ color: themeColor }">{{
              item.price
            }}</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
    import { mapState, mapMutations } from 'vuex';
    export default {
        name: 'home_seckill',
        cname: '秒杀',
        configName: 'c_home_seckill',
        icon: 'iconmiaosha',
        type:1,// 0 基础组件 1 营销组件 2工具组件
        defaultName:'seckill', // 外面匹配名称
        props: {
            index: {
                type: null
            },
            num: {
                type: null
            }
        },
        computed: {
            ...mapState('admin/mobildConfig', ['defaultArray'])
        },

        watch: {
            pageData: {
                handler (nVal, oVal) {
                    this.setConfig(nVal);
                },
                deep: true
            },
            num: {
                handler (nVal, oVal) {
                    let data = this.$store.state.admin.mobildConfig.defaultArray[nVal];
                    this.setConfig(data);
                    // this.$store.state.admin.mobildConfig.defaultArray.forEach((el, i) => {
                    //     if (el.timestamp == nVal) {
                    //         this.setConfig(el)
                    //         console.log(i, 'index监听')
                    //     }
                    // })
                },
                deep: true
            },
            defaultArray: {
                handler (nVal, oVal) {
                    let data = this.$store.state.admin.mobildConfig.defaultArray[this.num];
                    this.setConfig(data);
                },
                deep: true
            }
        },
        data () {
            return {
                // 默认初始化数据禁止修改
                defaultConfig: {
                    name: 'seckill',
                    timestamp: this.num,
                    countDownColor: {
                        title: '倒计时背景色',
                        name: 'countDownColor',
                        default: [
                            {
                                item: 'rgba(252,60,62,0.09)'
                            }
                        ],
                        color: [
                            {
                                item: 'rgba(252,60,62,0.09)'
                            }
                        ]
                    },
                    themeColor: {
                        title: '主题风格',
                        name: 'themeColor',
                        default: [
                            {
                                item: '#E93323'
                            }
                        ],
                        color: [
                            {
                                item: '#E93323'
                            }
                        ]
                    },
                    numberConfig: {
                        val: 3
                    },
                    lrConfig: {
                        title: '左右边距',
                        val: 10,
                        min: 10
                    },
                    // 页面间距
                    mbConfig: {
                        title: '页面间距',
                        val: 0,
                        min: 0
                    },
                    imgConfig: {
                        title: '最多可添加1张图片，建议宽度18 * 18px',
                        url: 'static/images/spike-icon-002.gif'
                    }
                },
                list: [
                    {
                        img: '',
                        name: '小米家用电饭煲小米家用电饭煲',
                        price: '234',
                        discount: '1.2'
                    },
                    {
                        img: '',
                        name: '小米家用电饭煲小米家用电饭煲',
                        price: '234',
                        discount: '1.2'
                    },
                    {
                        img: '',
                        name: '小米家用电饭煲小米家用电饭煲',
                        price: '234',
                        discount: '1.2'
                    }
                ],
                mTOP: 0,
                listRight: 0,
                bgColor: '',
                themeColor: '',
                pageData: {},
                imgUrl: ''
            };
        },
        mounted () {
            this.$nextTick(() => {
                this.pageData = this.$store.state.admin.mobildConfig.defaultArray[this.num]
                this.setConfig(this.pageData)
            })
        },
        methods: {
            setConfig (data) {
                this.mTOP = data.mbConfig.val;
                this.listRight = data.lrConfig.val;
                this.bgColor = data.countDownColor.color[0].item;
                this.themeColor = data.themeColor.color[0].item;
                this.imgUrl = data.imgConfig.url
            }
        }
    };
</script>

<style scoped lang="stylus">
.seckill-box
    padding 15px 10px
    background #fff
    .hd
        display flex
        justify-content space-between
        align-items center
        .left
            display flex
            align-items center
            img
                width 18px
                height 18px
                margin-right 5px
                border-radius 50%
            p
                font-size 16px
                color #282828
                font-weight:600;
            .time
                display flex
                align-items center
                margin-left 5px
                color #FF4444
                span
                    width 20px
                    height 16px
                    font-size 12px
                    text-align center
                    line-height 16px
                em
                    font-size 12px
                    margin 0 3px
                    font-style: initial;
                    font-weight bold
    .list-wrapper
        display flex
        margin-top 8px
        overflow hidden
        .list-item
            flex-shrink 0
            width 110px
            .img-box
                position: relative;
                width 100%
                height 110px
                img,.box
                    width 100%
                    height 100%
                    border-radius:8px;
                .box
                    background #D8D8D8
                .discount
                    position absolute
                    left 8px
                    bottom 8px
                    height:18px;
                    padding 0 3px
                    line-height 18px
                    background:rgba(255,255,255,1);
                    border-radius:2px;
                    border:1px solid transparent;
                    font-size 12px
            .title
                margin-top 5px
                font-size 13px
                color #282828
            .price
                display flex
                align-items center
                .label
                    font-size 9px
                    width 16px
                    height 16px
                    color #fff
                    text-align center
                    line-height 16px
                .num-label
                    color #FF4444
                    font-size 12px
                    font-weight:600;
                    margin 1px 2px 0
                .num
                    color #FF4444
                    font-size 16px
                    font-weight:600;
</style>
