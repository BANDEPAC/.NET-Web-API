using BLL.DTO;
using BLL.Interfaces;
using DAL.models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL.Services
{
    public class SearchProductByBothCases : ISearchByName<ProductDTO>, ISearchByPrice<ProductDTO>, IService<ProductDTO>
    {
        private readonly IRepository<Product> _productRepository; 
        private readonly IMapper _mapper;

        public SearchProductByBothCases(IRepository<Product> repository, IMapper mapper)
        {
            _productRepository = repository;
            _mapper = mapper;
        }

        public void Add(ProductDTO item)
        {
            var product = _mapper.Map<Product>(item); 
            _productRepository.Save(product);
        }

        public void DeleteById(int id)
        {
            _productRepository.Delete(id);
        }

        public ProductDTO FindById(int id)
        {
            var product = _productRepository.Get(id);
            return _mapper.Map<ProductDTO>(product); 
        }

        public List<ProductDTO> GetAll()
        {
            return _productRepository.GetAll()
                .Select(p => _mapper.Map<ProductDTO>(p)) 
                .ToList();
        }

        public List<ProductDTO> SearchByName(string name)
        {
            return _productRepository.GetAll()
                .Where(p => p.Name.Contains(name))
                .Select(p => _mapper.Map<ProductDTO>(p)) 
                .ToList();
        }

        public List<ProductDTO> SearchByPrice(int price)
        {
            return _productRepository.GetAll()
                .Where(p => p.Price <= price)
                .Select(p => _mapper.Map<ProductDTO>(p)) 
                .ToList();
        }

        public void Update(ProductDTO item)
        {
            var product = _mapper.Map<Product>(item);
            _productRepository.Update(product);
        }
    }
}