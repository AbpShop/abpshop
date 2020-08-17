<template>
    <div class="Modal">
        <Row class="colLeft">
            <Col :xl="6" :lg="6" :md="6" :sm="6" :xs="24" class="colLeft">
                <div class="Nav">
                    <div class="input"><Input search enter-button placeholder="选择分类" v-model="uploadName.name" style="width: 90%;" @on-search="changePage"/></div>
                    <div class="trees-coadd">
                        <div class="scollhide">
                            <div class="trees">
                                <Tree :data="treeData" :render="renderContent" class="treeBox" ref="tree"></Tree>
                            </div>
                        </div>
                    </div>
                </div>
            </Col>
            <Col :xl="18" :lg="18" :md="18" :sm="18" :xs="24" class="colLeft">
                <div class="conter">
                    <div class="bnt acea-row row-middle">
                        <Col span="24" class="mb10">
                            <Button type="primary" :disabled="checkPicList.length===0" @click="checkPics" class="mr10">使用选中图片</Button>
                            <Upload :show-upload-list="false" :action="fileUrl" class="mr10 mb10"
                                    :before-upload="beforeUpload"
                                    :data="uploadData"
                                    :headers="header"
                                    :multiple="true"
                                    :on-success="handleSuccess"
                                    style="margin-top: 1px;display: inline-block">
                                <Button type="primary">上传图片</Button>
                            </Upload>
                            <Button type="success" @click.stop="add" class="mr10">添加分类</Button>
                            <Button type="error" class="mr10" :disabled="checkPicList.length===0"  @click.stop="editPicList('图片')">删除图片</Button>
                            <i-select :value="pids" placeholder="图片移动至" style="width:160px"  class="treeSel">
                                <i-option v-for="(item,index) of list" :value="item.value" :key="index" style="display: none;">
                                    {{ item.title }}
                                </i-option>
                                <Tree :data="treeData2" :render="renderContentSel" ref="reference" class="treeBox"></Tree>
                            </i-select>
                        </Col>
                    </div>
                    <div class="pictrueList acea-row">
                        <Row :gutter="24" class="conter">
                            <div v-show="isShowPic" class="imagesNo">
                                <Icon type="ios-images" size="60" color="#dbdbdb"/>
                                <span class="imagesNo_sp">图片库为空</span>
                            </div>
                            <div class="acea-row">
                                <div class="pictrueList_pic mr10 mb10" v-for="(item, index) in pictrueList" :key="index">
                                    <img :class="item.isSelect ? 'on': '' " v-lazy="item.satt_dir"
                                         @click.stop="changImage(item, index, pictrueList)"/>
                                </div>
                            </div>
                            <!--<Col class="mb20" v-bind="gridPic"-->
                                 <!--v-for="(item, index) in pictrueList" :key="index" >-->
                                <!--<div class="pictrueList_pic">-->
                                    <!--<img :class="item.isSelect ? 'on': '' " v-lazy="item.satt_dir"-->
                                         <!--@click.stop="changImage(item, index, pictrueList)"/>-->
                                <!--</div>-->
                            <!--</Col>-->
                        </Row>
                    </div>
                    <div class="footer acea-row row-between-wrapper">
                        <Page :total="total" show-elevator show-total @on-change="pageChange"
                              :page-size="fileData.limit"/>
                    </div>
                </div>
            </Col>
        </Row>
    </div>
</template>

