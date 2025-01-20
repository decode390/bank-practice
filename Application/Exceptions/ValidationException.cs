using FluentValidation.Results;

namespace Application.Exceptions;

public class ValidationException(string Message, ValidationResult? result): ApiMappedErrors(Message)
{
    public ValidationResult? Result = result;
}