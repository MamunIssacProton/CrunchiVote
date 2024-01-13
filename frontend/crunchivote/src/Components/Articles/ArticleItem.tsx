import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../Store";
import { useEffect } from "react";
import { getCommentsStart, getCommentsSuccess, getCommentsFailure } from "../../Redux/Slices/CommentsSlice";
import { Article } from "../../interfaces/Article";
import CommentList from "./CommentList";
import CommentForm from "./CommentForm";

interface ArticleItemProps
{
    articleId:number,
    article:Article;
}

const ArticleItem:React.FC<ArticleItemProps>=({articleId,article})=>
{
    const dispatch=useDispatch();
    const comments=useSelector((state:RootState)=> state.comment.comments[articleId] || article.comments || []);


    useEffect(()=>
    {
        dispatch(getCommentsStart({articleId}));
        
        

    },[dispatch,articleId]);

    return(
        <div>
            <h1>{article.heading}</h1>
            <h4>{article.author}</h4>
            <CommentForm articleId={article.id}></CommentForm>
             <h6>comments: </h6>
                   
          <CommentList key={article.id} comments={comments}></CommentList>
            
            
        </div>
    )
}


export default ArticleItem;