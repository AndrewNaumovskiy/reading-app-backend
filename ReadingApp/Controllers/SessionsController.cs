﻿using ReadingApp.Models;
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

        [HttpPost]
        [EnableCors]
        [Route("pause")]
        public async Task<ActionResult<ResponseModel<StatusData, IError>>> PauseSession([FromBody] PauseSessionRequestModel body)
        {
            using(var db = await _dbContext.CreateDbContextAsync())
            {
                var session = await db.Sessions.FirstOrDefaultAsync(x => x.Id == body.SessionId);
                if (session == null)
                    return Ok(new ResponseModel<IData, Error>()
                    {
                        Error = new Error("No session found")
                    });

                session.Status = "paused";
                await db.SaveChangesAsync();
            }

            return Ok(new ResponseModel<StatusData, IError>()
            {
                Data = new StatusData()
            });
        }

        [HttpPost]
        [EnableCors]
        [Route("finish")]
        public async Task<ActionResult<ResponseModel<StatusData, IError>>> FinishSession([FromBody] PauseSessionRequestModel body)
        {
            using (var db = await _dbContext.CreateDbContextAsync())
            {
                var session = await db.Sessions.FirstOrDefaultAsync(x => x.Id == body.SessionId);
                if (session == null)
                    return Ok(new ResponseModel<IData, Error>()
                    {
                        Error = new Error("No session found")
                    });

                session.Status = "finished";
                await db.SaveChangesAsync();
            }

            return Ok(new ResponseModel<StatusData, IError>()
            {
                Data = new StatusData()
            });
        }

        [HttpGet]
        [EnableCors]
        [Route("checkUser")]
        public async Task<ActionResult<ResponseModel<CheckUserSessionData, IError>>> CheckUserSessions([FromQuery] int userId)
        {
            using (var db = await _dbContext.CreateDbContextAsync())
            {
                var session = await db.Sessions.FirstOrDefaultAsync(x => x.UserId == userId && x.Status != "finished");
                if (session == null)
                    return Ok(new ResponseModel<CheckUserSessionData, IError>()
                    {
                        Data = new CheckUserSessionData(false, -1)
                    });


                return Ok(new ResponseModel<CheckUserSessionData, IError>()
                {
                    Data = new CheckUserSessionData(true, session.Id)
                });
            }
        }
    }
}
