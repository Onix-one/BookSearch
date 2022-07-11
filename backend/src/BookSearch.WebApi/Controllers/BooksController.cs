using System.Collections.Immutable;
using AutoMapper;
using BookSearch.Business.Services.Interfaces;
using BookSearch.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookSearch.WebApi.Controllers
{
    /// <summary>
    /// Controller to handle aggregated requests for books api.
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]/[action]")]
    [SwaggerTag("Working with BookApi.")]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BooksController(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        /// <summary>
        /// Retrieves books by filter.
        /// </summary>
        /// <response code="200">Returns list of books</response>
        /// <response code="400">Something went wrong</response> 
        /// <response code="404">If books does not exist</response> 
        /// <response code="500">Oops! Can't lookup books right now</response>
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookViewModel>))]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> Get([FromQuery] BookFilterViewModel filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter.Search)) return BadRequest();

                var books = _mapper.Map<IEnumerable<BookViewModel>>(await _bookService.GetBooksBySearchAsync(filter.Search!));

                if (!books.Any()) return NotFound();

                return Ok(books);
            }
            catch
            {
                return Problem();
            }
        }
    }
}