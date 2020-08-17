<template>
    <div class="article-manager">
        <div class="i-layout-page-header">
            <PageHeader class="product_tabs" :title="title" hidden-breadcrumb>
                <div slot="content">
                    <Tabs v-model="currentTab" @on-click="changeTab">
                        <TabPane :icon="item.icon" :label="item.label" :name="item.value.toString()" v-for="(item,index) in headerList" :key="index"/>
                    </Tabs>
                </div>
            </PageHeader>
        </div>
        <Card :bordered="false" dis-hover class="ivu-mt fromBox">
            <Tabs type="card" v-model="childrenId" v-if="headerChildrenList.length" @on-click="changeChildrenTab">
                <TabPane :label="item.label" :name="item.id.toString()" v-for="(item,index) in headerChildrenList" :key="index"></TabPane>
            </Tabs>
            <form-create :option="option"  :rule="rules" @on-submit="onSubmit" v-if="rules.length!==0"></form-create>
            <Spin size="large" fix v-if="spinShow"></Spin>
        </Card>
    </div>
</template>

<script>
    import formCreate from '@form-create/iview'
    import { headerListApi, dataFromApi } from '@/api/setting';
    import request from '@/plugins/request';
    export default {
        name: 'setting_setSystem',
        components: { formCreate: formCreate.$form() },
        data () {
            return {
                rules: [],
                option: {
                    form: {
                        labelWidth: 185
                    },
                    global: {
                        upload: {
                            props: {
                                onSuccess (res, file) {
                                    if (res.status === 200) {
                                        file.url = res.data.src;
                                    } else {
                                        this.$Message.error(res.msg);
                                    }
                                }
                            }
                        }
                    }
                },
                spinShow: false,
                FromData: null,
                currentTab: '',
                headerList: [],
                headerChildrenList: [],
                childrenId: '',
                title: ''
            }
        },
        created () {
            this.getAllData();
        },
        watch: {
            $route (to, from) {
                this.headerChildrenList = [];
                this.getAllData();
            },
            childrenId () {
                this.getFrom();
            }
        },
        methods: {
            childrenList () {
                let that = this;
                that.headerList.forEach(function (item) {
                    if (item.value.toString() === that.currentTab) {
                        that.headerChildrenList = item.children;
                        that.childrenId = item.children.length ? item.children[0].id.toString() : '';
                    }
                });
            },
            // 头部tab
            getHeader () {
                this.spinShow = true;
                return new Promise((resolve, reject) => {
                    let data = {
                        type: this.$route.params.type ? this.$route.params.type : 0
                    };
                    headerListApi(data).then(async res => {
                        let config = res.data.config_tab;
                        this.headerList = config;
                        this.currentTab = config[0].value.toString();
                        this.childrenList();
                        resolve(this.currentTab);
                        this.spinShow = false;
                    }).catch(res => {
                        this.spinShow = false;
                        this.$Message.error(res.msg);
                    })
                });
            },
            // 表单
            getFrom () {
                this.spinShow = true;
                return new Promise((resolve, reject) => {
                    let ids = '';
                    if (this.$route.params.type === '3') {
                        ids = this.$route.params.tab_id
                    } else {
                        if (this.childrenId) {
                            ids = this.childrenId;
                        } else {
                            ids = this.currentTab;
                        }
                    }
                    let data = {
                        tab_id: Number(ids)
                    };
                    dataFromApi(data).then(async res => {
                        this.spinShow = false;
                        if (res.data.status === false) {
                            return this.$authLapse(res.data);
                        }
                        this.FromData = res.data;
                        this.rules = res.data.rules;
                        this.title = res.data.title;
                    }).catch(res => {
                        this.spinShow = false;
                        this.$Message.error(res.msg);
                    })
                });
            },
            async getAllData () {
                if (this.$route.params.type !== '3') {
                    await this.getHeader();
                } else {
                    this.headerList = [];
                    this.getFrom();
                }
            },
            // 选择
            changeTab () {
                this.childrenList();
            },
            // 二级选择
            changeChildrenTab (name) {
                this.childrenId = name;
            },
            // 提交表单 group
            onSubmit (formData) {
                request({
                    url: this.FromData.action,
                    method: this.FromData.method,
                    data: formData
                }).then(res => {
                    this.$Message.success(res.msg);
                }).catch(res => {
                    this.$Message.error(res.msg);
                });
            }
        }
    }
</script>

<style scoped lang="stylus">
.fromBox
    /*>>> .ivu-form-item-label*/
       /*width 155px !important*/
    /*>>> .ivu-form-item-content*/
       /*margin-left 155px !important*/
</style>
