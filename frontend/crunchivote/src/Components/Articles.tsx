// src/App.tsx
import React, { useEffect, useState } from "react";
import * as API from '../apis/ArticlesApi'
import ArticleItem from "./ArticleItem";

const Articles: React.FC = () => {
  const [data, setData] = useState<any[]>([]);

  useEffect(() => {
    const fetchDataFromApi = async () => {
      try {
        const apiData = await API.get(1);
        setData(apiData.data);
      } catch (error) {
        // Handle error
      }
    };

    fetchDataFromApi();
  }, []);

  return (
    <div className="App">
      <h1>Tech News</h1>
      {data.map((item) => (
        <ArticleItem
          key={item.id}
          heading={item.heading}
          link={item.link}
          author={item.author}
          comments={item.comments}
        />
      ))}
    </div>
  );
};

export default Articles;
