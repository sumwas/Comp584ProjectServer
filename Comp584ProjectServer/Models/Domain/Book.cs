﻿namespace Comp584ProjectServer.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string UrlHandle { get; set; }
        public string PlotSummary { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }


}
