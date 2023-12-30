using CrunchiVote.Api.Commands;
using CrunchVote.Domain;

namespace CrunchiVote.Api.InputValidators;

public static class AddVoteCommandValidator
{
    public static Result Validate (this  AddVoteCommand command)
    {
        return (command.CommentId.IsValidAsCommentId(), command.VoteType.IsValidAsVoteType()) switch
        {
            (true, true) => Result.Success(),
            (false, _) => InputErrors.InvalidCommentId,
            (_, false) => InputErrors.InvalidVoteType
        };
    }
}