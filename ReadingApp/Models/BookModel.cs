using ReadingApp.Models.DbModels;

namespace ReadingApp.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Genres { get; set; }
        public string Thumbnail { get; set; }
        public string SmallThumbnail { get; set; }
        public string Language { get; set; }
        public float Score { get; set; }
        public string Status { get; set; } // announced, ongoing, released, latest - "release not sooner than 1 month"
        public string Rating { get; set; }

        public BookModel() { }

        public BookModel(BookDbModel dbModel)
        {
            Id = dbModel.Id;
            Title = dbModel.Title;
            PublishedDate = dbModel.PublishedDate;
            Description = dbModel.Description;
            PageCount = dbModel.PageCount;
            Thumbnail = dbModel.Thumbnail;
            SmallThumbnail = dbModel.SmallThumbnail;
            Language = dbModel.Language;
            Score = dbModel.Score;
            Status = dbModel.Status;
            Rating = dbModel.Rating?.Name;

            Authors = dbModel.Authors?.Select(x => x.Name).ToList();
            Categories = dbModel.Categories?.Select(x => x.Name).ToList();
            Genres = dbModel.Genres?.Select(x => x.Name).ToList();
        }
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
