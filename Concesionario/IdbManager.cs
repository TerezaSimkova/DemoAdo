using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario
{
    interface IdbManager<T>
    {
        public List<T> Fetch();

        public List<T> FetchStaticList();

        public T GetById(int? id);
        public void Insert(T t);
        public void Delete(T t);
        public void Update(T t);
    }
}
