<template>
    <div class="numbox" v-if="configData">
        <div class="c_row-item">
        <Col class="label" span="4">
            <span>商品数量</span>
        </Col>
        <Col span="19" class="slider-box">
            <Input v-model="configData.val" type="number" placeholder="请输入数量" style="text-align: right;"/>
        </Col>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'c_input_number',
        props: {
            configObj: {
                type: Object
            },
            configNme: {
                type: String
            }
        },
        data () {
            return {
                defaults: {},
                sliderWidth: 0,
                configData: {}
            }
        },
        created () {
            this.defaults = this.configObj
            this.configData = this.configObj[this.configNme]
        },
        watch: {
            configObj: {
                handler (nVal, oVal) {
                    this.defaults = nVal
                    this.configData = nVal[this.configNme]
                },
                immediate: true,
                deep: true
            }
        }
    }
</script>

<style scoped lang="stylus">
    .numbox
        display flex
        align-items center
        margin-bottom 10px
        span
            width 80px
            color #999
            /*font-size 12px*/
    .c_row-item
        width 100%
</style>
