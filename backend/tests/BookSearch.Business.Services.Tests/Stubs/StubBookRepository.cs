using BookSearch.DataAccess.Database.Entities;
using BookSearch.DataAccess.Database.Interfaces;

namespace BookSearch.Business.Services.Tests.Stubs
{
    public class StubBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new()
        {
            new Book
            {
                Id = 761,
                GoogleId = "OCHEnQAACAAJ",
                Title = "React: Up & Running",
                Subtitle = "Building Web Applications",
                Authors = new Author[]
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
             new Book
            {
                Id = 762,
                GoogleId = "XCLhDwAAQBAJ",
                Title = "React and React Native",
                Subtitle = "A complete hands-on guide to modern web and mobile development with React.js, 3rd Edition",
                Authors = new Author[]
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
              new Book
            {
                Id = 763,
                GoogleId = "ppjUtAEACAAJ",
                Title = "Fullstack React",
                Subtitle = "The Complete Guide to ReactJS and Friends",
                Authors = new Author[]
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
              new Book
              {
                  Id = 802,
                  GoogleId = "0zZ1zQEACAAJ",
                  Title = "Pro Angular 9",
                  Subtitle = "Build Powerful and Dynamic Web Apps",
                  Authors = new Author[]
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

        public IQueryable<Book> Query { get; }

        Task<IEnumerable<Book>> IGenericRepository<Book>.GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Book>>(_books);
        }

        public Task<Book> GetByIdAsync(int id)
        {
            return Task.FromResult(_books.SingleOrDefault(b => b.Id == id)!);
        }

        public Task InsertAsync(Book entity)
        {
            _books.Add(entity);
            return Task.CompletedTask;
        }

        public Task InsertAsync(IEnumerable<Book> entities)
        {
            _books.AddRange(entities);
            return Task.CompletedTask;
        }

        public Task<Book> UpdateAsync(Book entity)
        {
            var book = _books.SingleOrDefault(c => c.Id == entity.Id);
            if (book == null) throw new Exception();
            _books.Remove(book);
            _books.Add(entity);
            return Task.FromResult(entity);
        }

        public Task UpdateAsync(IEnumerable<Book> entities)
        {
            foreach (var entity in entities.ToList())
            {
                var book = _books.SingleOrDefault(c => c.Id == entity.Id);
                if (book == null) throw new Exception();
                _books.Remove(book);
                _books.Add(entity);
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var book = _books.SingleOrDefault(c => c.Id == id);
            if (book == null) throw new Exception();
            _books.Remove(book);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Book entity)
        {
            _books.Remove(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(IEnumerable<Book> entities)
        {
            foreach (var entity in entities.ToList())
            {
                var book = _books.SingleOrDefault(c => c.Id == entity.Id);
                if (book == null) throw new Exception();
                _books.Remove(book);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Book>> GetBySearchAsync(string search)
        {
            return Task.FromResult(_books
                .Where(u => u.Title!.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
