<template>
    <div class="categoriesSticky">
        <ul class="frontDoorFilters">
            <li v-for="category in categories" :key="category.name" :class="category.selected ? 'activeCategory': '' " @click="toggleCategory(category)">
                {{ category.name }}
            </li>
            <li @click="resetCategories()">+reset</li>
        </ul>
    </div>
</template>

<script setup lang="ts">
import type Selectable from '../../models/Selectable';
import { storeToRefs } from 'pinia';
import { useContentStore } from '../../stores/ContentStore';
const store = useContentStore();
const { categories } = storeToRefs(store);
const toggleCategory = (category: Selectable) => {
    category.selected = !category.selected;
};
const resetCategories = () => {
    categories.value.forEach((category: Selectable) => {
        category.selected = true;
    });
};
</script>