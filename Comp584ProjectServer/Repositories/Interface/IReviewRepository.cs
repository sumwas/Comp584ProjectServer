using Comp584ProjectServer.Models.Domain;
using Comp584ProjectServer.Models.DTO;

namespace Comp584ProjectServer.Repositories.Interface
{
    public interface IReviewRepository
    {
        Task<Review> CreateAsync(Review review);

        Task<IEnumerable<Review>> GetAllAsync();
        Task<List<ReviewDTO>> GetReviewsForBook(Guid bookId);
    }
}
