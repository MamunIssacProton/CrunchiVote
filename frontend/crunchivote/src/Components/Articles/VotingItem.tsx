import { useDispatch } from "react-redux";
import { addVote } from "../../Redux/Slices/VotesSlice";
import { VoteType } from "../../Enums/VoteType";
import GenerateGuid from "../../utils/GuidGenerator";
import { useAuth } from "../Auth/AuthContext";
import { useState } from "react";
import * as API from '../../apis/CrunchiVoteApi';
import LoginPopup from "../LoginPopup";
interface VotingProps
{
    commentId: string;
}

const VotingItem:React.FC<VotingProps>=({commentId})=>
{
    const { token, isAuthenticated } = useAuth();
    const [showLoginPopup, setShowLoginPopup] = useState(false);
    const [message,setMesage]=useState('');
    const openLoginPopup = () => setShowLoginPopup(true);
    const closeLoginPopup = () => setShowLoginPopup(false);


    const dispatch=useDispatch();
    const handleUpVoteSubmit=async()=>
    {
        if (!isAuthenticated)
        {
           openLoginPopup();
           return;
        }

        const response= await API.AddVoteOnComment(commentId,VoteType.UpVote);
        if(response?.ok)
        {
            dispatch(addVote
                    ({
                        commentId:commentId,
                        voteType:VoteType.UpVote,
                        voteId:GenerateGuid(),
                        givenBy:''
                    }));
        }
        else
        {
            setMesage(`${response?.statusText}`);
        }
        setMesage('');
        
    }

    const handleDownVoteSubmit=async()=>
    {
        if (!isAuthenticated)
        {
           openLoginPopup();
           return;
        }

        const response= await API.AddVoteOnComment(commentId,VoteType.DownVote);
        if(response?.ok)
        {
            dispatch(addVote
                    ({
                        commentId:commentId,
                        voteType:VoteType.DownVote,
                        voteId:GenerateGuid(),
                        givenBy:''
                    }));
        }
        else
        {
            setMesage(`${response?.statusText}`);
        }
        setMesage('');
    }

    return(
        <>
            
            <button onClick={handleUpVoteSubmit}>UpVote</button> &nbsp;
            <button onClick={handleDownVoteSubmit}>DownVote</button>
            {showLoginPopup && !isAuthenticated && <LoginPopup onClose={closeLoginPopup} />}
        </>
    )
}

export default VotingItem;