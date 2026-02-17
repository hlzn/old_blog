<template>
    <div id="frontDoorMainCanva">
        <FrontDoorHeader />
        <FrontDoorContent />
        <FrontDoorList />
    </div>
    <input type="range" min="20" max="80" step="10" v-model="sizeValue"  class="slider" id="panelsRange">
</template>

<script setup lang="ts">
import FrontDoorList from './FrontDoorList.vue'
import FrontDoorContent from './FrontDoorContent.vue'
import FrontDoorHeader from './FrontDoorHeader.vue'
import { ref, watch, onMounted } from 'vue';
import { useContentStore } from '../../stores/ContentStore';
import { useRoute } from 'vue-router';
const route = useRoute();
const sizeValue = ref(50);
const store = useContentStore();
watch(() => sizeValue.value, (value:number) => {
    const bg = document.querySelector(':root') as HTMLElement;
    bg.style.setProperty('--frontDoorLeftColumnWidth', value + '%');
    bg.style.setProperty('--frontDoorRightColumnWidth', (100 - value) + '%');
});
onMounted(() => {
  if (window.location.pathname === '/about') {
    store.fetchAbout();
  } else if (route.params.storyid) {
    store.fetchStory(route.params.storyid as string);
  }
  store.verifySelectedStory();
});
watch(
  () => route.params.storyid,
  (newVal, oldVal) => {
    if (newVal !== oldVal) {
      store.fetchStory(newVal as string);
    }
  }
);
</script>

<style>
@import url('./frontdoor-styles.css');
</style>