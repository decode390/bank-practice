using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;

namespace Application.MediatR;

public class ValidationBehavior<TRequest, TResponse> (IValidator<TRequest> validator)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public IValidator<TRequest> _validator = validator;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var result = await _validator.ValidateAsync(request, cancellationToken);
        if (!result.IsValid) 
            throw new Exceptions.ValidationException(
                $"{request.GetType()}",
                result
            );
        return await next();
    }
}