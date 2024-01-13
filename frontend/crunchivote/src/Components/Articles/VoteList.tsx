import { Vote } from "../../interfaces/Vote";

interface VotesDataSource
{
    votes:Vote[];
}
const VoteList:React.FC<VotesDataSource>=({votes})=>
{

    return(
        <div>
            <label>Total votes count {votes.length}</label>
        </div>
    )
}
export default VoteList;