using BuildingBlocks.Common;
using BuildingBlocks.Common.Response;

namespace BuildingBlocks.ApiResultWrapper;

public class Result<TValue>(
    bool isSuccess,
    string message,
    Error[] errors,
    TValue? value) : Result(isSuccess, message, errors)
{
    private readonly TValue? _value = value;

    public TValue? Data => _value;

    public static implicit operator Result<TValue>(TValue value)
        => Create(value);

    public static Result<TValue> Success(TValue value)
        => new(true, BaseMessages.OperationSuccessfulMessage.Text, [], value);

    private static Result<TValue> Create(TValue value)
    {
        return new Result<TValue>(true, BaseMessages.OperationSuccessfulMessage.Text, [], value);
    }
}