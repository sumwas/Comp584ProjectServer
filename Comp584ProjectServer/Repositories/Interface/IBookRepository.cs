using Comp584ProjectServer.Models.Domain;

namespace Comp584ProjectServer.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task AddRangeAsync(IEnumerable<Book> books);

        Task<Book?> GetById(Guid id);
        Task<Book?> GetByUrlHandleAsync(string urlHandle);
        Task<int> GetCountAsync();
    }
}
