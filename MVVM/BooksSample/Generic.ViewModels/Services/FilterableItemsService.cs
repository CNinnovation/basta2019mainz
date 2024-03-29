﻿using System;
using System.Collections.Generic;

namespace GenericViewModels.Services
{
    public class FilterableItemsService<T> : ItemsService<T>, IFilterableItemsService<T>
        where T : class
    {
        public FilterableItemsService(ICommonServices<T> commonServices) 
            : base(commonServices)
        {
        }

        // contains all the unfiltered items from the service
        protected readonly List<T> _allItems = new List<T>();

        public Func<T, bool>? Filter { get; set; }

        public void ExecuteFilter()
        {
            // pass filtered items to the Items collection that is shared between views
            Items.Clear();
            foreach (var item in _allItems)
            {
                if (Filter == null)
                {
                    Items.Add(item);
                }
                else if (Filter(item))
                {
                    Items.Add(item);
                }
            }
        }
    }
}
