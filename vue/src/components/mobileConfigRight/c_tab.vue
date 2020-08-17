<template>
    <div style="margin-bottom: 20px">
        <div class="title-tips" v-if="configData.tabList">
            <span>选择模板</span>{{configData.tabList[configData.tabVal].name}}
        </div>
        <div class="radio-box" :class="{on:configData.type == 1}">
            <RadioGroup v-model="configData.tabVal" type="button" size="large" @on-change="radioChange($event)">
                <Radio :label="index" v-for="(item,index) in configData.tabList" :key="index" >
                    <span class="iconfont-diy" :class="item.icon" v-if="item.icon"></span>
                    <span v-else>{{item.name}}</span>
                </Radio>
            </RadioGroup>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'c_tab',
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
                formData: {
                    type: 0
                },
                defaults: {},
                configData: {}
            }
        },
        watch: {
            configObj: {
                handler (nVal, oVal) {
                    this.defaults = nVal
                    this.configData = nVal[this.configNme]
                },
                deep: true
            }
        },
        mounted () {
            this.$nextTick(() => {
                this.defaults = this.configObj
                this.configData = this.configObj[this.configNme]
            })
        },
        methods: {
            radioChange (e) {
                this.$emit('getConfig', e);
            }
        }
    }
</script>

<style scoped lang="stylus">
    .radio-box
        /deep/.ivu-radio-group-button
            display flex
            width 100%
            .ivu-radio-wrapper
                flex 1
                display flex
                align-items center
                justify-content center
        &.on
            /deep/.ivu-radio-group-button
                .ivu-radio-wrapper
                    flex 1
    .title-tips
        padding-bottom 10px
        font-size 14px
        color #333
        span
            margin-right 14px
            color #999
    .iconfont-diy
        font-size 20px
        line-height 18px
</style>
