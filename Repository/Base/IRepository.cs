using System.Linq.Expressions;

namespace WebMVC.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T SelectOne(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params string[] arges);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params string[] arges);

        void AddOne(T Item);
        void UpdateOne(T Item);
        void DeleteOne(T Item);

        void AddList(IEnumerable<T> ItemList);
        void UpdateList(IEnumerable<T> ItemList);
        void RemoveList(IEnumerable<T> ItemList);



    }
}
