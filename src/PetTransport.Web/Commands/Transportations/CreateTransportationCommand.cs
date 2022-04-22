using FluentValidation;
using MediatR;
using PetTransport.Domain.Entities;
using PetTransport.Infrastructure.Data;

namespace PetTransport.Web.Commands.Transportations;

public record CreateTransportationCommand(string Title, string Name, string Description) : IRequest, ICommand;

public class CreateMenuItemCommandValidator : AbstractValidator<CreateTransportationCommand>
{
    public CreateMenuItemCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}

public class CreateTransportationCommandHandler : IRequestHandler<CreateTransportationCommand>
{
    private readonly ApplicationDbContext _context;

    public CreateTransportationCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateTransportationCommand command, CancellationToken cancellationToken)
    {
        var transportation = new Transportation()
        {
            Title = command.Title,
            Name = command.Name,
            Description = command.Description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        _context.Transportations.Add(transportation);
        
        return Unit.Value;
    }
}