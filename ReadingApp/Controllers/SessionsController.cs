using ReadingApp.Models;
using ReadingApp.Helpers;
using ReadingApp.Models.DbModels;
using ReadingApp.Models.RequestModels.Sessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace ReadingApp.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly IDbContextFactory<ReadingDbContext> _dbContext;
        public SessionsController(IDbContextFactory<ReadingDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [EnableCors]
        [Route("start")]
        public async Task<ActionResult<ResponseModel<StartSessionData, IError>>> StartSession([FromBody] StartSessionRequestModel body)
        {
            int result = -1;

            var session = new SessionDbModel()
            {
                UserId = body.UserId,
                BookId = body.BookId,
                Status = "started"
            };

            using (var db = await _dbContext.CreateDbContextAsync())
            {
                await db.Sessions.AddAsync(session);
                await db.SaveChangesAsync();
                result = session.Id;
            }

            return Ok(new ResponseModel<StartSessionData, IError>()
            {
                Data = new StartSessionData(result),
            });
        }
    }
}
