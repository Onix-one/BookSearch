namespace BookSearch.DataAccess.ExternalDatabase.Entities
{
    public class BooksWrapperEntity
    {
        public string? Kind { get; set; }

        public int TotalItems { get; set; }

        public IEnumerable<BookEntity>? Items { get; set; }
    }
}
