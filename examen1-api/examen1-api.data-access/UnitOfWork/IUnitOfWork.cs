using examen1_api.data_access.Entities;
using examen1_api.data_access.Repositories;
using System;
using System.Threading.Tasks;

namespace examen1_api.data_access.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<User> UserRepository { get; }
        GenericRepository<Album> AlbumRepository { get; }
        GenericRepository<Song> SongRepository { get; }
        GenericRepository<UserAlbum> UserAlbumRepository { get; }
        GenericRepository<UserSong> UserSongRepository { get; }
        GenericRepository<AlbumSong> AlbumSongRepository { get; }
        Task Commit();
    }
}