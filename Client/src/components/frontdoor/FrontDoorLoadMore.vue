<template>
    <div class="frontDoorLoadMore" v-if="thereAreMoreStories">
        <button @click="loadMore()" class="loadMoreButton">Load More</button>
    </div>
</template>

<script setup lang="ts">
import { storeToRefs } from 'pinia';
import { useContentStore } from '../../stores/ContentStore';

const store = useContentStore();
const { thereAreMoreStories } = storeToRefs(store);

const loadMore = async () => {
    await store.fetchMoreStories();
};
</script>