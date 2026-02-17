<template>
    <div id="frontDoorContent">
        <div class="contentContainer" v-if="selectedStory">
            <div class="titleBlock section">
                <h1 class="mainStoryHeader">{{ selectedStory?.title }}</h1>
                <i class="lblPostWrittenOn">{{ selectedStory?.createdAt }}</i>
            </div>
            <div class="section" v-for="(section, index) in (selectedStory?.sections)" :key="index">
                <p v-if="section.contentTypeId === BlogSectionContentType.Text">{{ section.content }}</p>
                <img v-if="section.contentTypeId === BlogSectionContentType.Image" :src="section.content" alt="Image content" />
                <video v-if="section.contentTypeId === BlogSectionContentType.Video" controls>
                    <source :src="section.content" type="video/mp4" />
                    Your browser does not support the video tag.
                </video>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { storeToRefs } from 'pinia';
import { useContentStore } from '../../stores/ContentStore';
import BlogSectionContentType from '../../models/BlogSectionContentType';

    const store = useContentStore();
    const { selectedStory } = storeToRefs(store);
</script>