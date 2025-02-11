using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace DAL.repositories
{
        public class OrderRepository : IRepository<Order>
        {
            private readonly AppDbContext _context;

            public OrderRepository(AppDbContext context)
            {
                _context = context;
            }

            public void Delete(int id)
            {
                var order = _context.Order.Find(id); 

                if (order != null)
                {
                    _context.Order.Remove(order);
                    _context.SaveChanges();
                }
            }

            public Order Get(int id)
            {
                return _context.Order
                    .Include(o => o.Product) 
                    .FirstOrDefault(o => o.OrderId == id);
            }

            public IQueryable<Order> GetAll()
            {
                return _context.Order
                    .Include(o => o.Product)
                    .AsNoTracking();
            }

            public void Save(Order entity)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Order.Add(entity);
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            public void Update(Order entity)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var existingOrder = _context.Order
                            .Include(o => o.Product) 
                            .FirstOrDefault(o => o.OrderId == entity.OrderId);

                        if (existingOrder != null)
                        {
                            _context.Product.RemoveRange(existingOrder.Product); 
                            existingOrder.Product = entity.Product; 
                            _context.SaveChanges();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    
}