<script>
    import { getCategoryListApi, createApi, fileListApi, categoryEditApi, moveApi } from '@/api/uploadPictures';
    import Setting from '@/setting';
    import util from '@/libs/util';
    export default {
        name: 'uploadPictures',
        // components: { editFrom },
        props: {
            isChoice: {
                type: String,
                default: ''
            },
            gridBtn: {
                type: Object,
                default: null
            },
            gridPic: {
                type: Object,
                default: null
            }
        },
        data () {
            return {
                spinShow: false,
                fileUrl: Setting.apiBaseURL + '/file/upload',
                modalPic: false,
                treeData: [],
                treeData2: [],
                pictrueList: [],
                uploadData: {}, // 上传参数
                checkPicList: [],
                uploadName: {
                    name: ''
                },
                FromData: null,
                isShow: false,
                treeId: 0,
                isJudge: false,
                buttonProps: {
                    type: 'default',
                    size: 'small'
                },
                fileData: {
                    pid: 0,
                    page: 1,
                    limit: 12
                },
                total: 0,
                pids: 0,
                list: [],
                modalTitleSs: '',
                isShowPic: false,
                header: {},
                ids: [] // 选中附件的id集合
            }
        },
        mounted () {
            this.getToken();
            this.getList();
            this.getFileList();
        },
        methods: {
            // 上传头部token
            getToken () {
                this.header['Authori-zation'] = 'Bearer ' + util.cookies.get('token');
            },
            // 树状图
            renderContent (h, { root, node, data }) {
                return h('div', {
                    style: {
                        display: 'inline-block',
                        width: '90%'
                    },
                    on: {
                        mouseenter: () => { this.onMouseOver(root, node, data) },
                        mouseleave: () => { this.onMouseOver(root, node, data) }
                    }
                }, [
                    h('span', [
                        h('span', {
                            style: {
                                cursor: 'pointer'
                            },
                            class: ['ivu-tree-title'],
                            on: {
                                click: (e) => { this.appendBtn(root, node, data, e) }
                            }
                        }, data.title)
                    ]),
                    h('span', {
                        style: {
                            display: 'inline-block',
                            float: 'right'
                        }
                    }, [
                        h('Button', {
                            props: Object.assign({}, this.buttonProps, {
                                icon: 'ios-add'
                            }),
                            style: {
                                marginRight: '8px',
                                display: data.flag ? 'inline' : 'none'
                            },
                            on: {
                                click: () => { this.append(root, node, data) }

                            }
                        }),
                        h('Button', {
                            props: Object.assign({}, this.buttonProps, {
                                icon: 'md-create'
                            }),
                            style: {
                                marginRight: '8px',
                                display: data.flag ? 'inline' : 'none'
                            },
                            on: {
                                click: () => { this.editPic(root, node, data) }
                            }
                        }),
                        h('Button', {
                            props: Object.assign({}, this.buttonProps, {
                                icon: 'ios-remove'
                            }),
                            style: {
                                display: data.flag ? 'inline' : 'none'
                            },
                            on: {
                                click: () => { this.remove(root, node, data, '分类') }
                            }
                        })
                    ])
                ]);
            },
            renderContentSel (h, { root, node, data }) {
                return h('div', {
                    style: {
                        display: 'inline-block',
                        width: '90%'
                    }
                }, [
                    h('span', [
                        h('span', {
                            style: {
                                cursor: 'pointer'
                            },
                            class: ['ivu-tree-title'],
                            on: {
                                click: (e) => { this.handleCheckChange(root, node, data, e) }
                            }
                        }, data.title)
                    ])
                ])
            },
            // 下拉树
            handleCheckChange (root, node, data, e) {
                this.list = []
                // this.pids = 0;
                let value = data.id;
                let title = data.title;
                this.list.push({
                    value,
                    title
                });
                if (this.ids.length) {
                    this.pids = value;
                    this.getMove();
                } else {
                    this.$Message.warning('请先选择图片');
                }
                let selected = this.$refs.reference.$el.querySelectorAll('.ivu-tree-title-selected');
                for (let i = 0; i < selected.length; i++) {
                    selected[i].className = 'ivu-tree-title';
                }
                e.path[0].className = 'ivu-tree-title  ivu-tree-title-selected';// 当前点击的元素
            },
            // 移动分类
            getMove () {
                let data = {
                    pid: this.pids,
                    images: this.ids.toString()
                }
                moveApi(data).then(async res => {
                    this.$Message.success(res.msg);
                    this.getFileList();
                    this.pids = 0;
                    this.checkPicList = [];
                    this.ids = [];
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            // 删除图片
            editPicList (tit) {
                this.tits = tit;
                let ids = {
                    ids: this.ids.toString()
                };
                let delfromData = {
                    title: '删除选中图片',
                    url: `file/file/delete`,
                    method: 'POST',
                    ids: ids
                };
                this.$modalSure(delfromData).then((res) => {
                    this.$Message.success(res.msg);
                    this.getFileList();
                    this.checkPicList = [];
                }).catch(res => {
                    this.$Message.error(res.msg);
                });
            },
            // 鼠标移入 移出
            onMouseOver (root, node, data) {
                event.preventDefault();
                data.flag = !data.flag
            },
            // 点击树
            appendBtn (root, node, data, e) {
                this.treeId = data.id;
                this.getFileList();
                let selected = this.$refs.tree.$el.querySelectorAll('.ivu-tree-title-selected');
                for (let i = 0; i < selected.length; i++) {
                    selected[i].className = 'ivu-tree-title';
                }
                e.path[0].className = 'ivu-tree-title  ivu-tree-title-selected';// 当前点击的元素
            },
            // 点击添加
            append (root, node, data) {
                this.treeId = data.id;
                this.getFrom();
            },
            // 删除分类
            remove (root, node, data, tit) {
                this.tits = tit;
                let delfromData = {
                    title: '删除 [ ' + data.title + ' ] ' + '分类',
                    url: `file/category/${data.id}`,
                    method: 'DELETE',
                    ids: ''
                };
                this.$modalSure(delfromData).then((res) => {
                    this.$Message.success(res.msg);
                    this.getList();
                    this.checkPicList = [];
                }).catch(res => {
                    this.$Message.error(res.msg);
                });
            },
            // 确认删除树
            // submitModel () {
            //     if (this.tits === '图片') {
            //         this.getFileList();
            //         this.checkPicList = [];
            //     } else {
            //         this.getList();
            //         this.checkPicList = [];
            //     }
            // },
            // 编辑树表单
            editPic (root, node, data) {
                this.$modalForm(categoryEditApi(data.id)).then(() => this.getList());
            },
            // 搜索分类
            changePage () {
                this.getList();
            },
            // 分类列表树
            getList () {
                let data = {
                    title: '全部图片',
                    id: ''
                };
                getCategoryListApi(this.uploadName).then(async res => {
                    this.treeData = res.data.list;
                    this.treeData.unshift(data);
                    this.treeData2 = [...this.treeData];
                    this.addFlag(this.treeData);
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            addFlag (treedata) {
                treedata.map(item => {
                    this.$set(item, 'flag', false)
                    item.children && this.addFlag(item.children)
                })
            },
            // 新建分类
            add () {
                this.treeId = 0;
                this.getFrom()
            },
            // 文件列表
            getFileList () {
                this.fileData.pid = this.treeId;
                fileListApi(this.fileData).then(async res => {
                    this.pictrueList = res.data.list;
                    if (this.pictrueList.length) {
                        this.isShowPic = false
                    } else {
                        this.isShowPic = true
                    }
                    this.total = res.data.count;
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            pageChange (index) {
                this.fileData.page = index;
                this.getFileList();
                this.checkPicList = [];
            },
            // 新建分类表单
            getFrom () {
                this.$modalForm(createApi({ id: this.treeId })).then(() => this.getList());
            },
            // 上传之前
            beforeUpload () {
                this.uploadData = {
                    pid: this.treeId
                }
                let promise = new Promise((resolve) => {
                    this.$nextTick(function () {
                        resolve(true);
                    });
                });
                return promise;
            },
            // 上传成功
            handleSuccess (res, file) {
                if (res.status === 200) {
                    this.$Message.success(res.msg);
                    this.getFileList();
                } else {
                    this.$Message.error(res.msg);
                }
            },
            // 关闭
            cancel () {
                this.$emit('changeCancel')
            },
            // 选中图片
            changImage (item, index, row) {
                let selectItem = '';
                this.$set(this.pictrueList[index], 'isSelect', item.isSelect === undefined ? true : !item.isSelect);
                selectItem = this.pictrueList.filter((item) => { return item.isSelect === true });
                this.checkPicList = selectItem;
                this.ids = [];
                this.checkPicList.map((item, index) => {
                    this.ids.push(item.att_id)
                });
            },
            // 点击使用选中图片
            checkPics () {
                if (this.isChoice === '单选') {
                    if (this.checkPicList.length > 1) return this.$Message.warning('最多只能选一张图片');
                    this.$emit('getPic', this.checkPicList[0]);
                } else {
                    this.$emit('getPicD', this.checkPicList);
                    console.log(this.checkPicList)
                }
            }
        }
    }
</script>

<style scoped lang="stylus">
    .selectTreeClass
        background:#d5e8fc;
    .treeBox
        width 100%
        height 100%
        >>> .ivu-tree-title-selected, .ivu-tree-title-selected:hover
             color #2D8cF0 !important
             background-color #fff !important
        >>> .ivu-btn-icon-only
            width 20px !important
            height 20px !important
        >>> .ivu-tree-title:hover
            color #2D8cF0 !important
            background-color #fff !important
    .pictrueList_pic
        width 120px
        height 120px
        cursor pointer
        img
          width 100%
          height 100%
    .trees-coadd
        width: 100%;
        border-radius: 4px;
        overflow: hidden;
        position: relative;
        .scollhide
            overflow-x: hidden;
            overflow-y: scroll;
            padding: 10px 0 10px 0;
            box-sizing: border-box;
            .trees
                width: 100%;
                max-height: 374px;
        .scollhide::-webkit-scrollbar
            display: none;
    .treeSel >>>.ivu-select-dropdown-list
        padding 0 5px!important
        box-sizing border-box
    .imagesNo
        display: flex;
        justify-content: center;
        flex-direction column
        align-items center
        margin: 65px 0;
        .imagesNo_sp
            font-size 13px
            color #dbdbdb
            line-height 3
    .Modal{
        width:100%;
        height 100%;background #fff !important;}
    .Nav{width:100%;border-right:1px solid #eee;}
    .colLeft{padding-right:0!important;height:100%;}
    .conter{width:99%; height:100%;}
    .conter .bnt{width:100%;padding: 0 13px 10px 15px;box-sizing border-box}
    .conter .pictrueList{padding-left:25px;width 100%;}
    .conter .pictrueList img{width:100%;border:2px solid #fff;}
    .conter .pictrueList img.on{border:2px solid #5FB878;}
    .conter .footer{padding:20px;}
</style>
