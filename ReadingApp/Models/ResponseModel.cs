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

    public class GetUserData : IData
    {
        public UserDbModel User { get; set; }
        public GetUserData(UserDbModel user)
        {
            User = user;
        }
    }
}
