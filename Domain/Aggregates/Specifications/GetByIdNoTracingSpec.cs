using Domain.SeedWork;
using System;

namespace Domain.Aggregates.Specifications
{
    internal sealed class GetByIdNoTracingSpec<T> : BaseSpecification<T> where T : BaseEntity
    {
        public GetByIdNoTracingSpec(Guid id) : base(x => x.Id == id)
        {
            AsNoTracking = true;
        }
    }
}