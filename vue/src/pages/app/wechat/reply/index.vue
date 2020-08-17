<template>
    <div>
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" :title="$route.meta.title" hidden-breadcrumb></PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt"></Card>
    </div>
</template>

<script>
    export default {
        name: 'index'
    }
</script>

<style scoped>

</style>
