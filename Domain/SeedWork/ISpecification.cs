using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.SeedWork
{
    public interface ISpecification<T>
    {
        bool AsNoTracking { get; }
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}