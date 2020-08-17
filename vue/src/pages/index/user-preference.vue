<template>
    <div>
        <div v-height="200">
            <user-gender />
        </div>
        <div v-height="210">
            <div class="dashboard-console-user-preference"></div>
        </div>
    </div>
</template>
<script>
    import userGender from './user-gender';
    export default {
        components: { userGender }
    }
</script>
<style lang="less">
    .dashboard-console-user-preference{
        height: 100%;
        //background-image: url("../../../assets/images/user-preference.png");
        background-repeat: no-repeat;
        background-size: cover;
        background-position: center;
    }
</style>
