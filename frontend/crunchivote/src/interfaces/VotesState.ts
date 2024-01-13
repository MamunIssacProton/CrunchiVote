import { Vote } from "./Vote";

export interface VotesState
{
    votes:Record<string, Vote[]>;
    loading: boolean;
    error:string | null;
}

