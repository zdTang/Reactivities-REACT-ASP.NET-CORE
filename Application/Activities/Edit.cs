using Application.Core;
using AutoMapper;
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
        public class Command:IRequest<Result<Unit>>
        {
            public Activity Activity { set; get; }
        }
        public class Handler : IRequestHandler<Command,Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

             public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);
                //activity.Title=request.Activity.Title??activity.Title;  // can use this approach to update one by one        
                if (activity == null) return null;
                _mapper.Map(request.Activity, activity);    //  Updating Activity
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Fail to update activity");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
