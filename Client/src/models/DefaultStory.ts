// export default interface Story {
//     title: string;
//     description: string;
//     content: string;
//     writer: string;
//     date: string;
//     imageLink: string;
//     categories: string[];
// }



const DefaultStory = {
    id: '0',
    title: 'Hugo',
    preview: 'I work with web applications',
    previewImageSource: './img/myphoto.jpg',
    tags: ['work','me'] as string[],
    sections: [],
    content: 'I work with web applications',
    createdAt: '02/04/2025'
};

export default DefaultStory;