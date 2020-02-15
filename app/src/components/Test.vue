<template>
  <div>
    <h1>xxx {{ msg }} xxx</h1>
    <ul>
      <li v-for="(item, index) in arr" :key="index">{{ index }}: {{ item }}</li>
    </ul>

    <ul>
      <li v-for="(value, name) in info" :key="name">{{ name }}: {{ value }}</li>
    </ul>

    <ul>
      <li v-for="(value, name) in audio" :key="name">
        {{ name }}: {{ value }}
      </li>
    </ul>
    {{ post }}
    {{ test }}
    <a href="http://command.com/sample/exitprogram">Close App</a>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import ChromelyService from "../services/ChromelyService";

@Component
export default class Test extends Vue {
  @Prop() private msg!: string;
  info = "";
  audio = "";
  post = "";
  test = "";

  arr = [1, 2, 3, 4, 5];

  Chromely = new ChromelyService();

  mounted() {
    this.Chromely.get<any>("/sample/demo").then(
      res => {
        this.audio = res;
      },
      err => {
        console.log(err);
      }
    );

    this.Chromely.get<any>("/info").then(
      res => {
        this.info = res;
      },
      err => {
        console.log(err);
      }
    );

    this.Chromely.post<any>("/sample/execute").then(
      res => {
        this.post = res;
      },
      err => {
        console.log(err);
      }
    );
  }
}
</script>

<style>
ul {
  text-align: left;
  margin-left: 20px;
}
</style>
