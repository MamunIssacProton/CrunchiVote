import { useState } from "react";
import { useDispatch } from "react-redux";
import { addComment } from "../../Redux/Slices/CommentsSlice";
import GenerateGuid from "../../utils/GuidGenerator";
import { useAuth } from "../Auth/AuthContext";
import * as API from '../../apis/CrunchiVoteApi';
import LoginPopup from "../LoginPopup";
interface CommentFormProps

{
    articleId: number;
}

const CommentForm: React.FC<CommentFormProps>=({articleId})=>
    {

        const { token, isAuthenticated } = useAuth();
        const [showLoginPopup, setShowLoginPopup] = useState(false);
        const [message,setMesage]=useState('');
        const openLoginPopup = () => setShowLoginPopup(true);
        const closeLoginPopup = () => setShowLoginPopup(false);



        const dispatch=useDispatch();
        const [newComment, setNewComment]=useState('');
        
        const handleCommentSubmit= async()=>
        {
            if (!isAuthenticated)
             {
                openLoginPopup();
                return;
             }
             const response= await API.postComment(newComment,articleId);
             console.log('res',response);
             if(response?.ok)
             {
                dispatch(addComment
                    ({
                    articleId:articleId,
                    commentId: GenerateGuid(),
                    commentText:newComment,
                    votes:[]
                    }));

             }
             else
             {
               setMesage(`${response?.statusText}`);
             }
             
            setNewComment('');
            setMesage('');
        }


        return(
            <div>
                <input type="text" value={newComment}
                onChange={(e)=>setNewComment(e.target.value)}
                placeholder="type your comment here"

                />
                <button  onClick={handleCommentSubmit}>Post Comment</button>
           
                {showLoginPopup && !isAuthenticated && <LoginPopup onClose={closeLoginPopup} />}
            </div>
        )
    };

    export default CommentForm;