using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IRepository<T>
    {
        void Add(T obj);
        void Edit(T obj);
    }
}
