using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Edit
    {
        /// <summary>
        ///  Command !!!!!
        /// </summary>
        public class Command:IRequest
        {
            public Activity Activity { set; get; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

             public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);

                activity.Title = request.Activity.Title ?? activity.Title;  // can use this approach to update one by one

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
