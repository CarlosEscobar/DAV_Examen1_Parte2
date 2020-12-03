using examen1_api.data_access.Context;
using examen1_api.data_access.Entities;
using examen1_api.data_access.Repositories;
using System.Threading.Tasks;

namespace examen1_api.data_access.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Examen1DbContext dbContext;
        public GenericRepository<User> UserRepository { get; private set; }
        public GenericRepository<Album> AlbumRepository { get; private set; }
        public GenericRepository<Song> SongRepository { get; private set; }
        public GenericRepository<UserAlbum> UserAlbumRepository { get; private set; }
        public GenericRepository<UserSong> UserSongRepository { get; private set; }
        public GenericRepository<AlbumSong> AlbumSongRepository { get; private set; }

        public UnitOfWork(Examen1DbContext context)
        {
            dbContext = context;
            UserRepository = new GenericRepository<User>(dbContext);
            AlbumRepository = new GenericRepository<Album>(dbContext);
            SongRepository = new GenericRepository<Song>(dbContext);
            UserAlbumRepository = new GenericRepository<UserAlbum>(dbContext);
            UserSongRepository = new GenericRepository<UserSong>(dbContext);
            AlbumSongRepository = new GenericRepository<AlbumSong>(dbContext);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public async Task Commit()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
