using BLL.DTO;
using BLL.Interfaces;
using DAL.models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL.Services
{
    public class CategoryService : IService<CategoryDTO>
    {
        private readonly IRepository<Category> _categoryRepository; 
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _categoryRepository = repository;
            _mapper = mapper;
        }

        public void Add(CategoryDTO item)
        {
            var category = _mapper.Map<Category>(item);
            _categoryRepository.Save(category);
        }

        public void DeleteById(int id)
        {
            _categoryRepository.Delete(id);
        }

        public CategoryDTO FindById(int id)
        {
            var category = _categoryRepository.Get(id);
            return _mapper.Map<CategoryDTO>(category); // Преобразование сущности в DTO
        }

        public List<CategoryDTO> GetAll()
        {
            return _categoryRepository.GetAll()
                .Select(c => _mapper.Map<CategoryDTO>(c)) // Преобразование сущностей в DTO
                .ToList();
        }

        public void Update(CategoryDTO item)
        {
            var category = _mapper.Map<Category>(item); // Преобразование DTO в сущность
            _categoryRepository.Update(category);
        }
    }
}