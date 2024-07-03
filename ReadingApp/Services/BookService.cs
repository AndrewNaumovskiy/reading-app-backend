using ReadingApp.Models;
using ReadingApp.Helpers;
using ReadingApp.Models.DbModels;
using ReadingApp.Models.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace ReadingApp.Services
{
    public class BookService
    {
        private readonly IDbContextFactory<ReadingDbContext> _dbContextFactory;

        private readonly List<BookModel> _books;
        public BookService(IDbContextFactory<ReadingDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

            _books = new List<BookModel>();
        }

        public async Task<List<BookModel>> GetBooks()
        {
            //if(_books.Count != 0)
            //    return _books;

            _books.Clear();

            using(var db = await _dbContextFactory.CreateDbContextAsync())
            {
                // TODO: add pagination, optimize with select only needed fields
                var books = await db.Books
                    .AsNoTracking()
                    .ToListAsync();

                foreach(var book in books)
                {
                    _books.Add(new BookModel(book));
                }
            }

            return _books;
        }
    
        public async Task<BookInformationModel> GetBookById(int id, int userId)
        {
            var result = new BookInformationModel();

            BookDbModel? book = null;

            using(var db = await _dbContextFactory.CreateDbContextAsync())
            {
                try
                {
                    book = await db.Books
                        .AsNoTracking()
                        .Include(x => x.Authors)
                        .Include(x => x.Categories)
                        .Include(x => x.Genres)
                        .Include(x => x.Rating)
                        .Include(x => x.UserRates)
                        .Include(x => x.Comments)
                        .ThenInclude(x => x.User)
                        .FirstOrDefaultAsync(x => x.Id == id);
                }
                catch (Exception e)
                {

                }
            }

            if (book == null)
                return result;

            result.Book = new BookModel(book);

            result.Rates = new BookRatesModel(book.UserRates);

            if (userId != 0 && book.UserRates.Any(x => x.UserId == userId))
            {
                var firstUserRate = book.UserRates.FirstOrDefault(x => x.UserId == userId);
                result.UserRate = new UserRateModel(firstUserRate);
            }

            result.Comments = book.Comments.Select(x => new BookCommentModel(x)).ToList();

            return result;
        }

        public async Task<UserRateModel> UpdateUserRate(UpdateUserRateRequestModel body)
        {
            using(var db = await _dbContextFactory.CreateDbContextAsync())
            {
                var userRate = await db.UserRates
                                    .FirstOrDefaultAsync(x => x.BookId == body.BookId && x.UserId == body.UserId);

                if (userRate == null)
                {
                    userRate = new UserRateDbModel()
                    {
                        BookId = body.BookId,
                        UserId = body.UserId,
                        Score = 0,
                        StatusId = body.StatusId,
                        Pages = 0,
                        Rereads = 0,
                        Thoughts = ""
                    };

                    await db.UserRates.AddAsync(userRate);
                }
                else
                {
                    //userRate.Score = body.Score;
                    //userRate.Pages = body.Pages;
                    userRate.StatusId = body.StatusId;
                }

                await db.SaveChangesAsync();

                return new UserRateModel(userRate);
            }
        }
    }
}
