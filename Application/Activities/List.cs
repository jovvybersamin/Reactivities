﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> {}

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;

            public Handler(DataContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }
            
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                // try
                // {
                //     cancellationToken.ThrowIfCancellationRequested();
                //     for (int i = 0; i < 10; i++)
                //     {
                //         await Task.Delay(1000, cancellationToken);
                //         _logger.LogInformation($"Task {i} has been completed!");
                //     }
                // }
                // catch (Exception e) when (e is TaskCanceledException)
                // {
                //     _logger.LogInformation($"Task has been cancelled!");
                // }
                
                var activities = await _context.Activities.ToListAsync(cancellationToken);
                return activities;
            }
        }
    }
}