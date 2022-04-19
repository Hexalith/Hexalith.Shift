﻿namespace Hexalith.Shift.Service;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

public class MicrosoftShiftWorker : BackgroundService
{
    private readonly ILogger<MicrosoftShiftWorker> _logger;

    public MicrosoftShiftWorker(ILogger<MicrosoftShiftWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}