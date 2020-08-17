<template>
    <div class="box" v-if="configData">
        <div class="c_row-item">
            <Col class="label" span="4">
                {{configData.title}}
            </Col>
            <Col span="19" class="slider-box">
                <Input v-model="configData.value" placeholder="选填不超过10个字" :maxlength="configData.max" />
            </Col>
        </div>
    </div>

</template>

<script>
    export default {
        name: 'c_input_item',
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
                value: '',
                defaults: {},
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
.c_row-item
    margin-bottom 13px
</style>
