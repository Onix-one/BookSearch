import { Author } from "./author";

export interface Book {

    googleId: string;
    title: string;
    subtitle: string;
    authors: Author[];
    publishedDate: string;
    description: string;
    pageCount: number;
    smallThumbnail: string;
    thumbnail: string;
    language: string;
}