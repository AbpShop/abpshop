export default {
    methods: {
        tTitle (title) {
            if (title && title.indexOf('$t:') === 0) {
                return this.$t(title.split('$t:')[1]);
            } else {
                return title;
            }
        }
    }
}
