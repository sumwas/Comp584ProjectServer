using Comp584ProjectServer.Models.Domain;
using Comp584ProjectServer.Models.DTO;
using Comp584ProjectServer.Repositories.Implementation;
using Comp584ProjectServer.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Comp584ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IBookRepository bookRepository;

        public ReviewsController(IReviewRepository reviewRepository, IBookRepository bookRepository)
        {
            this.reviewRepository = reviewRepository;
            this.bookRepository = bookRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewRequestDTO request)
        {
            var book = await bookRepository.GetById(request.BookId);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            var review = new Review
            {
                Title = request.Title,
                Rating = request.Rating,
                Content = request.Content,
                PublishedDate = request.PublishedDate,
                Author = request.Author,
                BookId = request.BookId,
                BookTitle = book
            };

            review = await reviewRepository.CreateAsync(review);

            var response = new ReviewDTO
            {
                Id = review.Id,
                Title = review.Title,
                Rating = review.Rating,
                Content = review.Content,
                PublishedDate = review.PublishedDate,
                Author = review.Author,
                BookTitle = new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    PlotSummary = book.PlotSummary,
                    PublicationDate = book.PublicationDate,
                    UrlHandle = book.UrlHandle,
                }
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await reviewRepository.GetAllAsync();

            var response = reviews.Select(review => new ReviewDTO
            {
                Id = review.Id,
                Title = review.Title,
                Rating = review.Rating,
                Content = review.Content,
                PublishedDate = review.PublishedDate,
                Author = review.Author,
                BookTitle = new BookDTO
                {
                    Id = review.BookTitle.Id,
                    Title = review.BookTitle.Title,
                    Author = review.BookTitle.Author,
                    PlotSummary = review.BookTitle.PlotSummary,
                    PublicationDate = review.BookTitle.PublicationDate,
                    UrlHandle = review.BookTitle.UrlHandle,
                }
            }).ToList();

            return Ok(response);
        }
    }
}
