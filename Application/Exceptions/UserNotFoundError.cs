namespace Application.Exceptions;

public class UserNotFoundError(Guid id): ApiMappedErrors("User Not found")
{
    public Guid Id = id;
}