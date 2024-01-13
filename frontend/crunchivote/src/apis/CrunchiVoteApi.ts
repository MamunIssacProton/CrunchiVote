import { log } from "console";
import { VoteType } from "../Enums/VoteType";

const BaseUrl = "http://localhost:5254";
export const getArticles = async (page:number) => {
  try {
    const response = await fetch(`${BaseUrl}/articles?page=${page}`);
    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const postComment=async(message:string, articleId:number)=>
{
  const postCommenturl=`${BaseUrl}/postcomment`;
  try {
    
    const response=await fetch(postCommenturl,{
      method:'POST',
      headers:{
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('authToken')}`
      },
      body:JSON.stringify({message,articleId})
    })
    return response;

  } catch (error) {
    console.log(error);
    
  }
}

export const AddVoteOnComment=async(commentId:string, voteType:VoteType)=>
{
  const voteOnCommenturl=`${BaseUrl}/AddVoteOnComment`;
  try {
    
    const response=await fetch(voteOnCommenturl,{
      method:'POST',
      headers:{
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('authToken')}`
      },
      body:JSON.stringify({commentId,voteType})
    })
    return response;

  } catch (error) {
    console.log(error);
    
  }
}
export const authenticate = async (email: string, password: string) => {
  const loginUrl = `${BaseUrl}/login`;

  try {
    const response = await fetch(loginUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ email, password }),
    });

    if (!response.ok) {
      throw new Error("Authentication failed");
    }

    const authData = await response.json();
    localStorage.clear();
    localStorage.setItem('authToken',authData.accessToken);
    localStorage.setItem('userName',email);
    return authData;
  } catch (error) {
    console.error("Authentication error:", error);
    throw error;
  }
};