<template>
    <div class="Box">
        <Card>
            <div class="ft">注意：当前采集方式为免费采集，受到淘宝店铺影响需要登陆才可以访问商品详情，可能会导致采集程序不稳定，都属于正常现象，尽情谅解，后期会开发出付费接口采集保证稳定采集！</div>
            <div>链接格式说明： 输入以http或https开头的淘宝、天猫、1688、京东的商品详情页网址，网址正确且商品信息存在时才能入库成功。生成的商品默认是没有上架的，请手动上架商品！轮播图选中的颜色是绿色边框的请注意。</div>
        </Card>
        <Form class="formValidate mt20" ref="formValidate" :model="formValidate" :rules="ruleInline" :label-width="labelWidth" :label-position="labelPosition" @submit.native.prevent>
            <Row :gutter="24" type="flex">
                <Col span="24">
                    <FormItem label="链接地址：">
                        <Input search enter-button="确定"  v-model="soure_link" placeholder="请输入链接地址"  @on-search="add"/>
                    </FormItem>
                </Col>
                <div>
                    <div v-if="isData">
                        <Col span="24">
                            <FormItem label="商品名称：" prop="store_name">
                                <Input v-model="formValidate.store_name" placeholder="请输入商品名称" />
                            </FormItem>
                        </Col>
                        <Col span="24">
                            <FormItem label="商品简介：" prop="store_info" label-for="store_info">
                                <Input v-model="formValidate.store_info" type="textarea" :rows="3" placeholder="请输入商品简介"/>
                            </FormItem>
                        </Col>
                        <Col span="24">
                            <FormItem label="商品分类：" prop="cate_id">
                                <Select v-model="formValidate.cate_id" multiple>
                                    <Option v-for="item in treeSelect" :disabled="item.pid === 0" :value="item.id" :key="item.id">{{ item.html + item.cate_name }}</Option>
                                </Select>
                            </FormItem>
                        </Col>
                        <Col v-bind="grid">
                            <FormItem label="商品关键字：" prop="keyword" label-for="keyword">
                                <Input v-model="formValidate.keyword" placeholder="请输入商品关键字"  />
                            </FormItem>
                        </Col>
                        <Col v-bind="grid">
                            <FormItem label="单位：" prop="unit_name" label-for="unit_name">
                                <Input v-model="formValidate.unit_name"  placeholder="请输入单位" />
                            </FormItem>
                        </Col>
                        <Col v-bind="grid">
                            <FormItem label="虚拟销量："  label-for="ficti">
                                <InputNumber v-width="'100%'" v-model="formValidate.ficti" placeholder="请输入虚拟销量"  />
                            </FormItem>
                        </Col>
                        <Col v-bind="grid">
                            <FormItem label="积分："  label-for="give_integral">
                                <InputNumber v-width="'100%'" v-model="formValidate.give_integral" placeholder="请输入积分" />
                            </FormItem>
                        </Col>
                        <Col v-bind="grid">
                            <FormItem label="运费模板：" prop="temp_id">
                                <Select v-model="formValidate.temp_id">
                                    <Option v-for="item in templateList" :value="item.id" :key="item.id">{{ item.name }}{{item.id}}</Option>
                                </Select>
                            </FormItem>
                        </Col>
                        <!--<Col v-bind="grid">-->
                            <!--<FormItem label="邮费："  label-for="postage">-->
                                <!--<InputNumber v-width="'100%'" v-model="formValidate.postage" placeholder="请输入邮费"  />-->
                            <!--</FormItem>-->
                        <!--</Col>-->

                        <Col span="24">
                            <FormItem label="商品图：">
                                <div class="pictrueBox">
                                    <div class="pictrue" v-if="formValidate.image">
                                        <viewer><img v-lazy="formValidate.image"></viewer>
                                    </div>
                                </div>
                            </FormItem>
                        </Col>
                        <Col span="24">
                            <FormItem label="商品轮播图：">
                                <viewer>
                                    <div class="acea-row">
                                        <div class="lunBox mr15" v-for="(item,index) in formValidate.slider_image"
                                             :key="index"
                                             draggable="true"
                                             @dragstart="handleDragStart($event, item)"
                                             @dragover.prevent="handleDragOver($event, item)"
                                             @dragenter="handleDragEnter($event, item)"
                                             @dragend="handleDragEnd($event, item)">
                                            <div class="pictrue"><img v-lazy="item"></div>
                                            <ButtonGroup size="small">
                                                <Button @click.native="checked(item,index)">主图</Button>
                                                <Button @click.native="handleRemove(index)">移除</Button>
                                            </ButtonGroup>
                                        </div>
                                    </div>
                                </viewer>
                            </FormItem>
                        </Col>
                        <Col span="24">
                            <FormItem label="商品规格：" props="spec_type" label-for="spec_type">
                                <!-- 单规格表格-->
                                <Col :xl="23" :lg="24" :md="24" :sm="24" :xs="24">
                                    <FormItem >
                                        <Table :data="items" :columns="columns" border>
                                            <template slot-scope="{ row, index }" slot="pic">
                                                <div class="acea-row row-middle row-center-wrapper" @click="modalPicTap('dan')">
                                                    <div class="pictrue pictrueTab" v-if="images"><img v-lazy="images"></div>
                                                    <div class="upLoad upLoadTab acea-row row-center-wrapper" v-else>
                                                        <Icon type="ios-camera-outline" size="26" class="iconfont"/>
                                                    </div>
                                                </div>
                                            </template>
                                            <template slot-scope="{ row, index }" slot="price">
                                                <InputNumber  v-model="formValidate.price"  class="priceBox"></InputNumber>
                                            </template>
                                            <template slot-scope="{ row, index }" slot="cost">
                                                <InputNumber  v-model="formValidate.cost"  class="priceBox"></InputNumber>
                                            </template>
                                            <template slot-scope="{ row, index }" slot="ot_price">
                                                <InputNumber  v-model="formValidate.ot_price"  class="priceBox"></InputNumber>
                                            </template>
                                            <template slot-scope="{ row, index }" slot="stock">
                                                <InputNumber  v-model="formValidate.stock"  class="priceBox"></InputNumber>
                                            </template>
                                            <template slot-scope="{ row, index }" slot="bar_code">
                                                <Input  v-model="formValidate.bar_code"></Input>
                                            </template>
                                        </Table>
                                    </FormItem>
                                </Col>
                            </FormItem>
                        </Col>
                        <Col span="24">
                            <FormItem label="商品详情：">
                                <vue-ueditor-wrap v-model="formValidate.description"  @beforeInit="addCustomDialog"  :config="myConfig"  style="width: 100%;"></vue-ueditor-wrap>
                            </FormItem>
                        </Col>
                        <Col span="24">
                            <FormItem >
                                <Button type="primary" :loading="modal_loading" class="submission" @click="handleSubmit('formValidate')">提交</Button>
                            </FormItem>
                        </Col>
                    </div>
                    <Spin size="large" fix v-if="spinShow"></Spin>
                </div>
            </Row>
        </Form>
        <Modal v-model="modalPic" width="60%" scrollable  footer-hide closable title='上传商品图' :mask-closable="false" :z-index="99999">
            <uploadPictures :isChoice="isChoice" @getPic="getPic"  :gridBtn="gridBtn" :gridPic="gridPic" v-if="modalPic"></uploadPictures>
        </Modal>
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    import { crawlFromApi, treeListApi, crawlSaveApi, productGetTemplateApi } from '@/api/product';
    import VueUeditorWrap from 'vue-ueditor-wrap';
    import uploadPictures from '@/components/uploadPictures';
    export default {
        name: 'taoBao',
        data () {
            return {
                modal_loading: false,
                images: '',
                soure_link: '',
                tableData: [
                    {
                        pic: '',
                        price: 0,
                        cost: 0,
                        ot_price: 0,
                        stock: 0,
                        bar_code: ''
                    }
                ],
                modalPic: false,
                isChoice: '',
                spinShow: false,
                gridPic: {
                    xl: 6,
                    lg: 8,
                    md: 12,
                    sm: 12,
                    xs: 12
                },
                gridBtn: {
                    xl: 4,
                    lg: 8,
                    md: 8,
                    sm: 8,
                    xs: 8
                },
                columns: [
                    {
                        title: '图片',
                        slot: 'pic',
                        align: 'center',
                        minWidth: 80
                    },
                    {
                        title: '售价',
                        slot: 'price',
                        align: 'center',
                        minWidth: 120
                    },
                    {
                        title: '成本价',
                        slot: 'cost',
                        align: 'center',
                        minWidth: 140
                    },
                    {
                        title: '原价',
                        slot: 'ot_price',
                        align: 'center',
                        minWidth: 140
                    },
                    {
                        title: '库存',
                        slot: 'stock',
                        align: 'center',
                        minWidth: 140
                    },
                    {
                        title: '商品编号',
                        slot: 'bar_code',
                        align: 'center',
                        minWidth: 140
                    }
                ],
                treeSelect: [],
                ruleInline: {
                    cate_id: [
                        { required: true, message: '请选择商品分类', trigger: 'change', type: 'array', min: '1' }
                    ],
                    temp_id: [
                        { required: true, message: '请选择运费模板', trigger: 'change' ,type:'number'}
                    ]
                },
                grid: {
                    xl: 8,
                    lg: 8,
                    md: 12,
                    sm: 24,
                    xs: 24
                },
                grid2: {
                    xl: 12,
                    lg: 12,
                    md: 12,
                    sm: 24,
                    xs: 24
                },
                myConfig: {
                    autoHeightEnabled: false, // 编辑器不自动被内容撑高
                    initialFrameHeight: 500, // 初始容器高度
                    initialFrameWidth: '100%', // 初始容器宽度
                    UEDITOR_HOME_URL: '/UEditor/',
                    serverUrl: 'http://35.201.165.105:8000/controller.php'
                },
                formValidate: {
                    store_name: '',
                    cate_id: [],
                    temp_id: '',
                    keyword: '',
                    unit_name: '',
                    store_info: '',
                    image: '',
                    slider_image: [],
                    description: '',
                    ficti: 0,
                    give_integral: 0,
                    is_show: 0,
                    price: 0,
                    cost: 0,
                    ot_price: 0,
                    stock: 0,
                    soure_link: '',
                    description_images: '',
                    postage: 0,
                    attrs: [],
                    items:[]
                },
                items: [
                    {
                        pic: '',
                        price: 0,
                        cost: 0,
                        ot_price: 0,
                        stock: 0,
                        bar_code: ''
                    }
                ],
                templateList: [],
                isData: false
            }
        },
        components: { VueUeditorWrap, uploadPictures },
        watch:{
            'formValidate.temp_id':function (n) {
                console.log('789');
                console.log(n);
                console.log('456');
            }
        },
        computed: {
            ...mapState('admin/layout', [
                'isMobile'
            ]),
            labelWidth () {
                return this.isMobile ? undefined : 120;
            },
            labelPosition () {
                return this.isMobile ? 'top' : 'right';
            }
        },
        created () {
            this.goodsCategory();
        },
        mounted () {
            this.productGetTemplate();
        },
        methods: {
            //获取运费模板；
            productGetTemplate () {
                productGetTemplateApi().then(res=>{
                    this.templateList = res.data;
                })
            },
            // 删除图片
            handleRemove (i) {
                this.formValidate.slider_image.splice(i, 1);
            },
            // 选择主图
            checked (item, index) {
                this.formValidate.image = item;
            },
            // 商品分类；
            goodsCategory () {
                treeListApi().then(res => {
                    this.treeSelect = res.data;
                }).catch(res => {
                    this.$Message.error(res.msg);
                })
            },
            // 生成表单
            add () {
                if (this.soure_link) {
                    var reg = /(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&:/~\+#]*[\w\-\@?^=%&/~\+#])?/;
                    if (!reg.test(this.soure_link)) {
                        return this.$Message.warning('请输入以http开头的地址！');
                    }
                    this.spinShow = true;
                    let data = {
                        link: this.soure_link
                    }
                    crawlFromApi(data).then(res => {
                        this.formValidate = res.data.info;
                        this.formValidate.soure_link = this.soure_link;
                        this.items = [
                            {
                                pic: this.formValidate.image,
                                price: this.formValidate.price,
                                cost: this.formValidate.cost,
                                ot_price: this.formValidate.ot_price,
                                stock: this.formValidate.stock,
                                bar_code: this.formValidate.bar_code
                            }
                        ];
                        this.images = this.formValidate.image;
                        this.isData = true;
                        this.spinShow = false;
                    }).catch(res => {
                        this.spinShow = false;
                        this.$Message.error(res.msg);
                    })
                } else {
                    this.$Message.warning('请输入链接地址！');
                }
            },
            // 提交
            handleSubmit (name) {
                this.$refs[name].validate((valid) => {
                    if (valid) {
                        this.modal_loading = true;
                        this.formValidate.attrs = [
                            {
                                pic: this.images,
                                price: this.formValidate.price,
                                cost: this.formValidate.cost,
                                ot_price: this.formValidate.ot_price,
                                stock: this.formValidate.stock,
                                bar_code: this.formValidate.bar_code
                            }
                        ];
                        this.formValidate.items = [];
                        crawlSaveApi(this.formValidate).then(res => {
                            this.$Message.success('商品默认为不上架状态请手动上架商品!');
                            setTimeout(() => {
                                this.modal_loading = false;
                            }, 500);
                            setTimeout(() => {
                                this.$emit('on-close');
                            }, 600);
                        }).catch(res => {
                            this.modal_loading = false;
                            this.$Message.error(res.msg);
                        })
                    } else {
                        if (!this.formValidate.cate_id) {
                            this.$Message.warning('请填写商品分类！');
                        }
                    }
                })
            },
            // 点击商品图
            modalPicTap (tit) {
                this.modalPic = true;
                this.isChoice = tit === 'dan' ? '单选' : '多选';
            },
            // 获取单张图片信息
            getPic (pc) {
                console.log(pc)
                this.images = pc.att_dir;
                this.modalPic = false;
            },
            handleDragStart (e, item) {
                this.dragging = item;
            },
            handleDragEnd (e, item) {
                this.dragging = null
            },
            // 首先把div变成可以放置的元素，即重写dragenter/dragover
            handleDragOver (e) {
                // e.dataTransfer.dropEffect="move";//在dragenter中针对放置目标来设置!
                e.dataTransfer.dropEffect = 'move'
            },
            handleDragEnter (e, item) {
                // 为需要移动的元素设置dragstart事件
                e.dataTransfer.effectAllowed = 'move'
                if (item === this.dragging) {
                    return
                }
                const newItems = [...this.formValidate.slider_image]
                const src = newItems.indexOf(this.dragging)
                const dst = newItems.indexOf(item)
                newItems.splice(dst, 0, ...newItems.splice(src, 1))
                this.formValidate.slider_image = newItems
            },
            // 添加自定义弹窗
            addCustomDialog (editorId) {
                window.UE.registerUI('test-dialog', function (editor, uiName) {
                    let dialog = new window.UE.ui.Dialog({
                        iframeUrl: '/admin/widget.images/index.html?fodder=dialog',
                        editor: editor,
                        name: uiName,
                        title: '上传图片',
                        cssRules: 'width:1200px;height:500px;padding:20px;'
                    });
                    this.dialog = dialog;
                    var btn = new window.UE.ui.Button({
                        name: 'dialog-button',
                        title: '上传图片',
                        cssRules: `background-image: url(../../../assets/images/icons.png);background-position: -726px -77px;`,
                        onclick: function () {
                            dialog.render();
                            dialog.open();
                        }
                    });
                    return btn;
                }, 37);
            }
        }
    }
</script>

<style scoped lang="stylus">
    .lunBox
        /*width 80px*/
        display flex
        flex-direction column
        border: 1px solid #0bb20c;
    .pictrueBox
        display inline-block;
    .pictrue
        width:85px;
        height:85px;
        border:1px dotted rgba(0,0,0,0.1);
        display: inline-block;
        position: relative;
        cursor: pointer;
        img
            width 100%
            height 100%
    .pictrueTab
        width:40px !important;
        height:40px !important;
    .upLoad {
        width: 40px;
        height: 40px;
        border: 1px dotted rgba(0, 0, 0, 0.1);
        border-radius: 4px;
        background: rgba(0, 0, 0, 0.02);
        cursor: pointer;
    }
    .ft
      color red

</style>
