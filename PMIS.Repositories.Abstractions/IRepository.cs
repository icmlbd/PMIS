
namespace PMIS.Repositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        public bool Add(T entity);


        public bool Update(T entity);


        public bool Delete(T entity);


        public ICollection<T> GetAll();


        public T GetFirstOrDefault(Func<T, bool> predicate);


        public ICollection<T> GetMany(Func<T, bool> predicate);

        IQueryable<T> GetManyQuerable(Func<T, bool> predicate);

        IQueryable<T> GetManyQuerable();

    }
}
