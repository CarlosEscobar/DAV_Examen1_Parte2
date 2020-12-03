using examen1_api.data_access.Entities;
using examen1_api.data_access.UnitOfWork;
using examen1_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace examen1_api.Controllers
{
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AlbumController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        private double CalculateAlbumPopularity(int albumId)
        {
            List<int> songIdsForAlbum = unitOfWork.AlbumSongRepository
                                                  .GetAll()
                                                  .Where(albumSong => albumSong.AlbumId == albumId)
                                                  .Select(albumSong => albumSong.SongId)
                                                  .ToList();

            List<Song> albumSongs = unitOfWork.SongRepository
                                              .GetAll()
                                              .Where(song => songIdsForAlbum.Contains(song.Id))
                                              .ToList();

            return albumSongs.Sum(song => song.Popularity) / albumSongs.Count;
        }

        private double CalculateAlbumPrice(int albumId)
        {
            List<int> songIdsForAlbum = unitOfWork.AlbumSongRepository
                                                  .GetAll()
                                                  .Where(albumSong => albumSong.AlbumId == albumId)
                                                  .Select(albumSong => albumSong.SongId)
                                                  .ToList();

            return 0.9 * unitOfWork.SongRepository
                                   .GetAll()
                                   .Where(song => songIdsForAlbum.Contains(song.Id))
                                   .Sum(song => song.Price);
        }

        [HttpGet]
        [Route("api/home")]
        public ActionResult GetHomeAlbums()
        {
            try
            {
                return Ok(unitOfWork.AlbumRepository
                                    .GetAll()
                                    .OrderBy(album => CalculateAlbumPopularity(album.Id))
                                    .Take(10)
                                    .Select(album => new HomePageAlbum
                                    {
                                        Name = album.Name,
                                        Artist = album.Artist,
                                        AlbumCoverUrl = album.AlbumCoverUrl,
                                        Price = CalculateAlbumPrice(album.Id),
                                    })
                                    .ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/album")]
        public ActionResult GetAlbumDetail(int albumId)
        {
            try
            {
                List<int> songIdsForAlbum = unitOfWork.AlbumSongRepository
                                                  .GetAll()
                                                  .Where(albumSong => albumSong.AlbumId == albumId)
                                                  .Select(albumSong => albumSong.SongId)
                                                  .ToList();

                List<Song> albumSongs = unitOfWork.SongRepository
                                                  .GetAll()
                                                  .Where(song => songIdsForAlbum.Contains(song.Id))
                                                  .ToList();

                return Ok(new AlbumDetail()
                {
                    Album = unitOfWork.AlbumRepository.GetById(albumId),
                    Songs = albumSongs
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/album/score")]
        public ActionResult SetAlbumScore(int albumId, int score)
        {
            try
            {
                Album theAlbum = unitOfWork.AlbumRepository.GetById(albumId);
                theAlbum.Score = score;
                unitOfWork.AlbumRepository.Update(theAlbum);
                unitOfWork.Commit();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/album/buy")]
        public ActionResult BuyAlbum(int userId, int albumId)
        {
            try
            {
                User theUser = unitOfWork.UserRepository.GetById(userId);

                List<int> boughtUserSongs = unitOfWork.UserSongRepository
                                                      .GetAll()
                                                      .Where(userSong => userSong.UserId == userId)
                                                      .Select(userSong => userSong.SongId)
                                                      .ToList();

                List<Song> songsToBuy = unitOfWork.AlbumSongRepository
                                                  .GetAll()
                                                  .Where(albumSong => albumSong.AlbumId == albumId 
                                                                      && !boughtUserSongs.Contains(albumSong.SongId))
                                                  .Select(albumSong => albumSong.Song)
                                                  .ToList();

                foreach(Song song in songsToBuy)
                {
                    unitOfWork.UserSongRepository.Create(new UserSong()
                    {
                        User = theUser,
                        UserId = theUser.Id,
                        Song = song,
                        SongId = song.Id
                    });
                }

                unitOfWork.UserAlbumRepository.Create(new UserAlbum()
                {
                    User = theUser,
                    UserId = theUser.Id,
                    Album = unitOfWork.AlbumRepository.GetById(albumId),
                    AlbumId = albumId
                });

                unitOfWork.Commit();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/profile")]
        public ActionResult GetProfileAlbums(int userId)
        {
            try
            {
                List<Album> userAlbums = unitOfWork.UserAlbumRepository
                                                   .GetAll()
                                                   .Where(userAlbum => userAlbum.UserId == userId)
                                                   .Select(userAlbum => userAlbum.Album)
                                                   .ToList();

                List<int> boughtUserSongs = unitOfWork.UserSongRepository
                                                      .GetAll()
                                                      .Where(userSong => userSong.UserId == userId)
                                                      .Select(userSong => userSong.SongId)
                                                      .ToList();

                List<ProfilePageAlbum> result = new List<ProfilePageAlbum>();
                List<int> songIdsForAlbum;

                foreach(Album album in userAlbums)
                {
                    songIdsForAlbum = unitOfWork.AlbumSongRepository
                                                .GetAll()
                                                .Where(albumSong => albumSong.AlbumId == album.Id)
                                                .Select(albumSong => albumSong.SongId)
                                                .ToList();

                    result.Add(new ProfilePageAlbum()
                    {
                        Name = album.Name,
                        Artist = album.Artist,
                        AlbumCoverUrl = album.AlbumCoverUrl,
                        Duration = unitOfWork.SongRepository
                                             .GetAll()
                                             .Where(song => songIdsForAlbum.Contains(song.Id)
                                                            && boughtUserSongs.Contains(song.Id))
                                             .Sum(song => song.Duration)
                    });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
