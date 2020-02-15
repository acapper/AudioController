<template>
  <div>
    <AudioDeviceList />
  </div>
</template>

<script lang="ts">
import AudioDeviceList from "@/components/AudioDeviceList.vue";

export default {
  name: "AudioDevicesPage",
  components: {
    AudioDeviceList
  }
};
</script>

<style scoped></style>
