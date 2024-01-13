import {configureStore } from "@reduxjs/toolkit";
import ArticlesReducer from './Redux/Slices/ArticlesSlice';
import CommentsReducer from './Redux/Slices/CommentsSlice';
import VoteReducer from './Redux/Slices/VotesSlice'
import { useDispatch, TypedUseSelectorHook, useSelector } from "react-redux";

export const store = configureStore({
  reducer: {
    article: ArticlesReducer,
    comment: CommentsReducer,
    vote: VoteReducer
  }
});

export type RootState = ReturnType<typeof store.getState>;

export const useAppDispatch = () => useDispatch<typeof store.dispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
