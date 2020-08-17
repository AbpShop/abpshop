<template>
    <div class="table_box">
        <Form ref="orderData" :model="orderData" :label-width="labelWidth" :label-position="labelPosition" class="tabform" @submit.native.prevent>
            <Row :gutter="24" type="flex" justify="end">
                <Col span="24" class="ivu-text-left">
                        <FormItem label="订单状态：">
                            <RadioGroup v-model="orderData.status" type="button"  @on-change="selectChange2(orderData.status)">
                                <Radio label="">全部 {{  '(' +orderChartType.all?orderChartType.all:0 + ')' }}</Radio>
                                <Radio label="0">未支付 {{  '(' +orderChartType.unpaid?orderChartType.unpaid:0+ ')' }}</Radio>
                                <Radio label="1">未发货 {{  '(' +orderChartType.unshipped?orderChartType.unshipped:0+ ')' }}</Radio>
                                <Radio label="2">待收货 {{  '(' +orderChartType.untake?orderChartType.untake:0+ ')' }}</Radio>
                                <Radio label="3">待评价 {{  '(' +orderChartType.unevaluate?orderChartType.unevaluate:0+ ')' }}</Radio>
                                <Radio label="4">交易完成 {{  '(' +orderChartType.complete?orderChartType.complete:0+ ')' }}</Radio>
                                <Radio label="5">待核销 {{  '(' +orderChartType.write_off?orderChartType.write_off:0+ ')' }}</Radio>
                                <Radio label="-1">退款中 {{  '(' +orderChartType.refunding?orderChartType.refunding:0+ ')' }}</Radio>
                                <Radio label="-2">已退款 {{  '(' +orderChartType.refund?orderChartType.refund:0+ ')' }}</Radio>
                                <Radio label="-4">已删除 {{  '(' +orderChartType.del?orderChartType.del:0+ ')' }}</Radio>
                            </RadioGroup>
                        </FormItem>
                    </Col>
                <Col span="24" class="ivu-text-left">
                    <FormItem label="创建时间：">
                        <DatePicker @on-change="onchangeTime" :value="timeVal" format="yyyy/MM/dd"
                                    type="datetimerange" placement="bottom-start" placeholder="自定义时间"
                                    style="width: 300px;" class="mr20" :options="options"></DatePicker>
                    </FormItem>
                </Col>
                <Col span="24">
                    <Col v-bind="grid" class="mr">
                        <FormItem label="订单号：" prop="real_name" label-for="real_name">
                            <Input v-model="orderData.real_name" search enter-button placeholder="请输入" element-id="name" @on-search="orderSearch(orderData.real_name)" />
                        </FormItem>
                    </Col>
                    <!--<Col v-bind="grid">-->
                        <!--<Button class="mr">导出</Button>-->
                        <!--<span class="Refresh" @click="Refresh">刷新</span><Icon type="ios-refresh" />-->
                    <!--</Col>-->
                </Col>
                <Col span="24">
                    <Button v-auth="['order-dels']" class="mr10" type="primary" @click="delAll">批量删除订单</Button>
                    <Button v-auth="['order-write']" type="success" class="ml20 mr10 greens" size="default" @click="writeOff">
                        <Icon type="md-list"></Icon>
                        订单核销
                    </Button>
                    <Button class="export" icon="ios-share-outline" @click="exports">导出</Button>
                </Col>
            </Row>
        </Form>
        <!--订单核销模态框-->
        <Modal v-model="modals2" title="订单核销"  class="paymentFooter"  scrollable width="400">
            <Form ref="writeOffFrom" :model="writeOffFrom"  :rules="writeOffRules"   :label-position="labelPosition" class="tabform" @submit.native.prevent>
                <FormItem  prop="code" label-for="code">
                    <Input search enter-button="验证" style="width: 100%;" type="text" placeholder="请输入12位核销码" @on-search="search('writeOffFrom')" v-model.number="writeOffFrom.code" number/>
                </FormItem>
            </Form>
            <div slot="footer">
                <Button type="primary"  @click="ok">立即核销</Button>
                <Button @click="del('writeOffFrom')">取消</Button>
            </div>
        </Modal>
    </div>
</template>

