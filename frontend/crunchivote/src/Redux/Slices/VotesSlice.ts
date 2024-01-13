import { PayloadAction, createSlice } from "@reduxjs/toolkit"
import { VotesState } from "../../interfaces/VotesState"
import { Vote } from "../../interfaces/Vote";
import { produce } from "immer";

const initialState:VotesState=
{
    votes: {},
    loading:false,
    error:null
}
const VotesSlice = createSlice({
    name: 'votes',
    initialState,
    reducers: {
      getVotesStart(state, action: PayloadAction<{ commentId: string }>) {
        state.loading = true;
        state.error = null;
        state.votes = produce(state.votes, (draft) => {
             draft[action.payload.commentId] = Object.values(draft[action.payload.commentId] || [])
            .filter((vote) => vote.commentId === action.payload.commentId);
        });
      },
  
      getVotesSuccess(state, action: PayloadAction<Vote[]>) {
        action.payload.forEach((vote) => {
          if (!state.votes[vote.commentId]) {
            state.votes[vote.commentId] = [];
          }
          state.votes[vote.commentId].push(vote);
        });
  
        state.loading = false;
        state.error = null;
      },
  
      getVotesFailure(state, action: PayloadAction<string>) {
        state.loading = false;
        state.error = action.payload;
      },
  
      addVote(state, action: PayloadAction<Vote>) {
        const { commentId } = action.payload;
        state.votes = produce(state.votes, (draft) => {
          if (!draft[commentId]) {
            draft[commentId] = [];
          }
          draft[commentId].push(action.payload);
        });
      },
    },
  });
  

export const
{
    getVotesStart,
    getVotesSuccess,
    getVotesFailure,
    addVote
} = VotesSlice.actions;

export default VotesSlice.reducer;