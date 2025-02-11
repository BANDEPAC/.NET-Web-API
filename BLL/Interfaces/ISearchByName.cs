using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISearchByName<T> where T : class
    {
        List<T> SearchByName(string name);

    }
}
