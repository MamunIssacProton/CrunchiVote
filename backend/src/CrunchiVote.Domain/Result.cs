namespace CrunchVote.Domain;

public class Result
{
    private Result(bool isSuccess, Error error, dynamic? data=null)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
        Data = data;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }
    public dynamic Data { get;}
    public static Result Success() => new(true, Error.None);

    public static Result SucessWithData(dynamic data) => new(true, Error.None, data);
    public static Result Failure(Error error) => new(false, error);
    
}
