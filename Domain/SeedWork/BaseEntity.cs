using MediatR;
using System;
using System.Collections.Generic;

namespace Domain.SeedWork
{
    public abstract class BaseEntity
    {
        private int? _requestedHashCode;
        private List<INotification> _domainEvents;

        public Guid Id { get; set; }
        public List<INotification> DomainEvents => _domainEvents;

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            if (_domainEvents is null) return;
            _domainEvents.Remove(eventItem);
        }

        public bool IsTransient => Id == default;

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            BaseEntity item = (BaseEntity)obj;
            if (item.IsTransient || IsTransient)
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient)
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31;
                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(BaseEntity left, BaseEntity right)
            => Equals(left, null) ? Equals(right, null) : left.Equals(right);

        public static bool operator !=(BaseEntity left, BaseEntity right)
            => !(left == right);
    }
}