using System;
using System.Linq;

namespace DoggyFoody.Services.Filter.Generic
{
    internal class FilterStrategy<TItem, TFilterParams>
    {
        public Predicate<TFilterParams> Condition
        {
            get;
            protected set;
        }

        public Func<IQueryable<TItem>, TFilterParams, IQueryable<TItem>> Mutator
        {
            get;
            protected set;
        }
    }
}
