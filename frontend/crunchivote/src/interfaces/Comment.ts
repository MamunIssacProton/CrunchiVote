import { Vote } from "./Vote";

export interface ArticleComment
{
    articleId:number,
    commentId: string,
    commentText: string,
    votes: Vote[]
}