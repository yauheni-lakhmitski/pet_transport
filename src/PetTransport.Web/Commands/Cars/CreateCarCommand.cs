using FluentValidation;
using MediatR;
using PetTransport.Domain.Entities;
using PetTransport.Infrastructure.Data;

namespace PetTransport.Web.Commands.Cars;

public record CreateCarCommand(string Make, string Model, string RegistrationNumber) : IRequest, ICommand;

public class CreateMenuItemCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateMenuItemCommandValidator()
    {
        RuleFor(x => x.Make).NotEmpty();
        RuleFor(x => x.Model).NotEmpty();
        RuleFor(x => x.RegistrationNumber).NotEmpty();
    }
}

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
{
    private readonly ApplicationDbContext _context;

    public CreateCarCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateCarCommand command, CancellationToken cancellationToken)
    {
        var car = new Car()
        {
            Make = command.Make,
            Model = command.Model,
            RegistrationNumber = command.RegistrationNumber
        };

        _context.Cars.Add(car);
        
        return Unit.Value;
    }
}
