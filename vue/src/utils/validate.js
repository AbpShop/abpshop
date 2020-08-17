export function formatDate (date, fmt) {
    if (/(y+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, (date.getFullYear() + '').substr(4 - RegExp.$1.length));
    }
    let o = {
        'M+': date.getMonth() + 1,
        'd+': date.getDate(),
        'h+': date.getHours(),
        'm+': date.getMinutes(),
        's+': date.getSeconds()
    };
    for (let k in o) {
        if (new RegExp(`(${k})`).test(fmt)) {
            let str = o[k] + '';
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length === 1) ? str : padLeftZero(str));
        }
    }
    return fmt;
};

function padLeftZero (str) {
    return ('00' + str).substr(str.length);
}
// var padDate = function (value) {
//     return value < 10 ? '0' + value : value;
// };
// export function formatDate (value, fmt) {
//     console.log(value)
//     var date = new Date(value);
//     var year = date.getFullYear();
//     var month = padDate(date.getMonth() + 1);
//     var day = padDate(date.getDate());
//     var hours = padDate(date.getHours());
//     var minutes = padDate(date.getMinutes());
//     var seconds = padDate(date.getSeconds());
//     return year + '-' + month + '-' + day + '-' + ' ' + hours + ':' + minutes + ':' + seconds;
// };
