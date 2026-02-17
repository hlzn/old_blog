import type Section from "./Section";

export default interface Story {
    id: string;
    title: string;
    preview: string;
    previewImageSource: string;
    tags: string[];
    sections: Section[];
    content: string;
    createdAt: string;
}