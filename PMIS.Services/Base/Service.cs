using PMIS.Repositories.Abstractions;
using PMIS.Services.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Services.Base
{
    public class Service<T> : IService<T> where T: class
    {
        IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
           return _repository.Update(entity);
        }

        public virtual bool Delete(T entity)
        {
           return _repository.Delete(entity);
        }

        public virtual ICollection<T> GetAll()
        {
            return _repository.GetAll(); 
        }

        
    }
}
