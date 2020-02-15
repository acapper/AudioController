<template>
  <div>
    <h1>Audio Devices</h1>
    <div v-for="(device, index) in audioDevices" :key="index">
      <ul v-for="(value, name) in device" :key="name" class="audio-device">
        <li>{{ name }}: {{ value }}</li>
      </ul>
      <hr />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import ChromelyService from "../services/ChromelyService";

@Component
export default class AudioDeviceList extends Vue {
  Chromely = new ChromelyService();

  audioDevices = "";

  mounted() {
    this.Chromely.get<any>("/audiodevices").then(
      res => {
        this.audioDevices = res;
      },
      err => {
        console.log(err);
      }
    );
  }
}
</script>

<style>
.audio-device {
  text-align: left;
}
</style>
