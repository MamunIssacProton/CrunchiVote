import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { addComment } from '../store/features/ArticlesSlice';import { ArticleComment } from './Articles';

interface CommentFormProps {
  articleId: number;
}

const AddCommentComponent: React.FC<CommentFormProps> = ({ articleId }) => {
  const dispatch = useDispatch();
  const [commentInput, setCommentInput] = useState<string>('');

  const handleCommentSubmit = () => {
    if (commentInput.trim() === '') {
        
      return;
    }

    const newComment: ArticleComment = {
      commentId :`${genGenerateGuid()}`,
      username: 'pro',
      commentText: commentInput,
      votes: [],
    };
    console.log('adding comment : ',newComment);
    
    dispatch(addComment({ articleId, comment: newComment }));
    setCommentInput('');
  };

 
  return (
    <div className="vcontainer">
      <label>
        <textarea
          className="vtextbox"
          placeholder="Type your comment here"
          value={commentInput}
          onChange={(e) => setCommentInput(e.target.value)}
        />
      </label>
      <button onClick={handleCommentSubmit} className="vsend-button">
        Submit Comment
      </button>
    </div>
  );
};

export default AddCommentComponent;
function genGenerateGuid() {
    throw new Error('Function not implemented.');
}

