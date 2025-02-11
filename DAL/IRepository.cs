using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T> where T : class
    {
        void Save(T entity);

        void Delete(int id);

        T Get(int id);

        void Update(T entity);
        
        IQueryable<T> GetAll();
    }
}
//System.InvalidOperationException: "Unable to resolve service for type 'DAL.IRepository`1[BLL.DTO.CategoryDTO]' while attempting to activate 'BLL.Services.CategoryService'."
