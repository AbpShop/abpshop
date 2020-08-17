import { tableDelApi } from '@/api/common';
export function modalSure (delfromData) {
    return new Promise((resolve, reject) => {
        this.$Modal.confirm({
            title: delfromData.title,
            content: `<p>确定要${delfromData.title}吗？</p><p>${delfromData.title}后将无法恢复，请谨慎操作！</p>`,
            loading: true,
            onOk: () => {
                setTimeout(() => {
                    this.$Modal.remove();
                    if (delfromData.success) {
                        delfromData.success.then(async res => {
                            resolve(res);
                        }).catch(res => {
                            reject(res)
                        })
                    } else {
                        tableDelApi(delfromData).then(async res => {
                            resolve(res);
                        }).catch(res => {
                            reject(res)
                        })
                    }
                }, 300);
            },
            onCancel: () => {
                this.$Message.info('取消成功');
            }
        });
    })
}
