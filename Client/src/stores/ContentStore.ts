import { defineStore } from "pinia";
import type Story from "../models/Story";
import type Selectable from "../models/Selectable";
import DefaultStory from "../models/DefaultStory";
const runningInDev = window.location.href.indexOf('localhost') !== -1;
const serverUrl = runningInDev ? "http://localhost:8080/" : "/";
export const useContentStore = defineStore('content', {
    state: () => ({
        stories: [] as Story[],
        aBlankStory: {} as Story,
        categories: [] as Selectable[],
        selectedStory: {} as Story | null,
        defaultStory: DefaultStory as Story,
        thereAreMoreStories: false,
        page: 0
    }),
    getters: {
    },
    actions: {
        async fetchStories() {
            const request = await fetch(`${serverUrl}api/blog/posts/${this.page}`);
            const response = await request.json();
            if (response.success) {
                //remove the first ekement of the array
                this.stories = [...this.stories, ...response.data];
                [... new Set(response.data.map((s:any) => s.tags ? [...s.tags] : []).flat())].forEach(tag => {
                    this.categories.push({
                        name: tag,
                        selected: true,
                    } as Selectable);
                });
                if (this.defaultStory == null) {
                    this.defaultStory = this.stories[0];
                }
                this.thereAreMoreStories = response.mightBeMore;
                if (!this.selectedStory?.id) {
                    this.selectedStory = this.stories[0];
                }
            }
        },
        verifySelectedStory() {
            if ((this.selectedStory == null || !this.selectedStory.id) && this.stories.length > 0) {
                this.selectedStory = this.stories[0];
            }
        },
        async fetchStory(id: string) {
            const request = await fetch(`${serverUrl}api/blog/post/${id}`);
            const response = await request.json();
            if (response.success) {
                this.selectedStory = response.data;
            }
        },
        async fetchAbout() {
            const request = await fetch(`${serverUrl}api/blog/about`);
            const response = await request.json();
            if (response.success) {
                this.selectedStory = response.data;
            }
        },
        async fetchMoreStories() {
            this.page++;
            await this.fetchStories();
        }
    },
});