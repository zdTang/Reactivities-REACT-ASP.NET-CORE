using Application.Core;
using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Create
    {
        // the property of "command" is what we want to validate
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }
        /*================
        Here demo how to create Validator
        "Activity" is the type we want to validate
        // To be aware, the "Command" TYPE is upside.
        // Even comment out the following code, we can still validate
        // if we have defined a validate Class
        ==================*/
        // public class CommandValidator : AbstractValidator<Command>
        // {
        //     public CommandValidator()
        //     {
        //          // Notice the format
        //          RuleFor(x=>x.Activity).SetValidator(new ActivityValidator());
        //     }
        // }

        public class Handler : IRequestHandler<Command,Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to create activity");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
