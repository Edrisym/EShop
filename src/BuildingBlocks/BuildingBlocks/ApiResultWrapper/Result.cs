using BuildingBlocks.Common;
using BuildingBlocks.Common.Response;

namespace BuildingBlocks.ApiResultWrapper;

public class Result
{
    public Result(bool isSuccess,
        string message, Error[] errors)
    {
        ValidateInput(isSuccess, message, errors);
        IsSuccess = isSuccess;
        Message = message;
        Errors = errors;
    }

    public bool IsSuccess { get; private set; }
    public string Message { get; private set; } = string.Empty;
    public Error[] Errors { get; private set; } = [];

    public static Result Success()
        => new(true, BaseMessages.OperationSuccessfulMessage.Text, []);

    public static Result Failure(Error error)
        => new(false, BaseMessages.OperationFailedMessage.Text, [error]);

    public static Result ValidationFailure(Error[] errors)
        => new(false, BaseMessages.SomeValuesAreInvalid.Text, errors);

    private static void ValidateInput(bool isSuccess, string message, Error[] errors)
    {
        if (isSuccess && errors.Length != 0 || !isSuccess && errors.Length == 0)
        {
            throw new InvalidOperationException();
        }

        ArgumentException.ThrowIfNullOrEmpty(message, nameof(message));
    }

    public static Result<T> Failure<T>(Error error)
        => new(false, BaseMessages.OperationFailedMessage.Text, [error], default!);
    
    // public static Result<T> Success<T>()
    //     => new(true, BaseMessages.OperationSuccessfulMessage.Text, [], default!);
    
        
    public static Result<T> Success<T>(T value)
        => new(true, BaseMessages.OperationSuccessfulMessage.Text, [], value ?? default!);
}