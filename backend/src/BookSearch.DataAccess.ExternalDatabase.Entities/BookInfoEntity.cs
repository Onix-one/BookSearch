namespace BookSearch.DataAccess.ExternalDatabase.Entities
{
    public class BookInfoEntity
    {
        public string? Title { get; set; }

        public string? Subtitle { get; set; }

        public List<string>? Authors { get; set; }

        public string? PublishedDate { get; set; }

        public string? Description { get; set; }

        public int PageCount { get; set; }

        public ImageLinkEntity? ImageLinks { get; set; }

        public string? Language { get; set; }

    }
}
