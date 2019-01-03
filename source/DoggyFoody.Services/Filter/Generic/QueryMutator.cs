using System.Linq;

namespace DoggyFoody.Services.Filter.Generic
{
    internal class QueryMutator<TItem, TFilterParams>
    {
        public FilterStrategy<TItem, TFilterParams> Filter { get; set; }

        public QueryMutator(FilterStrategy<TItem, TFilterParams> filterStrategy)
        {
            Filter = filterStrategy;
        }

        public IQueryable<TItem> ApplyFilter(TFilterParams filterParams, IQueryable<TItem> query)
            => (Filter?.Condition(filterParams) ?? false) ? Filter.Mutator(query, filterParams) : query;
    }
}
