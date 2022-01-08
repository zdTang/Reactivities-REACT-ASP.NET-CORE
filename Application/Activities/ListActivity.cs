using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class ListActivity
    {
        public class Query : IRequest<Result<List<Activity>>> { }  // A Marker Interface

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly DataContext _context;
            private readonly ILogger<ListActivity> _logger;
            public Handler(DataContext context, ILogger<ListActivity> logger)
            {
                _context = context;
                _logger = logger;
            }
            /// <summary>
            /// CancellationToken is used when the user cancel the request during the processing
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>

            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try {
                    for(var i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();  // when user cancel the request,it is triggered.
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation($"Task {i} has complated");
                    }
                }catch(Exception ex) when (ex is TaskCanceledException)
                {
                    _logger.LogInformation("Task was cancelled");
                }
                return Result<List<Activity>>.Success(await _context.Activities.ToListAsync(cancellationToken));
            }
        }
    }
}
