import low from 'lowdb';
import LocalStorage from 'lowdb/adapters/LocalStorage';

const adapter = new LocalStorage('admin');
const db = low(adapter);

db
    .defaults({
        sys: {},
        database: {}
    })
    .write();

export default db;
