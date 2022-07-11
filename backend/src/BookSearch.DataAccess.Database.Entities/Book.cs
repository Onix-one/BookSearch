namespace BookSearch.DataAccess.Database.Entities
{
    public class Book : BaseEntity
    {
        public string? GoogleId { get; set; }

        public string? Title { get; set; }

        public string? Subtitle { get; set; }

        public IEnumerable<Author>? Authors { get; set; }

        public string? PublishedDate { get; set; }

        public string? Description { get; set; }

        public int PageCount { get; set; }

        public string? SmallThumbnail { get; set; }

        public string? Thumbnail { get; set; }

        public string? Language { get; set; }
    }
}
