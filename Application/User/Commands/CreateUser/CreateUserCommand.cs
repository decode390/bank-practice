using MediatR;
using Microsoft.Extensions.Logging;
using Infrastructure.Context;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Common.Interfaces;

namespace Application.User.Commands.CreateUser;

public class CreateUserCommand(string name): IRequest<Guid>
{
    /// <summary>
    ///     The name of the new user
    /// </summary>
    /// <example>New user name</example> 
    [Required]
    [MinLength(5)]
    public string Name {get; set;} = name;
}

public class CreateUserCommandHandler(
        ILogService<CreateUserCommandHandler> logger,
        BankContext context
    )
    : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly ILogService<CreateUserCommandHandler> _logger = logger;
    private readonly BankContext _context = context;
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.User{Name = request.Name};
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInfo("User created - Data: {data}", new {user.Id});
        return user.Id;
    }
}