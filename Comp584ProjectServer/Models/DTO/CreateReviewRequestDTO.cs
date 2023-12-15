using Comp584ProjectServer.Models.Domain;

namespace Comp584ProjectServer.Models.DTO
{
    public class CreateReviewRequestDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Rating { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Author { get; set; }
        public Guid BookId { get; set; }

    }
}
