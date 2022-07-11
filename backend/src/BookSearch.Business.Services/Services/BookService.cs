using AutoMapper;
using BookSearch.Business.Entities.Dtos;
using BookSearch.Business.ExternalServices.Interfaces;
using BookSearch.Business.Services.Interfaces;
using BookSearch.DataAccess.Database.Entities;
using BookSearch.DataAccess.Database.Interfaces;

namespace BookSearch.Business.Services.Services
{
    public sealed class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IBookExternalService _bookExternalService;

        public BookService(IMapper mapper, IBookRepository bookRepository, IBookExternalService bookExternalService)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _bookExternalService = bookExternalService;
        }

        public async Task<IEnumerable<BookDto>> GetBooksBySearchAsync(string search)
        {
            var bookList = _mapper.Map<IEnumerable<BookDto>>(await _bookRepository.GetBySearchAsync(search));

            if (!bookList.Any())
            {
                bookList = await _bookExternalService.GetBooksBySearchAsync(search);
                await _bookRepository.InsertAsync(_mapper.Map<IEnumerable<Book>>(bookList));
            }
            return bookList;
        }
    }
}
