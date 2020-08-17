<template>
    <div class="c_product" v-if="configData">
        <div class="title">{{configData.title}}</div>
        <div class="list-box">
            <draggable
                    class="dragArea list-group"
                    :list="configData.list"
                    group="peoples"
                    handle=".move-icon"
            >
                <div class="item" v-for="(item,index) in configData.list" :key="index">
                    <div class="move-icon">
                        <span class="iconfont-diy icondrag2"></span>
                    </div>
                    <div class="content">
                        <div class="con-item" v-for="(list,key) in item.chiild" :key="key">
                            <span>{{list.title}}</span>
                            <Input v-model="list.val" :placeholder="list.pla" :maxlength="list.max"/>
                        </div>
                        <div class="con-item" v-if="item.link">
                            <span>{{item.link.title}}</span>
                            <Select v-model="item.link.activeVal" style="">
                                <Option v-for="(item,j) in item.link.optiops" :value="item.value" :key="j">{{ item.label
                                    }}
                                </Option>
                            </Select>
                        </div>
                    </div>
                    <div class="delete" @click.stop="bindDelete(index)">
                        <Icon type="ios-close-circle" size="26"/>
                    </div>
                </div>
            </draggable>
        </div>
        <div v-if="configData.list">
            <div class="add-btn" @click="addHotTxt" v-if="configData.list.length < 4">
                <Button type="primary" ghost style="width: 100%; height: 40px; border-color:#1890FF; color: #1890FF;">添加热词</Button>
            </div>
        </div>

    </div>
</template>

<script>
    import vuedraggable from 'vuedraggable'

    export default {
        name: 'c_product',
        props: {
            configObj: {
                type: Object
            },
            configNme: {
                type: String
            },
            index: {
                type: null
            }
        },
        components: {
            draggable: vuedraggable
        },
        data () {
            return {
                defaults: {},
                configData: {},
                itemObj: {}
            }
        },
        mounted () {
            this.$nextTick(() => {
                this.defaults = this.configObj
                this.configData = this.configObj[this.configNme]
            })
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
        methods: {
            addHotTxt () {
                if (this.configData.list.length == 0) {
                    this.configData.list.push(this.itemObj)
                } else {
                    let obj = JSON.parse(JSON.stringify(this.configData.list[this.configData.list.length - 1]));
                    this.configData.list.push(obj)
                }
            },
            // 删除数组
            bindDelete (index) {
                if (this.configData.list.length == 1) {
                    this.itemObj = this.configData.list[0]
                }
                this.configData.list.splice(index, 1)
            }
        }
    }
</script>

<style scoped lang="stylus">
    .c_product
        border-bottom 1px solid rgba(0,0,0,0.05);
        padding-bottom 20px
        margin-bottom 20px
        .list-box
            .item
                position relative
                display flex
                margin-top 23px
                padding 18px 20px 18px 0
                border: 1px solid rgba(238, 238, 238, 1);

                .delete
                    position absolute
                    right 0
                    top 0
                    right: -13px;
                    top: -14px;
                    color #999999
                    cursor pointer

            .move-icon
                display flex
                align-items center
                justify-content center
                width 50px
                cursor move

            .content
                flex 1

                .con-item
                    display flex
                    align-items center
                    margin-bottom 15px

                    &:last-child
                        margin-bottom 0
                    span
                        width 45px
                        font-size 13px

        .add-btn
            margin-top 18px
    .title
        padding-top 20px
        font-size 12px
        color #999
    .iconfont-diy
        color #DDDDDD
        font-size 38px
</style>
