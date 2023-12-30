// src/components/NewsCard.tsx
import React from "react";

interface ArticleItemProps {
  heading: string;
  link: string;
  author: string;
  comments: { commentId: string; username: string; commentText: string; votes: [] }[];
}

const ArticleItem: React.FC<ArticleItemProps> = ({ heading, link, author, comments }) => {
  return (
    <div className="article-card">
      <h2>{heading}</h2>
      <p>Author: {author}</p>
      <a href={link} target="_blank" rel="noopener noreferrer">
        Read More
      </a>
      {comments.length > 0 && (
        <div>
          <h3>Comments:</h3>
          <ul>
            {comments.map((comment) => (
              <li key={comment.commentId}>
                <strong>{comment.username}:</strong> {comment.commentText}
              </li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
};

export default ArticleItem;
