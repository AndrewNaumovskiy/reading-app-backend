using ReadingApp.Models.DbModels;

namespace ReadingApp.Models
{
    public class UserRateModel
    {
        public float Score { get; set; }
        public int ReadStatusId { get; set; }
        public int PagesRead { get; set; }
        public int PagesCount { get; set; }
        public int Rereads { get; set; }
        public string Thoughts { get; set; }

        public UserRateModel(UserRateDbModel model)
        {
            Score = model.Score;
            ReadStatusId = model.StatusId;
            PagesRead = model.PagesRead;
            PagesCount = model.PagesCount;
            Rereads = model.Rereads;
            Thoughts = model.Thoughts;
        }
    }
}
