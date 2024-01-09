import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ArticleComment, NewsItem } from "../../Components/Articles";

interface NewsState
{
    articles: NewsItem[]
}
const initialState: NewsState={
   articles:[]
};

export const NewsSlice = createSlice({
    name: 'news',
    initialState,
    reducers: {
      addComment: (state, action: PayloadAction<{ articleId: number; comment: ArticleComment }>) => {
        const { articleId, comment } = action.payload;
        const article=state.articles.find((x) => x.id === articleId);
        article?.comments.push(comment);
      },
    },
  });
  export const { addComment } = NewsSlice.actions;
  
  export default NewsSlice.reducer;