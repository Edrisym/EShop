using BuildingBlocks.ApiResultWrapper;
using BuildingBlocks.Common.Response;
using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviour;

public class ValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> _validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
    where TResponse : Result
{
    private static TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        if (typeof(TResult) == typeof(Result))
        {
            return (Result.ValidationFailure(errors) as TResult)!;
        }

        object validationResult = typeof(Result)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof(Result.ValidationFailure))!
            .Invoke(null, [errors])!;

        return (TResult)validationResult;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        Error[] errors = _validators
            .Select(validator => validator.Validate(request))
            .SelectMany(ValidationResult => ValidationResult.Errors)
            .Where(validationfailure => validationfailure is not null)
            .Select(failure => new Error(
                failure.ErrorCode,
                failure.ErrorMessage))
            .Distinct()
            .ToArray();

        if (errors.Length != 0)
        {
            return CreateValidationResult<TResponse>(errors);
        }

        return await next();
    }
}