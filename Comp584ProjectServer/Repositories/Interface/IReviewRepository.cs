using Comp584ProjectServer.Models.Domain;

namespace Comp584ProjectServer.Repositories.Interface
{
    public interface IReviewRepository
    {
        Task<Review> CreateAsync(Review review);

        Task<IEnumerable<Review>> GetAllAsync();
    }
}
