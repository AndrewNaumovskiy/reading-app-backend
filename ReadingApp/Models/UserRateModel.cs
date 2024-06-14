using ReadingApp.Models.DbModels;

namespace ReadingApp.Models
{
    public class UserRateModel
    {
        public float Score { get; set; }
        public int ReadStatusId { get; set; }
        public int Pages { get; set; }
        public int Rereads { get; set; }
        public string Thoughts { get; set; }

        public UserRateModel(UserRateDbModel model)
        {
            Score = model.Score;
            ReadStatusId = model.StatusId;
            Pages = model.Pages;
            Rereads = model.Rereads;
            Thoughts = model.Thoughts;
        }
    }
}
