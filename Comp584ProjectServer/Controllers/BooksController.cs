using Comp584ProjectServer.Models.DTO;
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

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        //[Authorize(Roles = "RegisteredUser")]
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

        //[Authorize(Roles = "RegisteredUser")]
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


        [HttpPost("populate")]
        public async Task<IActionResult> PopulateBooks()
        {
            try
            {
                string filePath = "Data/booksummaries.txt";
                var books = BookService.ReadBooksFromFile(filePath);

                await bookRepository.AddRangeAsync(books);

                return Ok("Books populated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
