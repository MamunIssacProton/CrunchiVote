import { useDispatch } from "react-redux";
import { addVote } from "../../Redux/Slices/VotesSlice";
import { VoteType } from "../../Enums/VoteType";
import GenerateGuid from "../../utils/GuidGenerator";

interface VotingProps
{
    commentId: string;
}

const VotingItem:React.FC<VotingProps>=({commentId})=>
{
    const dispatch=useDispatch();
    const handleUpVoteSubmit=()=>
    {
        dispatch(addVote
                    ({
                        commentId:commentId,
                        voteType:VoteType.UpVote,
                        voteId:GenerateGuid(),
                        givenBy:'pro'
                    })
                );
    }

    const handleDownVoteSubmit=()=>
    {
        dispatch(addVote
                    ({
                        commentId:commentId,
                        voteType:VoteType.DownVote,
                        voteId:GenerateGuid(),
                        givenBy:'pro'
                    })
                );
    }

    return(
        <label>
            
            <button onClick={handleUpVoteSubmit}>UpVote</button> &nbsp;
            <button onClick={handleDownVoteSubmit}>DownVote</button>
        </label>
    )
}

export default VotingItem;