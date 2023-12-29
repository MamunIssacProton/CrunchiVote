namespace CrunchiVote.Shared.DTOs;
public record CommentDTO(Guid CommentId, string Username, string CommentText, List<VoteDTO> Votes = null)
{
    public CommentDTO WithDefaults(Guid? commentId = null, string username = null, string commentText = null, List<VoteDTO> votes = null)
    {
        return this with
        {
            CommentId = commentId ?? Guid.Empty,
            Username = username ?? string.Empty,
            CommentText = commentText ?? string.Empty,
            Votes = votes ?? new List<VoteDTO>()
        };
    }
}

//
// public record CommentDTO(Guid commentId, string username, string comment, List<VoteDTO>()=null)
// {
//     public CommentDTO WithDefaults(Guid? commentId = null, string username = null, string comment = null, List<VoteDTO>)
//     {
//         return this with
//         {
//             commentId=Guid.Empty,
//             username=string.Empty,
//             comment=string.Empty,
//             Votes = votes ?? new List<VoteDTO>()
//         };
//     }
// }
// public class CommentDTO
// {
//     public  Guid commentId { get; set; }
//     
//     public  string username { get; set; }
//     
//     public  string comment { get; set; }
//      
// }
