import { ArticleComment } from "../../interfaces/Comment";

interface CommentItemProps
{
    comment: ArticleComment;
}

const CommentItem:React.FC<CommentItemProps>=({comment})=>
{
    return(
        <div>
            <p>{comment.commentText}</p>
           
        </div>
    )
}
export default CommentItem;