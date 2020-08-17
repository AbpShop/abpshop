<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="订单管理" hidden-breadcrumb>
                <div slot="content">
                    <Tabs v-model="currentTab">
                        <TabPane label="开发者专区" name=" "/>
                        <TabPane label="官方动态" name="1"/>
                    </Tabs>
                </div>
            </PageHeader>
        </div>
        <table-list></table-list>
    </div>
</template>

<script>
    import tableList from './components/tableList';
    export default {
        name: 'index',
        data () {
            return {
                currentTab: ''
            }
        },
        components: {
            tableList
        },
    }
</script>

<style scoped>

</style>
