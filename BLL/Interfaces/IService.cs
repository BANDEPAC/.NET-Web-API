using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void DeleteById(int id);
        T FindById(int id);
        List<T> GetAll();

    }
}
