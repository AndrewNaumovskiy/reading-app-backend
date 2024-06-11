using ReadingApp.Models;
using ReadingApp.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ReadingApp.Services
{
    public class BookService
    {
        private readonly IDbContextFactory<ReadingDbContext> _dbContextFactory;

        private List<BookModel> _books;
        public BookService(IDbContextFactory<ReadingDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

            _books = new List<BookModel>();

            //var text = File.ReadAllText("books.json");
            //_books = JsonSerializer.Deserialize<List<BookModel>>(text);
        }

        public async Task<List<BookModel>> GetBooks()
        {
            //if(_books.Count != 0)
            //    return _books;

            _books.Clear();

            using(var db = await _dbContextFactory.CreateDbContextAsync())
            {
                var books = await db.Books
                    .AsNoTracking()
                    .Include(b => b.Authors)
                    .ToListAsync();

                foreach(var book in books)
                {
                    var authors = book.Authors.Select(x => x.Name).ToList();
                    
                    _books.Add(new BookModel()
                    {
                        Id = book.Id.ToString(),
                        Title = book.Title,
                        PublishedDate = book.PublishedDate,
                        Description = book.Description,
                        PageCount = book.PageCount,
                        Language = book.Language,
                        Authors = authors
                    });
                }
            }

            return _books;
        }
    }
}
