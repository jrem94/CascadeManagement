using Application.Repositories;
using Application.UnitOfWork;
using Domain.Entities.OutboxMessage;
using Domain.Entities.WorkItem;
using Quartz;

namespace Infrastructure.BackgroundJobs;

public sealed class OutboxMessageReaderJob : IJob
{
    private readonly IOutboxMessageRepository _outboxMessageRepository;
    private readonly IQueryRepository<OutboxMessage> _queryRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public OutboxMessageReaderJob(IOutboxMessageRepository outboxMessageRepository, IUnitOfWork unitOfWork,
        IQueryRepository<OutboxMessage> queryRepository)
    {
        _outboxMessageRepository = outboxMessageRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Execute(IJobExecutionContext context)
    {
        var messages = await _queryRepository.GetAllAsync();

        foreach (var currentMessage in messages)
        {
            Console.WriteLine($"Read {currentMessage.Type} message {currentMessage.Id}: {currentMessage.Content}");
            
            _outboxMessageRepository.Delete(currentMessage);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}