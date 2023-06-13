using WebMVC.Models;

namespace WebMVC.Repository.Base
{
    public interface IUniteOfWork : IDisposable
    {
        IRepository<Category> categories { get; }
        IRepository<Item> items { get; }
        IEmpRepo employees { get; }
        int CommitChanges();
    }
}
