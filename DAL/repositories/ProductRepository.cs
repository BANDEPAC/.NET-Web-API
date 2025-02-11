using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace DAL.repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var product = Get(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }
        }

        public Product Get(int id)
        {
            return _context.Product.Find(id);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Product.AsQueryable().AsNoTracking();
        }

        public void Save(Product entity)
        {
            _context.Product.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            _context.Product.Update(entity);
            _context.SaveChanges();
        }
    }
}
