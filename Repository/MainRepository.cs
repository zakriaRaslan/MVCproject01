using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebMVC.Data;
using WebMVC.Repository.Base;

namespace WebMVC.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public MainRepository(AppDbContext context)
        {
            _context = context;
        }

        public T GetById(int id) => _context.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);


        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public T SelectOne(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().SingleOrDefault(expression);
        }

        public IEnumerable<T> GetAll(params string[] arges)
        {
            IQueryable<T> query = _context.Set<T>();

            if (arges.Length > 0)
            {
                foreach (var arge in arges)
                {
                    query = query.Include(arge);
                }
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] arges)
        {
            IQueryable<T> query = _context.Set<T>();

            if (arges.Length > 0)
            {
                foreach (var arge in arges)
                {
                    query = query.Include(arge);
                }

            }
            return await query.ToListAsync();

        }

        //*************************************************************************

        public void AddOne(T Item)
        {
            _context.Set<T>().Add(Item);
            _context.SaveChanges();
        }


        public void UpdateOne(T Item)
        {
            _context.Set<T>().Update(Item);
            _context.SaveChanges();
        }
        public void DeleteOne(T Item)
        {
            _context.Set<T>().Remove(Item);
            _context.SaveChanges();

        }

        public void AddList(IEnumerable<T> ItemList)
        {
            _context.Set<T>().AddRange(ItemList);
            _context.SaveChanges();

        }


        public void UpdateList(IEnumerable<T> ItemList)
        {
            _context.Set<T>().UpdateRange(ItemList);
            _context.SaveChanges();

        }


        public void RemoveList(IEnumerable<T> ItemList)
        {
            _context.Set<T>().RemoveRange(ItemList);
            _context.SaveChanges();

        }

    }
}
