using System.Collections.Generic;
using System.Linq;

namespace DoggyFoody.Services.Filter.Generic
{
    internal class QueryBuilder<TItem, TFilterParams>
    {
        public List<QueryMutator<TItem, TFilterParams>> Mutators { get; set; }

        public IQueryable<TItem>  ApplyFilters(TFilterParams filterParams, IQueryable<TItem> items)
        {
            foreach(var mutator in Mutators ?? Enumerable.Empty<QueryMutator<TItem, TFilterParams>>())
            {
                items = mutator.ApplyFilter(filterParams, items);
            }

            return items;
        }
    }
}
