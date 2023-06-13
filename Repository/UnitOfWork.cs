using WebMVC.Data;
using WebMVC.Models;
using WebMVC.Repository.Base;

namespace WebMVC.Repository
{
    public class UnitOfWork : IUniteOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            categories = new MainRepository<Category>(_context);
            items = new MainRepository<Item>(_context);
            employees = new EmpRepo(_context);

        }

        public IRepository<Category> categories { get; private set; }

        public IRepository<Item> items { get; private set; }

        public IEmpRepo employees { get; private set; }

        public int CommitChanges() => _context.SaveChanges();


        public void Dispose() => _context.Dispose();

    }
}
