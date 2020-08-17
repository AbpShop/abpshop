import adminMock from './admin-mock';

const req = context => context.keys().map(context);
const options = req(require.context('./api/', true, /\.js$/))
    .filter(e => e.default)
    .map(e => e.default);

options.forEach(option => {
    adminMock.load(option);
});
