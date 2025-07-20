using BloodBank.Services.Donors.Core.Events;

namespace BloodBank.Services.Donors.Core;


public class AggregateRoot : BaseEntity
{
        private List<IDomainEvent> _events = new List<IDomainEvent>();
        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event) {
            if (_events == null)
                _events = new List<IDomainEvent>();

            _events.Add(@event);
        }
}
