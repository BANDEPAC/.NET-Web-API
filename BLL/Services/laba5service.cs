using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.repositories;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class laba5service : Ilaba5Service<ProductDTO>
    {
        private readonly IRepository<Product> rep;
        private readonly IRepository<Category> repcat;
        private readonly IMapper _mapper;

        public laba5service(IRepository<Product> repository, IRepository<Category> _repcat, IMapper mapper)
        {
            rep = repository;
            repcat = _repcat;
            _mapper = mapper;
        }

        public int GetProductsByCategoryName(string name)
        {
            var totalPrice = rep.GetAll()
                .Where(p => repcat.GetAll()
                    .Any(c => c.CategoryId == p.CategoryId && c.Name == name))
                .Sum(p => p.Price);

            return totalPrice;
        }

    }
}