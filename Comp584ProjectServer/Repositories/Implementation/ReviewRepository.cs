using Comp584ProjectServer.Data;
using Comp584ProjectServer.Models.Domain;
using Comp584ProjectServer.Models.DTO;
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

        public async Task<List<ReviewDTO>> GetReviewsForBook(Guid bookId)
        {
            var reviews = await dbContext.Reviews
            .Where(r => r.BookId == bookId)
            .Select(r => new ReviewDTO
             {
                Id = r.Id,
                Title = r.Title,
                Author = r.Author,
                PublishedDate = r.PublishedDate,
                Content = r.Content,
                Rating = r.Rating,
                BookTitle = new BookDTO
                {
                    Id = r.BookTitle.Id,
                    Title = r.BookTitle.Title,
                    Author = r.BookTitle.Author,
                    PublicationDate = r.BookTitle.PublicationDate,
                    PlotSummary = r.BookTitle.PlotSummary,
                    UrlHandle = r.BookTitle.UrlHandle,
                }
               })
            .ToListAsync();

            return reviews;
        }
    }
}
