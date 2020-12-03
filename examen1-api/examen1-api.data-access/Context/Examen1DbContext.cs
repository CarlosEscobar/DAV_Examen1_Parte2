using examen1_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;

namespace examen1_api.data_access.Context
{
    public class Examen1DbContext : DbContext
    {
        public Examen1DbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<UserAlbum> UserAlbums { get; set; }
        public DbSet<UserSong> UserSongs { get; set; }
        public DbSet<AlbumSong> AlbumSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new UserAlbumConfiguration());
            modelBuilder.ApplyConfiguration(new UserSongConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumSongConfiguration());
        }
    }
}
