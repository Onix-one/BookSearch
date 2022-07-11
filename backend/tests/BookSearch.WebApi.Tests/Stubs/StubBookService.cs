using BookSearch.Business.Entities.Dtos;
using BookSearch.Business.Services.Interfaces;

namespace BookSearch.WebApi.Tests.Stubs
{
    public class StubBookService : IBookService
    {
        private readonly List<BookDto> _books = new()
        {
            new BookDto
            {
                Id = 761,
                GoogleId = "OCHEnQAACAAJ",
                Title = "React: Up & Running",
                Subtitle = "Building Web Applications",
                Authors = new AuthorDto[]
                {
                    new(){ FullName = "Stoyan Stefanov"}
                },
                PublishedDate = "2016-08-04",
                Description = "Hit the ground running with React, the open-source technology from " +
                              "Facebook for building rich web applications fast. With this practical " +
                              "guide, Yahoo!",
                PageCount = 250,
                SmallThumbnail = "http://books.google.com/books/content?id=OCHEnQAACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                Thumbnail = "http://books.google.com/books/content?id=OCHEnQAACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api",
                Language = "en"
            },
             new BookDto
            {
                Id = 762,
                GoogleId = "XCLhDwAAQBAJ",
                Title = "React and React Native",
                Subtitle = "A complete hands-on guide to modern web and mobile development with React.js, 3rd Edition",
                Authors = new AuthorDto[]
                {
                    new(){ FullName = "Adam Boduch"},
                    new(){FullName = "Roy Derks"}
                },
                PublishedDate = "2020-04-30",
                Description = "Get up to speed with React, React Native, GraphQL and Apollo for building cross-platform " +
                              "native apps with the help of practical examples Key Features Covers the latest features of " +
                              "React such as Hooks, Suspense, NativeBase, and Apollo in this updated third edition Get to" +
                              " grips with the React architecture for writing easy-to-manage web and mobile applications " +
                              "Understand GraphQL and Apollo for building a scalable backend for your cross-platform apps " +
                              "Book Description React and React Native, Facebook’s innovative User Interface (UI) libraries," +
                              " are designed to help you build robust cross-platform web and mobile applications.",
                PageCount = 526,
                SmallThumbnail = "http://books.google.com/books/content?id=XCLhDwAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                Thumbnail = "http://books.google.com/books/content?id=XCLhDwAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_apii",
                Language = "en"
            },
              new BookDto
            {
                Id = 763,
                GoogleId = "ppjUtAEACAAJ",
                Title = "Fullstack React",
                Subtitle = "The Complete Guide to ReactJS and Friends",
                Authors = new AuthorDto[]
                {
                    new(){ FullName = "Accomazzo Anthony"},
                    new(){ FullName = "Murray Nathaniel"},
                    new(){ FullName = "Ari Lerner"}
                },
                PublishedDate = "2017-03",
                Description = "LEARN REACT TODAY The up-to-date, in-depth, complete guide to React and friends. Become a " +
                              "ReactJS expert today",
                PageCount = 836,
                SmallThumbnail = "http://books.google.com/books/content?id=ppjUtAEACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                Thumbnail = "http://books.google.com/books/content?id=ppjUtAEACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api",
                Language = "en"
            },
              new BookDto
              {
                  Id = 802,
                  GoogleId = "0zZ1zQEACAAJ",
                  Title = "Pro Angular 9",
                  Subtitle = "Build Powerful and Dynamic Web Apps",
                  Authors = new AuthorDto[]
                  {
                      new(){ FullName = "Adam Freeman"}
                  },
                  PublishedDate = "2020-11-09",
                  Description = "The new edition of this concise and comprehensive guide is presented in full color " +
                                "and updated for Angular 9. Angular is the leading framework for building dynamic JavaScript" +
                                " applications that take advantage of the capabilities of modern browsers and devices.",
                  PageCount = 0,
                  SmallThumbnail = "http://books.google.com/books/content?id=0zZ1zQEACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                  Thumbnail = "http://books.google.com/books/content?id=0zZ1zQEACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api",
                  Language = "en"
              }
        };
        public  Task<IEnumerable<BookDto>> GetBooksBySearchAsync(string search)
        {
            return Task.FromResult(_books.Where(u => u.Title!.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
