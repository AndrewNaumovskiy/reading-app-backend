using ReadingApp.Models.DbModels;

namespace ReadingApp.Models
{
    public class BookCommentModel
    {
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public BookCommentModel(BookCommentDbModel model)
        {
            UserName = model.User.Nickname;
            Text = model.Text;
            Date = model.UpdatedDate;
        }
    }
}
