import React, { useEffect, useState } from "react";
import * as API from '../apis/CrunchiVoteApi';
import ArticleItem from "./ArticleItem";

export interface ArticleComment {
  commentId: string;
  username: string;
  commentText: string;
  votes: [];
}

export interface NewsItem {
  id: number;
  heading: string;
  link: string;
  author: string;
  comments: ArticleComment[];
}

const Articles: React.FC = () => {
  const [data, setData] = React.useState<NewsItem[]>([]);
  const [showLoginPopup, setShowLoginPopup] = useState(false);
  const [loading, setLoading] = useState(true);
  const [currentArticlePage]=useState(1);
  useEffect(() => {
    const fetchDataFromApi = async () => {
      try {
        const apiData = await API.getArticles(currentArticlePage);
        setData(apiData.data);
      } catch (error) {
        // Handle error
      } finally {
        setLoading(false);
      }
    };

    fetchDataFromApi();
  }, []); 
  return (
    <div className="App">
      <h1>Crunchi Votes</h1>
      <div className="listcontainer">

      {loading ? (
        <p>Loading...</p>
      ) : (
        
        data.map((item) =><ArticleItem key={item.id} {...item} />
        
          
        )
         
      )}
      </div>
    </div>
  );
};

export default Articles;
