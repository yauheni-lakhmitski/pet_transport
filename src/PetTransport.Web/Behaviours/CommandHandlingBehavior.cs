using MediatR;
using PetTransport.Domain;
using PetTransport.Infrastructure.Data;
using PetTransport.Web.Commands;

namespace PetTransport.Web.Behaviours
{
    public class CommandHandlingBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _applicationDbContext;

        public CommandHandlingBehavior(ApplicationDbContext applicationDbContext, IMediator mediator)
        {
            _mediator = mediator;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            if (request is ICommand)
            {
                var domainEntities = _applicationDbContext.ChangeTracker
                    .Entries<DomainEntity>()
                    .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

                var domainEvents = domainEntities
                    .SelectMany(x => x.Entity.DomainEvents)
                    .ToList();

                domainEntities.ToList()
                    .ForEach(entity => entity.Entity.ClearDomainEvents());

                foreach (var domainEvent in domainEvents)
                    await _mediator.Publish(domainEvent);
                
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }

            return response;
        }
    }
}
