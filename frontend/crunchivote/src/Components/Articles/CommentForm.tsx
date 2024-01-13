import { useState } from "react";
import { useDispatch } from "react-redux";
import { addComment } from "../../Redux/Slices/CommentsSlice";
import GenerateGuid from "../../utils/GuidGenerator";

interface CommentFormProps

{
    articleId: number;
}

const CommentForm: React.FC<CommentFormProps>=({articleId})=>
    {
        const dispatch=useDispatch();
        const [newComment, setNewComment]=useState('');
        
        const handleCommentSubmit=()=>
        {
            const username="pro";
            dispatch(
                addComment({
                    articleId:articleId,
                    commentId: GenerateGuid(),
                    commentText:newComment,
                    votes:[]
                })
            );
        
            setNewComment('');
        }


        return(
            <div>
                <input type="text" value={newComment}
                onChange={(e)=>setNewComment(e.target.value)}
                placeholder="type your comment here"

                />
                <button className="vsend-button" onClick={handleCommentSubmit}>Post Comment</button>
            </div>
        )
    };

    export default CommentForm;