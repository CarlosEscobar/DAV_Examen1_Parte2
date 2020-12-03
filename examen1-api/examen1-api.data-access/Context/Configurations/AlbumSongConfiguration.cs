using examen1_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examen1_api.data_access.Context
{
    public class AlbumSongConfiguration : IEntityTypeConfiguration<AlbumSong>
    {
        public void Configure(EntityTypeBuilder<AlbumSong> builder)
        {
            builder.HasKey(albumSong => new { albumSong.AlbumId, albumSong.SongId });

            builder.HasOne(albumSong => albumSong.Album)
                   .WithMany(album => album.AlbumSongs)
                   .HasForeignKey(albumSong => albumSong.AlbumId);

            builder.HasOne(albumSong => albumSong.Song)
                   .WithMany(song => song.AlbumSongs)
                   .HasForeignKey(albumSong => albumSong.SongId);
        }
    }
}
