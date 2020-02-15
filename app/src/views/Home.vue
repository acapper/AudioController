<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <test msg="test" />
  </div>
</template>

<script>
import Test from "@/components/Test.vue";

export default {
  name: "Home",
  components: {
    Test
  }
};
</script>
