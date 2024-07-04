using ReadingApp.Models.DbModels.Relationships;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels
{
    [Table("books")]
    public class BookDbModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }

        // TODO: rework with book edition
        public int PageCount { get; set; }
        public string Language { get; set; }
        public string Thumbnail { get; set; }
        public string SmallThumbnail { get; set; }

        // calculated once a day or something with a job
        public float Score { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Status { get; set; } // announced, ongoing, released, latest - "release not sooner than 1 month"
        public int RatingId { get; set; }

        public List<AuthorDbModel> Authors { get; set; } = [];
        public List<CategoryDbModel> Categories { get; set; } = [];
        public List<GenreDbModel> Genres { get; set; } = [];

        public List<UserRateDbModel> UserRates { get; set; } = [];
        public BookRatingDbModel Rating { get; set; }
        public List<BookCommentDbModel> Comments { get; set; } = [];

    }
}
