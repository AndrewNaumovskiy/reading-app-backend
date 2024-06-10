namespace ReadingApp.Models
{
    public class BookModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public List<string> Categories { get; set; }
        public ImageLinks ImageLinks { get; set; }
        public string Language { get; set; }
    }

    public class ImageLinks
    {
        public string Thumbnail { get; set; }
        public string SmallThumbnail { get; set; }
    }

    /* Models for Google API
    public class BookKek
    {
        public string id { get; set; }
        public VolumeInfo volumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string title { get; set; }
        public List<string> authors { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
        public int pageCount { get; set; }
        public List<string> categories { get; set; }
        public ImageLinksKek imageLinks { get; set; }
        public string language { get; set; }
    }

    public class ImageLinksKek
    {
        public string thumbnail { get; set; }
        public string smallThumbnail { get; set; }
    }
    */
}
