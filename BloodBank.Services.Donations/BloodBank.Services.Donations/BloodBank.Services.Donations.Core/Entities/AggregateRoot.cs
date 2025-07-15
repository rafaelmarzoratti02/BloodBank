using BloodBank.Services.Donations.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Core.Entities;

public abstract class AggregateRoot : BaseEntity
{
    private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
    public Guid Id { get; protected set; }
    public IEnumerable<IDomainEvent> Events => _events;

    protected void AddEvent(IDomainEvent @event)
    {
        _events.Add(@event);
    }
}
