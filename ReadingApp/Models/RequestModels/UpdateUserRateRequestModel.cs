namespace ReadingApp.Models.RequestModels
{
    public class UpdateUserRateRequestModel
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Score { get; set; }
        public int StatusId { get; set; }
        public int Pages { get; set; }
    }
}
