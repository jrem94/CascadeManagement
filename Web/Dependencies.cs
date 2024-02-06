using Application.InfrastructurePorts;
using Infrastructure;
using Infrastructure.BackgroundJobs;
using Infrastructure.DataProviders;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Web;

public static class Dependencies
{
    public static void MapDependencies(IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<CascadeManagementDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IQueryableDataSource, QueryableDataSource>();
        services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        services.AddScoped<IOutboxMessageRepository, OutboxMessageRepository>();
        
        services.AddQuartz(options =>
        {
            var key = JobKey.Create(nameof(OutboxMessageReaderJob));
            options
                .AddJob<OutboxMessageReaderJob>(key)
                .AddTrigger(trigger =>
                    trigger.ForJob(key).WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever())
                );
        });
        services.AddQuartzHostedService();
    }
}