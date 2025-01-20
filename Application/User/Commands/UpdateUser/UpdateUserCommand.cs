using Application.Exceptions;
using Domain.Entities;
using Infrastructure.Context;
using MediatR;

namespace Application.User.Commands.UpdateUser;

public record UpdateUserCommand(string Name, Guid Id): IRequest<Domain.Entities.User>
{}

public class UpdateUserCommandHandler(BankContext context) 
: IRequestHandler<UpdateUserCommand, Domain.Entities.User>
{
    private readonly BankContext _context = context;
    public async Task<Domain.Entities.User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = 
            await _context.Users.FindAsync(request.Id, cancellationToken)
            ?? throw new UserNotFoundError(request.Id);
        user.Name = request.Name;
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }
}