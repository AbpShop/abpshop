import Vue from 'vue';
import VueI18n from 'vue-i18n';
import store from '@/store/index';

import Languages from '@/i18n/locale';

store.dispatch('admin/i18n/getLocale');

const locale = store.state.admin.i18n.locale;

Vue.use(VueI18n);

export default new VueI18n({
    locale,
    messages: Languages
});
