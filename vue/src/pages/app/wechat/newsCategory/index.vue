<template>
    <div style="height: 100%">
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" title="图文管理" hidden-breadcrumb></PageHeader>
        </div>
        <news-category :isShow="isShow"></news-category>
    </div>
</template>

<script>
    import newsCategory from '@/components/newsCategory/index';
    export default {
        name: 'newsCategoryIndex',
        data () {
            return {
                isShow: true
            }
        },
        components: {
            newsCategory
        }
    }
</script>
