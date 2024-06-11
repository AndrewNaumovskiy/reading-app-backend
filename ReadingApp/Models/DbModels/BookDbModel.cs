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

        public List<AuthorDbModel> Authors { get; set; } = [];
        public List<CategorieDbModel> Categories { get; set; } = [];
    }
}
