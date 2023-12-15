using Comp584ProjectServer.Data;
using Comp584ProjectServer.Models.Domain;
using Comp584ProjectServer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Comp584ProjectServer.Repositories.Implementation
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ReviewRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Review> CreateAsync(Review review)
        {
            await dbContext.Reviews.AddAsync(review);
            await dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await dbContext.Reviews.Include(r => r.BookTitle).ToListAsync();
        }
    }
}
