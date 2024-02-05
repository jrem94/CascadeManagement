using Application.DataProviderInterfaces;
using Domain.Entities.OutboxMessage;
using Domain.Entities.WorkItem;
using Quartz;

namespace Infrastructure.BackgroundJobs;

public sealed class OutboxMessageReaderJob : IJob
{
    private readonly IOutboxMessageRepository _outboxMessageRepository;
    private readonly IQueryableDataSource _queryableDataSource;
    private readonly IUnitOfWork _unitOfWork;
    
    public OutboxMessageReaderJob(IOutboxMessageRepository outboxMessageRepository, IUnitOfWork unitOfWork,
        IQueryableDataSource queryableDataSource)
    {
        _outboxMessageRepository = outboxMessageRepository;
        _queryableDataSource = queryableDataSource;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Execute(IJobExecutionContext context)
    {
        var messages = await _queryableDataSource
            .Query<OutboxMessage>($"select * from OutboxMessage");

        foreach (var currentMessage in messages)
        {
            Console.WriteLine($"Read {currentMessage.Type} message {currentMessage.Id}: {currentMessage.Content}");
            
            _outboxMessageRepository.Delete(currentMessage);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}