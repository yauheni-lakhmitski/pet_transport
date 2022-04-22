using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetTransport.Infrastructure.Data;

namespace PetTransport.Web.Commands.Transportations;

public record UpdateTransportationCommand(Guid Id, string Title, string Name, string Description) : IRequest, ICommand;


    public class UpdateTransportationCommandValidator : AbstractValidator<UpdateTransportationCommand>
{
    public UpdateTransportationCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}

public class UpdateTransportationCommandHandler : IRequestHandler<UpdateTransportationCommand>
{
    private readonly ApplicationDbContext _context;

    public UpdateTransportationCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTransportationCommand command, CancellationToken cancellationToken)
        {
        var transportation = await _context.Transportations.FirstOrDefaultAsync(x=>x.Id == command.Id, cancellationToken);

        transportation.Title = command.Title;
        transportation.Name = command.Name;
        transportation.Description = command.Description;

        _context.Transportations.Update(transportation);

        return Unit.Value;
    }
}
