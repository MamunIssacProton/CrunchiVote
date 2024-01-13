import { ArticleComment } from "../../interfaces/Comment";
import CommentItem from "./CommentItem";

interface CommentDataSource
{
    comments: ArticleComment[];
}

const CommentList:React.FC<CommentDataSource>=({comments})=>
{
    return(
       <div>
            {
                comments.map((comment)=>(
                
                    <CommentItem key={comment.commentId} comment={comment}></CommentItem>
                ))
                
            }
       </div>
    )    
}
export default CommentList;