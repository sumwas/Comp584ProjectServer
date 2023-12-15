namespace Comp584ProjectServer.Models.DTO
{
    public class CreateBookRequestDTO
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? UrlHandle { get; set; }
        public string? PlotSummary { get; set; }
    }
}
