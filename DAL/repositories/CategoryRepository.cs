using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var category = Get(id);
            if (category != null)
            {
                _context.Category.Remove(category);   
                _context.SaveChanges();
            }
        }

        public Category Get(int id)
        {
            return _context.Category.Find(id);
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Category.AsQueryable().AsNoTracking();
        }

        public void Save(Category entity)
        {
            _context.Category.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Category entity)
        {
            _context.Category.Update(entity);
            _context.SaveChanges();
        }
    }
}
