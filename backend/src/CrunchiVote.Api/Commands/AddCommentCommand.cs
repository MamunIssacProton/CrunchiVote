namespace CrunchiVote.Api.Commands;

public record AddCommentCommand
{
    public  required  string Message { get; set; }
    
    public  required  int ArticleId { get; set; }
}