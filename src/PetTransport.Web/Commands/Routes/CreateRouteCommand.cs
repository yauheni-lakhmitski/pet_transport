// using FluentValidation;
// using MediatR;
// using PetTransport.Infrastructure.Data;
// using Route = PetTransport.Domain.Entities.Route;
//
// namespace PetTransport.Web.Commands.Routes;
//
// public record CreateRouteCommand(string Name, string Source, string Destination, string DriverId, Guid CarId, Guid TransportationId,
//     DateTime StartTime, DateTime EndTime) : IRequest, ICommand;
//
// public class CreateRouteCommandValidator : AbstractValidator<CreateRouteCommand>
// {
//     public CreateRouteCommandValidator()
//     {
//         RuleFor(x => x.Name).NotEmpty();
//         RuleFor(x => x.Source).NotEmpty();
//         RuleFor(x => x.Destination).NotEmpty();
//         RuleFor(x => x.CarId).NotEmpty();
//         RuleFor(x => x.DriverId).NotEmpty();
//         RuleFor(x => x.TransportationId).NotEmpty();
//         RuleFor(x => x.StartTime).NotEmpty();
//         RuleFor(x => x.EndTime).NotEmpty();
//     }
// }
//
// public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand>
// {
//     private readonly ApplicationDbContext _context;
//
//     public CreateRouteCommandHandler(ApplicationDbContext context)
//     {
//         _context = context;
//     }
//
//     public async Task<Unit> Handle(CreateRouteCommand command, CancellationToken cancellationToken)
//     {
//         var route = new Route()
//         {
//             Name = command.Name,
//             Source = command.Source,
//             Destination = command.Destination,
//             CarId = command.CarId,
//             TransportationId = command.TransportationId,
//             StartTime = command.StartTime,
//             EndTime = command.EndTime,
//             DriverId = command.DriverId
//         };
//
//         _context.Routes.Add(route);
//
//         return Unit.Value;
//     }
// }