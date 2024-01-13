import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getArticlesStart, getArticlesSuccess, getArticlesFailure } from "../../Redux/Slices/ArticlesSlice";
import { getCommentsStart, getCommentsSuccess, getCommentsFailure } from "../../Redux/Slices/CommentsSlice";
import { RootState } from "../../Store";
import * as API from '../../apis/CrunchiVoteApi';
import { Article } from "../../interfaces/Article";
import CommentList from "./CommentList";
import CommentForm from "./CommentForm";
import { ArticleComment } from "../../interfaces/Comment";
import ArticleItem from "./ArticleItem";

const ArticleList: React.FC = () => {
    const dispatch = useDispatch();
    const articles = useSelector((state: RootState) => state.article.articles);
    const loading = useSelector((state: RootState) => state.article.loading);
    const error = useSelector((state: RootState) => state.article.error);

    useEffect(() => {
        const fetchData = async () => {
            try {
                dispatch(getArticlesStart());
                const response = await API.getArticles(1);
              
                dispatch(getArticlesSuccess(response.data));
              
            } catch (err) {
                dispatch(getArticlesFailure(String(err)));
            }
        };



        fetchData();
    }, [dispatch]);

    if (loading) {
        return <p>Loading articles...</p>;
    }

    if (error) {
        return <p>An error has occurred: {error}</p>;
    }
    if (!Array.isArray(articles)) {
        return <p>Articles data is not in the expected format.</p>;
    }
    return (
        <div className="listcontainer">
            {articles.map((article) => (
                <div key={article.id} className="listitem">
                   <ArticleItem articleId={article.id} article={article}></ArticleItem>
                  
                </div>
            
            ))}

            
        </div>
    );
};

export default ArticleList;
