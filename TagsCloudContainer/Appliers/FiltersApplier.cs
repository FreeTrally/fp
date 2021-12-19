﻿using TagsCloudContainer.Filters;
using TagsCloudContainer.Infrastructure.Settings;

namespace TagsCloudContainer.Appliers
{
    public class FiltersApplier : IFiltersApplier
    {
        private readonly IFilter[] filters;

        public FiltersApplier(Settings settings)
        {
            filters = settings.Filters;
        }

        public IEnumerable<string> ApplyFilters(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                if (filters.All(filter => filter.Allows(word)))
                    yield return word;
            }
        }
    }
}
