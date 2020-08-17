import util from '@/libs/util';
import Setting from '@/setting';

class Socket {
    constructor () {
        this.ws = null;
        this.socketStatus = false;
    }

    close () {
        console.log('ws close');
        clearInterval(this.timer);
        this.ws.close();
    }

    onOpen () {
        console.log('ws open');
        let that = this;
        this.send({
            type: 'login',
            data: util.cookies.get('token')
        }).then(() => {
            that.ping();
        });
        this.vm.$emit('socket_open');
        this.socketStatus = true;
    }

    init (vm) {
        this.vm = vm;
        if (this.socketStatus === false) {
            try {
                let wsSocketUrl = Setting.wsSocketUrl;
                this.ws = new WebSocket(util.wss(wsSocketUrl));
                this.ws.onopen = this.onOpen.bind(this);
                this.ws.onerror = this.onError.bind(this);
                this.ws.onmessage = this.onMessage.bind(this);
                this.ws.onclose = this.onClose.bind(this);
            } catch (e) {

            }
        }
    }

    ping () {
        var that = this;
        this.timer = setInterval(function () {
            that.send({ type: 'ping' });
        }, 10000);
    }

    send (data) {
        return new Promise((resolve, reject) => {
            try {
                this.ws.send(JSON.stringify(data));
                resolve({ status: true });
            } catch (e) {
                reject({ status: false })
            }
        });
    }

    onMessage (res) {
        const { type, data = {} } = JSON.parse(res.data);
        this.vm.$emit(type, data);
    }

    onClose () {
        console.log('ws close 1');
        clearInterval(this.timer);
    }

    onError (e) {
        console.log(e);
        this.vm.$emit('socket_error', e);
    }
}

export default new Socket();
