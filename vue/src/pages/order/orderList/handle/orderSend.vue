<template>
    <Modal v-model="modals" scrollable title="订单记录" class="order_box" :closable="false">
        <Form ref="formItem" :model="formItem" :rules="ruleValidate" :label-width="100" @submit.native.prevent>
            <FormItem label="选择类型：">
                <RadioGroup v-model="formItem.type" @on-change="changeRadio(formItem.type)">
                    <Radio label="1">发货</Radio>
                    <Radio label="2">送货</Radio>
                    <Radio label="3">虚拟</Radio>
                </RadioGroup>
            </FormItem>
            <div v-if="formItem.type==='1'">
                <FormItem label="快递公司：" prop="delivery_name">
                    <Select v-model="formItem.delivery_name" style="width:80%;">
                        <Option v-for="(item,i) in express" :value="item.value" :key="i">{{ item.value }}</Option>
                    </Select>
                </FormItem>
                <FormItem label="快递单号：" prop="delivery_id">
                    <Input v-model="formItem.delivery_id" placeholder="请输入快递单号" style="width:80%;"></Input>
                </FormItem>
            </div>
            <div v-if="formItem.type==='2'">
                <FormItem label="送货人姓名：" prop="sh_delivery_name">
                    <Input v-model="formItem.sh_delivery_name" placeholder="请输入送货人姓名" style="width:80%;"></Input>
                </FormItem>
                <FormItem label="送货人电话：" prop="sh_delivery_id">
                    <Input v-model="formItem.sh_delivery_id" placeholder="请输入送货人电话" style="width:80%;"></Input>
                </FormItem>
            </div>
        </Form>
        <div slot="footer">
            <Button type="primary" @click="putSend('formItem')">提交</Button>
            <Button @click="cancel('formItem')">取消</Button>
        </div>
    </Modal>
</template>

<script>
    import { getExpressData, putDelivery } from '@/api/order';
    export default {
        name: 'orderSend',
        props: {
            orderId: Number
        },
        data () {
            return {
                formItem: {
                    type: '1',
                    delivery_name: '',
                    delivery_id: '',
                    sh_delivery_name: '',
                    sh_delivery_id: ''
                },
                modals: false,
                express: [],
                ruleValidate: {
                    delivery_name: [
                        { required: true, message: '请选择快递公司', trigger: 'change' }
                    ],
                    sh_delivery_name: [
                        { required: true, message: '请输入送货人姓名', trigger: 'blur' }
                    ],
                    delivery_id: [
                        { required: true, message: '请输入快递单独', trigger: 'blur' }
                    ]
                }
            }
        },
        mounted () {
        },
        methods: {
            changeRadio (o) {
                switch (o) {
                case '1':
                    this.formItem.sh_delivery_name = '';
                    this.formItem.sh_delivery_id = ''
                    break;
                case '2':
                    this.formItem.delivery_name = '';
                    this.formItem.delivery_id = ''
                    break;
                default:
                    this.formItem = {
                        type: '3',
                        delivery_name: '',
                        delivery_id: '',
                        sh_delivery_name: '',
                        sh_delivery_id: ''
                    };
                    break;
                }
            },
            // 物流公司列表
            getList () {
                getExpressData().then(async res => {
                    this.express = res.data
                }).catch(res => {
                    this.loading = false;
                    this.$Message.error(res.msg);
                })
            },
            // 提交
            putSend (name) {
                let data = {
                    id: this.orderId,
                    datas: this.formItem
                };
                if (this.formItem.type == 3) {
                    putDelivery(data).then(async res => {
                        this.modals = false;
                        this.$Message.success(res.msg);
                        this.$refs[name].resetFields();
                        this.$emit('submitFail')
                    }).catch(res => {
                        this.$Message.error(res.msg);
                    })
                } else {
                    this.$refs[name].validate((valid) => {
                        if (valid) {
                            putDelivery(data).then(async res => {
                                this.modals = false;
                                this.$Message.success(res.msg);
                                this.$refs[name].resetFields();
                                this.$emit('submitFail')
                            }).catch(res => {
                                this.$Message.error(res.msg);
                            })
                        } else {
                            this.$Message.error('请填写信息');
                        }
                    })
                }
            },
            cancel (name) {
                this.modals = false;
                this.$refs[name].resetFields();
                this.formItem.type = '1';
            }
        }
    }
</script>

<style scoped>

</style>
