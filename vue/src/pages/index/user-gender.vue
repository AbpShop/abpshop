<template>
    <div class="dashboard-console-user-gender">
        <Row type="flex" justify="center" align="middle">
            <Col span="8" class="ivu-text-center" v-color="'#3399ff'">
                <Avatar icon="ios-man" size="large" v-color="'#3399ff'" v-bg-color="'#d6f0ff'" />
                <div class="ivu-mt-8">男性 65%</div>
            </Col>
            <Col span="8" class="ivu-text-center" v-color="'#be6be0'">
                <Avatar icon="ios-woman" size="large" v-color="'#be6be0'" v-bg-color="'#fdf0ff'" />
                <div class="ivu-mt-8">女性 25%</div>
            </Col>
            <Col span="8" class="ivu-text-center" v-color="'#babdc3'">
                <Avatar icon="md-man" size="large" v-color="'#babdc3'" v-bg-color="'#e6edf5'" />
                <div class="ivu-mt-8">未知 10%</div>
            </Col>
        </Row>
        <div class="dashboard-console-user-gender-grid ivu-mt-8">
            <Grid center square :col="25" padding="2px" :border="false">
                <GridItem v-for="item in 100" :key="item">
                    <span v-bg-color="'#3399ff'" v-if="item <= 65"></span>
                    <span v-bg-color="'#be6be0'" v-else-if="item <= 90"></span>
                    <span v-bg-color="'#babdc3'" v-else></span>
                </GridItem>
            </Grid>
        </div>
    </div>
</template>
<script>
    export default {
        data () {
            return {

            }
        }
    }
</script>
<style lang="less">
    .dashboard-console-user-gender{
        &-grid{
            .ivu-grid-item-main{
                height: 100%;
            }
            span{
                display: block;
                height: 100%;
                border-radius: 2px;
                opacity: 0.75;
            }
        }
    }
</style>
