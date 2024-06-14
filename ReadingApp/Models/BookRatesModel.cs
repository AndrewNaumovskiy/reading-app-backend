using ReadingApp.Models.DbModels;

namespace ReadingApp.Models
{
    public class BookRatesModel
    {
        public List<BookScoreModel> BookScores { get; set; }
        public List<BookStatusModel> BookStatuses { get; set; }
        public int TotalRates { get; set; }

        public BookRatesModel(List<UserRateDbModel> rates)
        {
            if (rates.Count == 0)
                return;

            BookScores = new List<BookScoreModel>();
            BookStatuses = new List<BookStatusModel>();

            TotalRates = rates.Count;

            foreach (var item in rates.GroupBy(x => x.Score))
            {
                if (item.Key == 0)
                    continue;

                BookScores.Add(new BookScoreModel()
                {
                    Score = item.Key,
                    Amount = item.Count()
                });
            }

            foreach (var item in rates.GroupBy(x => x.StatusId))
                BookStatuses.Add(new BookStatusModel()
                {
                    StatusId = item.Key,
                    Amount = item.Count()
                });
        }
    }

    public class BookScoreModel
    {
        public int Score { get; set; }
        public int Amount { get; set; }
    }
    public class BookStatusModel
    {
        public int StatusId { get; set; }
        public int Amount { get; set; }
    }
}
