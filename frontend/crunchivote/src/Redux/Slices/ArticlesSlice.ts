import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ArticleState } from "../../interfaces/ArticleState";
import { Article } from "../../interfaces/Article";
const initialState:ArticleState=
{
    articles:[],
    loading: false,
    error: null
};
const ArticleSlice=createSlice({
name:'articles',
initialState,
reducers:{
    getArticlesStart(state){
        state.loading=true;
        state.error=null;
    },
    getArticlesSuccess(state, action: PayloadAction<Article[]>)
    {
        state.articles=action.payload;
        state.loading=false;
        state.error=null;
    },
    getArticlesFailure(state, action: PayloadAction<string>)
    {
        state.loading=false;
        state.error=action.payload;
    },
},
});


export const
{
    getArticlesStart,
    getArticlesSuccess,
    getArticlesFailure
}=ArticleSlice.actions;
export default ArticleSlice.reducer;