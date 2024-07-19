using BuildingBlocks.Common.Response;
using BuildingBlocks.Core.Common;
using BuildingBlocks.Core.Response;

namespace BuildingBlocks.Core.ApiResultWrapper;

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