using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface Ilaba5Service<T> where T : class
    {
        int GetProductsByCategoryName(string name);   
    }
}
