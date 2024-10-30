using Microsoft.EntityFrameworkCore;
using PMIS.Repositories.Abstractions;


namespace PMIS.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext _db;

        public Repository(DbContext db)
        {
            _db = db;
        }
       
        private DbSet<T> Table {
            get
            {
                return _db.Set<T>();
            }
        
        }

        public virtual bool Add(T entity)
        {
            _db.Add(entity);

            return _db.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            _db.Update(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual bool Delete(T entity)
        {
            _db.Remove(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual ICollection<T> GetAll()
        {
           return  Table.ToList();
        }

        public T GetFirstOrDefault(Func<T,bool> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        public ICollection<T> GetMany(Func<T,bool> predicate)
        {
            return Table.Where(predicate).ToList();
        }
    }
}
