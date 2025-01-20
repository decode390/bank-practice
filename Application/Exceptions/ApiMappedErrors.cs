namespace Application.Exceptions;

public abstract class ApiMappedErrors(string Message) : Exception(Message)
{}