<template>
    <div class="article-manager">
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="系统设置">
                <div slot="content">
                    <Tabs v-model="currentTab">
                        <TabPane label="公众号配置" name="onsale"/>
                        <TabPane label="配置" name="forsale"/>
                    </Tabs>
                </div>
            </PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt" v-if="currentTab === 'onsale'">
            <!--<form-create  :rule="Array.from(FromData.rules)" @on-submit="onSubmit" ></form-create>-->
        </Card>
    </div>
</template>

<script>
    import formCreate from '@form-create/iview'
    export default {
        name: 'setApp',
        components: { formCreate },
        data () {
            return {
                FromData: null,
                currentTab: ''
            }
        },
        mounted () {
        },
        methods: {
        }
    }
</script>

<style scoped>

</style>
