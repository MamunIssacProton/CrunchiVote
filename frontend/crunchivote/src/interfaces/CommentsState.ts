import { ArticleComment } from "./Comment";

export interface CommentsState
{
    comments:Record<string,ArticleComment[]>;
    loading:boolean;
    error:string | null;
}
