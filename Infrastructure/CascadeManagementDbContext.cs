using Domain.Entities.OutboxMessage;
using Domain.Entities.WorkItem;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class CascadeManagementDbContext : DbContext
{
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }
    
    public CascadeManagementDbContext(DbContextOptions<CascadeManagementDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskItemConfiguration());
        modelBuilder.ApplyConfiguration(new OutboundMessageConfiguration());
    }
}