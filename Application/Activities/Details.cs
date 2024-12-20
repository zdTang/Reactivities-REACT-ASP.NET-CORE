using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Result<Activity>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity=await _context.Activities.FindAsync(request.Id);
                // Here, it is not possible cause Error, if activity==Null, we accept it and leave it to the controllor to handle it.
                return Result<Activity>.Success(activity);  
                // we cannot return NotFound() here!
            }
        }
    }
}