<script>
    import { mapState, mapMutations } from 'vuex';
    import { putWrite, storeOrderApi } from '@/api/order';
    export default {
        name: 'table_from',
        data () {
            const codeNum = (rule, value, callback) => {
                if (!value) {
                    return callback(new Error('请填写核销码'));
                }
                // 模拟异步验证效果
                if (!Number.isInteger(value)) {
                    callback(new Error('请填写12位数字'));
                } else {
                    const reg = /[0-9]{12}/;
                    if (!reg.test(value)) {
                        callback(new Error('请填写12位数字'));
                    } else {
                        callback();
                    }
                }
            };
            return {
                fromList: {
                    title: '选择时间',
                    custom: true,
                    fromTxt: [
                        { text: '全部', val: '' },
                        { text: '今天', val: 'today' },
                        { text: '昨天', val: 'yesterday' },
                        { text: '最近7天', val: 'lately7' },
                        { text: '最近30天', val: 'lately30' },
                        { text: '本月', val: 'month' },
                        { text: '本年', val: 'year' }
                    ]
                },
                currentTab: '',
                grid: {
                    xl: 8,
                    lg: 8,
                    md: 8,
                    sm: 24,
                    xs: 24
                },
                // 搜索条件
                orderData: {
                    status: '',
                    data: '',
                    real_name: ''
                },
                modalTitleSs: '',
                statusType: '',
                time: '',
                value2: [],
                isDelIdList: [],
                writeOffRules: {
                    code: [
                        { validator: codeNum, trigger: 'blur', required: true }
                    ]
                },
                writeOffFrom: {
                    code: '',
                    confirm: 0
                },
                modals2: false,
                timeVal: [],
                options: {
                    shortcuts: [
                        {
                            text: '今天',
                            value () {
                                const end = new Date();
                                const start = new Date();
                                start.setTime(new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate()));
                                return [start, end];
                            }
                        },
                        {
                            text: '昨天',
                            value () {
                                const end = new Date();
                                const start = new Date();
                                start.setTime(start.setTime(new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() - 1)));
                                end.setTime(end.setTime(new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate())));
                                return [start, end];
                            }
                        },
                        {
                            text: '最近7天',
                            value () {
                                const end = new Date();
                                const start = new Date();
                                start.setTime(start.setTime(new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() - 6)));
                                return [start, end];
                            }
                        },
                        {
                            text: '最近30天',
                            value () {
                                const end = new Date();
                                const start = new Date();
                                start.setTime(start.setTime(new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() - 29)));
                                return [start, end];
                            }
                        },
                        {
                            text: '本月',
                            value () {
                                const end = new Date();
                                const start = new Date();
                                start.setTime(start.setTime(new Date(new Date().getFullYear(), new Date().getMonth(), 1)));
                                return [start, end];
                            }
                        },
                        {
                            text: '本年',
                            value () {
                                const end = new Date();
                                const start = new Date();
                                start.setTime(start.setTime(new Date(new Date().getFullYear(), 0, 1)));
                                return [start, end];
                            }
                        }
                    ]
                }
            }
        },
        computed: {
            ...mapState('admin/layout', [
                'isMobile'
            ]),
            ...mapState('admin/order', [
                'orderChartType',
                'isDels',
                'delIdList'
            ]),
            labelWidth () {
                return this.isMobile ? undefined : 80;
            },
            labelPosition () {
                return this.isMobile ? 'top' : 'right';
            },
            today () {
                const end = new Date();
                const start = new Date();
                var datetimeStart = start.getFullYear() + '/' + (start.getMonth() + 1) + '/' + start.getDate();
                var datetimeEnd = end.getFullYear() + '/' + (end.getMonth() + 1) + '/' + end.getDate();
                return [datetimeStart, datetimeEnd];
            }
        },
        created () {
            // this.timeVal = this.today;
            // this.orderData.data = this.timeVal.join('-');
        },
        methods: {
            ...mapMutations('admin/order', [
                'getOrderStatus',
                'getOrderTime',
                'getOrderNum'
            ]),
            // 导出
            exports () {
                let formValidate = this.orderData;
                let data = {
                    status: formValidate.status,
                    data: formValidate.data,
                    real_name: formValidate.real_name
                };
                storeOrderApi(data).then(res => {
                    location.href = res.data[0];
                }).catch(res => {
                    this.$Message.error(res.msg)
                })
            },
            // 具体日期
            onchangeTime (e) {
                this.timeVal = e;
                this.orderData.data = this.timeVal[0] ? this.timeVal.join('-') : '';
                this.$store.dispatch('admin/order/getOrderTabs', { data: this.orderData.data })
                this.getOrderTime(this.orderData.data);
                this.$emit('getList');
            },
            // 选择时间
            selectChange (tab) {
                this.$store.dispatch('admin/order/getOrderTabs', { data: tab })
                this.orderData.data = tab;
                this.getOrderTime(this.orderData.data);
                this.timeVal = [];
                this.$emit('getList');
            },
            // 订单选择状态
            selectChange2 (tab) {
                this.getOrderStatus(tab);
                this.$emit('getList');
            },
            // 时间状态
            timeChange (time) {
                this.getOrderTime(time);
                this.$emit('getList');
            },
            // 订单号搜索
            orderSearch (num) {
                this.getOrderNum(num);
                this.$emit('getList', 1);
            },
            // 点击订单类型
            onClickTab () {
                this.$emit('onChangeType', this.currentTab);
            },
            // 批量删除
            delAll () {
                if (this.delIdList.length === 0) {
                    this.$Message.error('请先选择删除的订单！');
                } else {
                    if (this.isDels) {
                        this.delIdList.filter(item => {
                            this.isDelIdList.push(item.id)
                        })
                        let idss = {
                            ids: this.isDelIdList
                        }
                        let delfromData = {
                            title: '删除订单',
                            url: `/order/dels`,
                            method: 'post',
                            ids: idss
                        };
                        this.$modalSure(delfromData).then((res) => {
                            this.$Message.success(res.msg);
                            this.tabList();
                        }).catch(res => {
                            this.$Message.error(res.msg);
                        });
                    } else {
                        const title = '错误！';
                        const content = '<p>您选择的的订单存在用户未删除的订单，无法删除用户未删除的订单！</p>';
                        this.$Modal.error({
                            title: title,
                            content: content
                        });
                    }
                }
            },
            // 订单核销
            writeOff () {
                this.modals2 = true;
            },
            // 验证
            search (name) {
                this.$refs[name].validate((valid) => {
                    if (valid) {
                        putWrite(this.writeOffFrom).then(async res => {
                            if (res.status === 200) {
                                this.$Message.success(res.msg);
                                this.modals2 = false;
                                this.$refs[name].resetFields();
                                this.$emit('getList');
                            } else {
                                this.$Message.error(res.msg);
                            }
                        }).catch(res => {
                            this.$Message.error(res.msg);
                        })
                    } else {
                        this.$Message.error('Fail!');
                    }
                })
            },
            // 订单核销
            ok () {
                if (!this.writeOffFrom.code) {
                    this.$Message.warning('请先验证订单！');
                } else {
                    this.writeOffFrom.confirm = 1;
                    putWrite(this.writeOffFrom).then(async res => {
                        if (res.status === 200) {
                            this.$Message.success(res.msg);
                            this.modals2 = false;
                            this.$refs[name].resetFields();
                            this.$emit('getList');
                        } else {
                            this.$Message.error(res.msg);
                        }
                    }).catch(res => {
                        this.$Message.error(res.msg);
                    })
                }
            },
            del (name) {
                this.modals2 = false;
                this.$refs[name].resetFields();
            },
            handleSubmit () {
                this.$emit('on-submit', this.data);
            },
            // 刷新
            Refresh () {
                this.$emit('getList');
            },
            //
            handleReset () {
                this.$refs.form.resetFields();
                this.$emit('on-reset');
            }
        }
    }
</script>

<style scoped lang="stylus">
  .tab_data >>> .ivu-form-item-content
    margin-left 0 !important
  .table_box >>> .ivu-divider-horizontal
    margin-top 0px !important
  .table_box >>> .ivu-form-item
      margin-bottom: 15px !important;
  .tabform
     margin-bottom 10px
  .Refresh
     font-size 12px
     color #1890FF
     cursor pointer
</style>
