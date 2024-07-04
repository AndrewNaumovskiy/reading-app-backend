namespace ReadingApp.Models
{
    public class BookInformationModel
    {
        public BookModel Book { get; set; }
        public UserRateModel UserRate { get; set; }
        public BookRatesModel Rates { get; set; }
        public List<BookCommentModel> Comments { get; set; }
    }
}
