using AutoMapper;
using BookSearch.Business.Entities.Dtos;
using BookSearch.Business.ExternalServices.Interfaces;
using BookSearch.Business.Services.Services;
using BookSearch.Business.Services.Tests.Configurations;
using BookSearch.Business.Services.Tests.Mapper;
using BookSearch.DataAccess.Database.Interfaces;
using Moq;
using Ninject;
using static NUnit.Framework.Assert;

namespace BookSearch.Business.Services.Tests.Services
{
    public class BookServiceTest
    {
        private IKernel? _ninject;
        private IBookRepository? _bookRepositoryStub;
        private IBookExternalService? _bookExternalServiceStub;
        private Mock<IBookRepository>? _bookRepositoryMock;
        private Mock<IMapper>? _mapperMock;
        private BookService? _bookService;
        private IMapper? _mapper;

        [SetUp]
        public void Setup()
        {
            _ninject = new StandardKernel(new ConfigBookRepository());
            _bookRepositoryStub = _ninject!.Get<IBookRepository>();
            _bookExternalServiceStub = _ninject!.Get<IBookExternalService>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _mapperMock = new Mock<IMapper>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookProfile());
            });
            _mapper = mapperConfig.CreateMapper();
        }


        [Test]
        public async Task GetBooksBySearchAsync_ShouldReturnThreeBooks()
        {
            //arrange
            _bookService = new BookService(_mapperMock!.Object, _bookRepositoryStub!, _bookExternalServiceStub!);
            const string searchValue = "react";
            var books = (await _bookRepositoryStub!.GetBySearchAsync(searchValue));

            _mapperMock
                .Setup(x => x.Map<IEnumerable<BookDto>>(books))
                .Returns(_mapper!.Map<IEnumerable<BookDto>>(books));

            //act
            var result = (await _bookService.GetBooksBySearchAsync(searchValue)).ToList();
            var booksCount = result.Count;

            //assert
            const int expectedBooksCount = 3;
            That(expectedBooksCount, Is.EqualTo(booksCount));
        }

        [Test]
        public async Task GetBooksBySearchAsync_ShouldReturnOneBook()
        {
            //arrange
            _bookService = new BookService(_mapperMock!.Object, _bookRepositoryStub!, _bookExternalServiceStub!);
            const string searchValue = "Nika";
            var books = await _bookRepositoryStub!.GetBySearchAsync(searchValue);
            var booksFromGoogleApi = await _bookExternalServiceStub!.GetBooksBySearchAsync(searchValue);

            _mapperMock
                .Setup(x => x.Map<IEnumerable<BookDto>>(books))
                .Returns(_mapper!.Map<IEnumerable<BookDto>>(books));


            //act
            var result = (await _bookService.GetBooksBySearchAsync(searchValue)).ToList();
            var booksCount = result.Count;

            //assert
            const int expectedBooksCount = 1;
            That(expectedBooksCount, Is.EqualTo(booksCount));
        }

    }
}