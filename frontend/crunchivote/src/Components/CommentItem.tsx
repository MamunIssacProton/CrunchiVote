import React ,{useState}from "react"
import { useAuth } from "./Auth/AuthContext";
import Auth from "./AuthComponent";
import * as API from '../apis/CrunchiVoteApi';
import LoginPopup from "./LoginPopup";
import { VoteType } from "../Enums/VoteType";

interface Vote{
    commentId:string;
    voteId:string;
    givenBy:string;
    voteType:VoteType
}
interface CommentItemProps
{
    commentId: string;
    username: string;
    commentText: string;
    votes: Vote[];
}
const CommentItem:React.FC<CommentItemProps>=({commentId,username,commentText,votes})=>{

    const { token, isAuthenticated } = useAuth();
    const [showLoginPopup, setShowLoginPopup] = useState(false);
    const [message,setMesage]=useState('');
    const openLoginPopup = () => setShowLoginPopup(true);
    const closeLoginPopup = () => setShowLoginPopup(false);
  
    const handleUpVoteSubmit = async (id:string) => {
      if (!isAuthenticated) {
        openLoginPopup();
        return;
      }
  
     
      try {
          var res=await API.AddVoteOnComment(id,VoteType.UpVote);
          if(res?.ok)
          {
            setMesage("vote has given , please do refresh!");
          }
      } catch (error) {
        
        console.error("Error submitting vote:", error);
      }
    };
    const handleDownVoteSubmit=async(id:string)=>{
        if(!isAuthenticated)
        {
            openLoginPopup();
            return;
        }
        try{
          var res=await API.AddVoteOnComment(id,VoteType.DownVote);
          if(res?.ok)
          {
            setMesage("vote has given , please do refresh!");
          }
        }
        catch(error)
        {
           
        }
    }

return(
    <div>
        <div >
            
              
            <section>
            <label className="commentMessage">{commentText}  </label>
            <label className="commentAuthor">by {username.split('@')[0]}</label>
           {votes.length>0}
           (
             <label>Total votes : {votes.length}</label>
           )
           
                  <button className="upVote" onClick={(e)=>handleUpVoteSubmit(commentId)} >UpVote</button>
                  <button className="downVote" onClick={(e)=>handleDownVoteSubmit(commentId)}>DownVote</button>
           
            </section>
            
        </div>
        {showLoginPopup && !isAuthenticated && <LoginPopup onClose={closeLoginPopup} />}
    </div>
)
};
export default CommentItem;