import { VoteType } from "../Enums/VoteType";

export interface Vote
{
    commentId: string,
    voteId: string,
    givenBy: string | '',
    voteType: VoteType
}