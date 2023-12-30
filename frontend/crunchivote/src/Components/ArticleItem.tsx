import React, { useState } from "react";
import * as API from '../apis/CrunchiVoteApi';
import { useAuth } from "../Components/Auth/AuthContext";
import Auth from "../Components/AuthComponent";
import LoginPopup from "../Components/LoginPopup";
import CommentItem from "./CommentItem";


interface Comment {
  commentId: string;
  username: string;
  commentText: string;
  votes:[];
}

interface ArticleItemProps {
  id: number;
  heading: string;
  link: string;
  author: string;
  comments: Comment[];
}

const ArticleItem: React.FC<ArticleItemProps> = ({ id, heading, link, author, comments }) => {
  const { token, isAuthenticated } = useAuth();
  const [showLoginPopup, setShowLoginPopup] = useState(false);
  const [commentInput, setCommentInput] = useState<string>("");
  const[selectedArticleId, setArticleId]=useState<string>("");
  const openLoginPopup = () => setShowLoginPopup(true);
  const closeLoginPopup = () => setShowLoginPopup(false);
const[message,setMesage]=useState<string>("");
  const handleCommentSubmit = async (id:number) => {
  
    if (!isAuthenticated) {
      openLoginPopup();
      return;
    }

    try {
    
      var res= await API.postComment(commentInput,id);
      if(res?.ok)
      {
        setMesage("Successfuly saved the comment, please do reload manually")
      }
      setCommentInput("");
    } catch (error) {
      console.error("Error submitting comment:", error);
    }
  };

  return (
    <div className="news-card">
  <h4>{message}</h4>
      <h2>{heading}</h2>
      <p>Author: {author}</p>
      <a href={link} target="_blank" rel="noopener noreferrer">
          Read the post
      </a>

      {comments.length > 0 && (
        <div className="comments-section">
          <h3>Comments:</h3>
          <ul>
            {comments.map((comment) => (
              <li key={comment.commentId}>
                <CommentItem commentId={comment.commentId} commentText={comment.commentText} username={comment.username} votes={comment.votes}></CommentItem>
             
              </li>
            ))}
          </ul>
        </div>
      )}

   
        <div>
          <label>
            <textarea className="commentBox" placeholder="Type your comment here"
              value={commentInput}
              onChange={(e) => setCommentInput(e.target.value)}
            />
            
          </label>
          <button onClick={(e) => handleCommentSubmit(id)} className="btnSubmit">Submit Comment</button>
        </div>
   

      {showLoginPopup && !isAuthenticated && <LoginPopup onClose={closeLoginPopup} />}
    </div>
  );
};

export default ArticleItem;
