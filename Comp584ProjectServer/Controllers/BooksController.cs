using Comp584ProjectServer.Models.DTO;
using Comp584ProjectServer.Repositories.Implementation;
using Comp584ProjectServer.Repositories.Interface;
using Comp584ProjectServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Comp584ProjectServer.Controllers
{
    //Get : https://localhost:7096/api/Books

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IReviewRepository reviewRepository;

        public BooksController(IBookRepository bookRepository, IReviewRepository reviewRepository)
        {
            this.bookRepository = bookRepository;
            this.reviewRepository = reviewRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await bookRepository.GetBooksAsync();

            //map to DTO

            var response = new List<BookDTO>();
            foreach (var book in books)
            {
                response.Add(new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    PublicationDate = book.PublicationDate,
                    UrlHandle = book.UrlHandle,
                    PlotSummary = book.PlotSummary
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBookbyID([FromRoute] Guid id)
        {
            var existingBook = await bookRepository.GetById(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            var response = new BookDTO
            {
                Id = existingBook.Id,
                Title = existingBook.Title,
                Author = existingBook.Author,
                PlotSummary = existingBook.PlotSummary,
                PublicationDate = existingBook.PublicationDate,
                UrlHandle = existingBook.UrlHandle,
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}/reviews")]
        public async Task<IActionResult> GetReviewsForBook([FromRoute] Guid id)
        {
            var reviews = await reviewRepository.GetReviewsForBook(id);

            return Ok(reviews);
        }

        [HttpGet]
        [Route("{urlHandle}")]
        public async Task<IActionResult> GetBookByUrlHandle([FromRoute] string urlHandle)
        {
            var existingBook = await bookRepository.GetByUrlHandleAsync(urlHandle);

            if (existingBook == null)
            {
                return NotFound();
            }

            var response = new BookDTO
            {
                Id = existingBook.Id,
                Title = existingBook.Title,
                Author = existingBook.Author,
                PlotSummary = existingBook.PlotSummary,
                PublicationDate = existingBook.PublicationDate,
                UrlHandle = existingBook.UrlHandle,
            };

            return Ok(response);

        }


        [HttpPost("populate")]
        public async Task<IActionResult> PopulateBooks()
        {
            try
            {
                // Check if the Books table is empty
                if (await bookRepository.GetCountAsync() == 0)
                {
                    string filePath = "Data/booksummaries.txt";
                    var books = BookService.ReadBooksFromFile(filePath);

                    await bookRepository.AddRangeAsync(books);

                    return Ok("Books populated successfully.");
                }
                else
                {
                    return Ok("Books table is not empty. No need to populate.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


    }
}
