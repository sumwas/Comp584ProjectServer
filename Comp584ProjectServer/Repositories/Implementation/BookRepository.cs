using Comp584ProjectServer.Data;
using Comp584ProjectServer.Models.Domain;
using Comp584ProjectServer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Comp584ProjectServer.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await dbContext.Books.ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Book> books)
        {
            await dbContext.Books.AddRangeAsync(books);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Book?> GetById(Guid id)
        {
           return await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
