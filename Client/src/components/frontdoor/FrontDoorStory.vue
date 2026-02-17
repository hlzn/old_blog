<template>
    <div class="frontDoorStory" v-if="exists()" @click="$emit('selectedStory', props.story)">
        <div class="frontDoorTextContent">
            <h3>{{ props.story.title }}</h3>
            <i>{{ props.story.createdAt }}</i>
            <p>{{ props.story.preview }}</p>
        </div>
        <img :src="props.story.previewImageSource" alt="story image" class="frontDoorStoryImg" />
    </div>
</template>

<script setup lang="ts">
    import { storeToRefs } from 'pinia';
    import type Story from '../../models/Story'
    import { useContentStore } from '../../stores/ContentStore';
    //import type Selectable from '../../models/Selectable';
    
    const props = defineProps<{
        story: Story;
    }>();
    const store = useContentStore();
    const {categories} = storeToRefs(store);
    const exists = function() {
        const selected = categories.value.filter(c => c.selected).map(c => c.name);
        return props.story.tags.some(c => selected.includes(c));
    }
</script>