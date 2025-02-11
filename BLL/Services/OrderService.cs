using BLL.DTO;
using BLL.Interfaces;
using DAL.models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL.Services
{
    public class OrderService : IService<OrderDTO>
    {
        private readonly IRepository<Order> _orderRepository; 
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper) 
        {
            _orderRepository = repository;
            _mapper = mapper;
        }

        public void Add(OrderDTO item)
        {
            var order = _mapper.Map<Order>(item); 
            _orderRepository.Save(order);
        }

        public void DeleteById(int id)
        {
            _orderRepository.Delete(id);
        }

        public OrderDTO FindById(int id)
        {
            var order = _orderRepository.Get(id);
            return _mapper.Map<OrderDTO>(order); 
        }

        public List<OrderDTO> GetAll()
        {
            return _orderRepository.GetAll()
                .Select(o => _mapper.Map<OrderDTO>(o)) 
                .ToList();
        }

        public void Update(OrderDTO item)
        {
            var order = _mapper.Map<Order>(item);
            _orderRepository.Update(order);
        }
    }
}