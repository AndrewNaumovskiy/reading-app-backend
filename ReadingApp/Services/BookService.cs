using System.Text.Json;
using ReadingApp.Models;

namespace ReadingApp.Services
{
    public class BookService
    {
        private List<BookModel> _books;
        public BookService()
        {
            var text = File.ReadAllText("books.json");
            _books = JsonSerializer.Deserialize<List<BookModel>>(text);
        }

        public List<BookModel> GetBooks()
        {
            return _books;
        }
    }
}
