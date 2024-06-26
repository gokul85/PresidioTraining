﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected IList<T> items = new List<T>();
        public virtual T Add(T item)
        {
            items.Add(item);
            return item;
        }
        public virtual ICollection<T> GetAll()
        {
            return items.ToList<T>();
        }

        public abstract T Delete(K key);

        public abstract T GetByKey(K key);

        public abstract T Update(T item);

    }
}