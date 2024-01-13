import { Article } from "./Article";

export interface ArticleState
{
    articles:Article[];
    loading: boolean;
    error: string | null;
}