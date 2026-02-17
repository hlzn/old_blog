<template>
    <div class="frontDoorStoryHero" v-if="props.story">
        <div class="frontDoorHeroContent">
            <img :src="props.story.previewImageSource" alt="story image" class="frontDoorStoryImg" />
            <div class="frontDoorTextContent">
                <h3 class="frontDoorHeroContentTitle">{{ props.story.title }}</h3>
                <i class="frontDoorHeroContentText">{{ story.createdAt }}</i>
                <p class="frontDoorHeroContentText">{{ props.story.preview }}</p>
            </div>
            
        </div>
    </div>
</template>

<script setup lang="ts">
    import type Story from '../../models/Story'
    
    const props = defineProps<{
        story: Story;
    }>();
</script>