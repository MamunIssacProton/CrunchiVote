import { useDispatch, useSelector } from "react-redux";
import { ArticleComment } from "../../interfaces/Comment";
import VoteList from "./VoteList";
import VotingItem from "./VotingItem";
import { RootState } from "../../Store";
import { useEffect } from "react";
import { getVotesStart } from "../../Redux/Slices/VotesSlice";

interface CommentItemProps
{
    commentId:string;
    comment: ArticleComment;
}

const CommentItem:React.FC<CommentItemProps>=({commentId,comment})=>
{
    const dispatch=useDispatch();
    const votes=useSelector((state:RootState)=>
    {
        const stateVotes=state.vote.votes[commentId] || [];
        const persistedVotes=comment.votes || [];
        return [...stateVotes,...persistedVotes];
    })
   
    useEffect(()=>
    {
        dispatch(getVotesStart({commentId}));
    },[dispatch,commentId]);
    return(
        <div>
            <>{comment.commentText} &nbsp;&nbsp;&nbsp;

              <VotingItem commentId={comment.commentId}></VotingItem>
              <VoteList key={commentId} votes={votes}></VoteList>
            </>
            
            
            
             <hr></hr>
        </div>
    )
}
export default CommentItem;