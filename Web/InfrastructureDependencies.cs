using Application.Repositories;
using Application.UnitOfWork;
using Domain.Entities.OutboxMessage;
using Domain.Entities.WorkItem;
using Infrastructure;
using Infrastructure.BackgroundJobs;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Web;

public class InfrastructureDependencies
{
    public static void MapDependencies(IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<CascadeManagementDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        services.AddScoped<IOutboxMessageRepository, OutboxMessageRepository>();
        services.AddScoped<IQueryRepository<TaskItem>, QueryRepository<TaskItem>>();
        services.AddScoped<IQueryRepository<OutboxMessage>, QueryRepository<OutboxMessage>>();
        
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