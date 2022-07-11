using AutoMapper;
using BookSearch.Business.Services.Interfaces;
using BookSearch.WebApi.Controllers;
using BookSearch.WebApi.Tests.Configurations;
using BookSearch.WebApi.Tests.Mapper;
using BookSearch.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Ninject;
using static NUnit.Framework.Assert;

namespace BookSearch.WebApi.Tests.Controllers
{
    public class BooksControllerTest
    {
        private IKernel? _ninject;
        private IBookService? _bookServiceStub;
        private Mock<IBookService>? _bookServiceMock;
        private Mock<IMapper>? _mapperMock;
        private BooksController? _booksController;
        private IMapper? _mapper;

        [SetUp]
        public void Setup()
        {
            _ninject = new StandardKernel(new ConfigBookService());
            _bookServiceStub = _ninject!.Get<IBookService>();
            _mapperMock = new Mock<IMapper>();
            _bookServiceMock = new Mock<IBookService>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookProfile());
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task GetAction_ShouldReturnOkObjectResultWithListOfThreeBooks()
        {
            //arrange
            _booksController = new BooksController(_mapperMock!.Object, _bookServiceStub!);
            const string searchValue = "react";
            var filterViewModel = new BookFilterViewModel { Search = searchValue };
            var books = (await _bookServiceStub!.GetBooksBySearchAsync(filterViewModel.Search));

            _mapperMock
                .Setup(x => x.Map<IEnumerable<BookViewModel>>(books))
                .Returns(_mapper!.Map<IEnumerable<BookViewModel>>(books));

            //act
            var result = (await _booksController.Get(filterViewModel)).Result as OkObjectResult;
            var booksCount = (result!.Value as IEnumerable<BookViewModel>)!.Count();

            //assert
            const int expectedBooksCount = 3;
            Multiple(() =>
            {
                That(expectedBooksCount, Is.EqualTo(booksCount));
                That(result, Is.TypeOf<OkObjectResult>());
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public async Task GetAction_ShouldReturnBadRequest(string notCorrectSearch)
        {
            //arrange
            _booksController = new BooksController(_mapperMock!.Object, _bookServiceStub!);

            var filterViewModel = new BookFilterViewModel { Search = notCorrectSearch };

            //act
            var result = (await _booksController.Get(filterViewModel)).Result as BadRequestResult;

            //assert
            That(result, Is.TypeOf<BadRequestResult>());
        }

        [Test]
        public async Task GetAction_ShouldReturnNotFound()
        {
            //arrange
            _booksController = new BooksController(_mapperMock!.Object, _bookServiceStub!);
            const string searchValue = "asdfkasfhdskjfah";
            var filterViewModel = new BookFilterViewModel { Search = searchValue };
            var books = (await _bookServiceStub!.GetBooksBySearchAsync(filterViewModel.Search));

            _mapperMock
                .Setup(x => x.Map<IEnumerable<BookViewModel>>(books))
                .Returns(_mapper!.Map<IEnumerable<BookViewModel>>(books));

            //act
            var result = (await _booksController.Get(filterViewModel)).Result as NotFoundResult;

            //assert
            That(result, Is.TypeOf<NotFoundResult>());

        }

        [Test]
        public async Task GetAction_ShouldReturnProblemDetails()
        {
            //arrange
            _booksController = new BooksController(_mapperMock!.Object, _bookServiceMock!.Object);
            const string searchValue = "react";
            var filterViewModel = new BookFilterViewModel { Search = searchValue };

            _bookServiceMock.Setup(x => x.GetBooksBySearchAsync(It.IsAny<string>()).Result)
            .Throws(new Exception());

            //act
            var result = (await _booksController.Get(filterViewModel)).Result as ObjectResult;

            //assert
            That(result!.Value, Is.TypeOf<ProblemDetails>());

        }
    }
}
