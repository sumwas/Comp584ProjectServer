namespace Comp584ProjectServer.Models.Domain
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Rating { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Author { get; set; }

        public Book BookTitle { get; set; }
        public Guid BookId { get; set; }  // Foreign key
    }
}
