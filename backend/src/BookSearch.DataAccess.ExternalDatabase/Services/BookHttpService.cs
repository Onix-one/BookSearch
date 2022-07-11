using BookSearch.DataAccess.ExternalDatabase.Entities;
using BookSearch.DataAccess.ExternalDatabase.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BookSearch.DataAccess.ExternalDatabase.Services
{

    public class BookHttpService : BaseHttpService, IBookHttpService
    {
        private readonly IConfiguration _configuration;
        public BookHttpService(HttpClient httpClient, IConfiguration configuration) : base(httpClient)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<BookEntity>> GetBooksBySearchAsync(string search)
        {
            var message = new HttpRequestMessage(HttpMethod.Get,
                $"volumes?key={_configuration["GoogleBookApiKey"]}&q={search}&maxResults=40");
            var response = await HttpClient.SendAsync(message);
            response.EnsureSuccessStatusCode();
            var bookList = (await ConvertHttpResponseTo<BooksWrapperEntity>(response)).Items;
            return bookList!;
        }
    }
}
