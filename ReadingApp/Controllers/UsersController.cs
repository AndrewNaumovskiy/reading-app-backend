using ReadingApp.Models;
using ReadingApp.Helpers;
using ReadingApp.Models.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace ReadingApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDbContextFactory<ReadingDbContext> _dbContext;
        public UsersController(IDbContextFactory<ReadingDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [EnableCors]
        [Route("{nickname}")]
        public async Task<ActionResult<ResponseModel<GetUserData, IError>>> GetByNickname(string nickname)
        {
            UserDbModel user = null;

            using (var db = await _dbContext.CreateDbContextAsync())
            {
                user = await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Nickname == nickname);

                if (user == null)
                    return Ok(new ResponseModel<IData, Error>()
                    {
                        Error = new Error("No user found")
                    });
            }

            return Ok(new ResponseModel<GetUserData, IError>()
            {
                Data = new GetUserData(user)
            });
        }
    }
}
