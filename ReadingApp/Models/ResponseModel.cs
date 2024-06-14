using ReadingApp.Models.DbModels;

namespace ReadingApp.Models
{
    public class ResponseModel<D, E>
        where D : IData
        where E : IError
    {
        public D Data { get; set; }
        public E Error { get; set; }
    }

    public interface IError
    {
    }

    public class Error : IError
    {
        public string Description { get; set; }
        public Error(string desc)
        {
            Description = desc;
        }
    }

    public interface IData
    {

    }

    public class GetBooksData : IData
    {
        public List<BookModel> Books { get; set; }
        public GetBooksData(List<BookModel> books)
        {
            Books = books;
        }
    }
    public class GetBookInformationData : IData
    {
        public BookInformationModel Info { get; set; }
        public GetBookInformationData(BookInformationModel info)
        {
            Info = info;
        }
    }
    public class UpdateUserRateData : IData
    {
        public UserRateModel UserRate { get; set; }
        public UpdateUserRateData(UserRateModel userRate)
        {
            UserRate = userRate;
        }
    }



    public class GetUserData : IData
    {
        public UserDbModel User { get; set; }
        public GetUserData(UserDbModel user)
        {
            User = user;
        }
    }

    public class StartSessionData : IData
    {
        public int SessionId { get; set; }
        public DateTime StartTime { get; set; }
        public StartSessionData(int id, DateTime startTime)
        {
            SessionId = id;
            StartTime = startTime;
        }
    }
    public class PauseSessionData : IData
    {
        public int SessionId { get; set; }
        public int SecondsRead { get; set; }
        public PauseSessionData(int id, int seconds)
        {
            SessionId = id;
            SecondsRead = seconds;
        }
    }
    public class ResumeSessionData : IData
    {
        public int SessionId { get; set; }
        public DateTime StartTime { get; set; }
        public int SecondsRead { get; set; }
        public ResumeSessionData(int id, DateTime start, int seconds)
        {
            SessionId = id;
            StartTime = start;
            SecondsRead = seconds;
        }
    }
    public class FinishSessionData : IData
    {
        public int SecondsRead { get; set; }
        public FinishSessionData(int seconds)
        {
            SecondsRead = seconds;
        }
    }
    public class CheckUserSessionData : IData
    {
        public bool HasSessionPending { get; set; }
        public int SessionId { get; set; }

        public DateTime? StartTime { get; set; }
        public int SecondsReadForPreviousActions { get; set; }

        public CheckUserSessionData()
        {
            HasSessionPending = false;
            SessionId = -1;
            StartTime = null;
            SecondsReadForPreviousActions = 0;
        }

        public CheckUserSessionData(bool hasSessions, int sessionId, DateTime? startTime, int secondsReadForPreviousActions)
        {
            HasSessionPending = hasSessions;
            SessionId = sessionId;
            StartTime = startTime;
            SecondsReadForPreviousActions = secondsReadForPreviousActions;
        }
    }





    public class StatusData : IData
    {
        public string Status { get; set; }
        public StatusData()
        {
            Status = "Ok";
        }
    }

}
