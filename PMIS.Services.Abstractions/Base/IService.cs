using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Services.Abstractions.Base
{
    public interface IService<T> where T : class
    {
         bool Add(T entity);


         bool Update(T entity);


         bool Delete(T entity);


         ICollection<T> GetAll();

    }
}
