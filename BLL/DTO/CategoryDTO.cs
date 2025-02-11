using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        // Конструктор без параметров
        public CategoryDTO() { }

        public CategoryDTO(int categoryId, string name, string description)
        {
            Id = categoryId;
            Name = name;
            Description = description;
        }
    }
}
