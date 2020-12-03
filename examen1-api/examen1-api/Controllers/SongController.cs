using examen1_api.data_access.Entities;
using examen1_api.data_access.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;

namespace examen1_api.Controllers
{
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public SongController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("api/song/buy")]
        public ActionResult BuySong(int userId, int songId)
        {
            try
            {
                User theUser = unitOfWork.UserRepository.GetById(userId);
                Song theSong = unitOfWork.SongRepository.GetById(songId);
                unitOfWork.UserSongRepository.Create(new UserSong()
                {
                    User = theUser,
                    UserId = theUser.Id,
                    Song = theSong,
                    SongId = theSong.Id
                });
                unitOfWork.Commit();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}