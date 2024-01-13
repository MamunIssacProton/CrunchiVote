import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { CommentsState } from "../../interfaces/CommentsState";
import { ArticleComment } from "../../interfaces/Comment";
const initialState:CommentsState=
{
    comments:{},
    loading:false,
    error:null
}
const CommentsSlice=createSlice
({
    name:'comments',
    initialState,
    reducers:
    {
        getCommentsStart(state, action:PayloadAction<{articleId:number}>)
        {
            state.loading=true;
            state.error=null;
            const filteredComments = Object.values(state.comments)
            .flatMap((comments) => comments)
            .filter((comment) => comment.articleId === action.payload.articleId);
    
            state.comments = { [action.payload.articleId]: filteredComments };
        },

        
        getCommentsSuccess(state,action:PayloadAction<ArticleComment[]>)
        { 
            action.payload.forEach((comment) => {
                
                if(!state.comments[comment.commentId])
                {
                    state.comments[comment.commentId]=[];
                }
                state.comments[comment.commentId].push(comment);
            });
            state.loading=false;
            state.error=null;
        },

        getCommentsFailure(state,action:PayloadAction<string>)
        {
            state.loading=false;
            state.error=action.payload;
        },

        addComment(state, action: PayloadAction<ArticleComment>)
        {
            
            if(!state.comments[action.payload.articleId])
            {
                state.comments[action.payload.articleId]=[];
            }
            state.comments[action.payload.articleId].push(action.payload);
        }


    },
});


export const
{
    getCommentsStart,
    getCommentsSuccess,
    getCommentsFailure,
    addComment
}=CommentsSlice.actions;

export default CommentsSlice.reducer;