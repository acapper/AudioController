import Vue from "vue";
import VueRouter from "vue-router";
import AudioDevicesPage from "@/views/AudioDevicesPage.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "AudioDevicesPage",
    component: AudioDevicesPage
  }
];

const router = new VueRouter({
  routes
});

export default router;
