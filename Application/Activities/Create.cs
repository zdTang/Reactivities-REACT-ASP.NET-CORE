using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Create
    {
        // the property of "command" is what we want to validate
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }
        /*================
        Here demo how to create Validator
        "Activity" is the type we want to validate
        ==================*/
        public class CommandValidator : AbstractValidator<Activity>
        {
            public CommandValidator()
            {
                RuleFor(x=>x.Title).NotEmpty();
            }
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
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
