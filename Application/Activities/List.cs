
using System.Collections.Generic;
using Domain;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Activities
{
    public class List

    {
        public class Query : IRequest<List<Activity>> { }
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            public Handler(DataContext context)// ILogger<List> logger
            {
                //_logger = logger;
                _context = context;
            }


            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {

              /*  try
                {

                    for (var i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation($"Task {i} has completed");

                    }

                }
                catch (Exception ex) when (ex is TaskCanceledException)
                {
                    _logger.LogInformation("Task was cancelled");



                }*/

                return await _context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}