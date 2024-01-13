import { ArticleComment } from "./Comment";

export interface Article{
    id:number,
    heading: string,
    link: string,
    author: string,
    comments: ArticleComment[]

}