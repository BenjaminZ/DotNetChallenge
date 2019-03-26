import '../css/index.css';
import Vue from "vue";

Vue.config.debug = true;

new Vue({
    el: `#app`,
    render: h => h(App)
});
