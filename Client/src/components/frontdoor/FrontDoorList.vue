<template>
    <div id="frontDoorList">
        <FrontDoorFilters :categories="categories" />
        <FrontDoorHero :story="stories.length ? stories[0] : store.aBlankStory" @click="makeThisTheSelectedStory(stories[0])" />
        <FrontDoorStory v-for="story in stories.slice(1)" :key="story.title" :story="story" @selectedStory="makeThisTheSelectedStory(story)" />
        <FrontDoorLoadMore />
    </div>
</template>

<script setup lang="ts">
    import { storeToRefs } from 'pinia';
    import { useContentStore } from '../../stores/ContentStore';
    import FrontDoorHero from './FrontDoorHero.vue';
    import FrontDoorStory from './FrontDoorStory.vue';
    import FrontDoorFilters from './FrontDoorFilters.vue';
    import FrontDoorLoadMore from './FrontDoorLoadMore.vue';
    import type Story from '../../models/Story';
    import { onMounted } from 'vue';
    import { useRouter } from 'vue-router';
    import BrowserUtilities from '../../utilities/BrowserUtilities';
    const store = useContentStore();
    const router = useRouter();

    onMounted(async () => {
        await store.fetchStories();
    });

    const {stories, categories} = storeToRefs(store);
    const makeThisTheSelectedStory = (story: Story) => {
        router.push({ path: '/story/' + story.id });
        BrowserUtilities.scrollToTopIfSmallScreen();
    };
</script>