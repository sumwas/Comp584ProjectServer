using Comp584ProjectServer.Models.Domain;

namespace Comp584ProjectServer.Services
{
    public class BookService
    {
        public static List<Book> ReadBooksFromFile(string filePath)
        {
            List<Book> books = new List<Book>();

            foreach (string line in File.ReadLines(filePath))
            {
                string[] columns = line.Split('\t');
                string title = columns[2];

                string urlHandle = title.Replace(" ", "-");


                Book book = new Book
                {
                    Title = columns[2],
                    Author = columns[3],
                    PublicationDate = DateTime.TryParse(columns[4], out var date) ? date : (DateTime?)null,
                    UrlHandle = urlHandle,
                    PlotSummary = columns[6]
                };

                books.Add(book);
            }

            return books;
        }



    }
}
