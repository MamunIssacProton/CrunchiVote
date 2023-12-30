using System.Text.RegularExpressions;
using CrunchiVote.Api.Commands;
using CrunchVote.Domain;

namespace CrunchiVote.Api.InputValidators;

public static class AddCommentCommandValidator
{
    public static Result Validate (this  AddCommentCommand command)
    {
        return (command.ArticleId.IsValidAsArticleId(), command.Message.IsValid()) switch
        {
            (true, true) => Result.Success(),
            (false, _) => InputErrors.InvalidArticleId,
            (_, false) => InputErrors.InvalidComment
        };
    }
    
}
