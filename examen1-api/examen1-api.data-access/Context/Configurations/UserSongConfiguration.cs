using examen1_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examen1_api.data_access.Context
{
    public class UserSongConfiguration : IEntityTypeConfiguration<UserSong>
    {
        public void Configure(EntityTypeBuilder<UserSong> builder)
        {
            builder.HasKey(userSong => new { userSong.UserId, userSong.SongId });

            builder.HasOne(userSong => userSong.User)
                   .WithMany(user => user.UserSongs)
                   .HasForeignKey(userSong => userSong.UserId);

            builder.HasOne(userSong => userSong.Song)
                   .WithMany(song => song.UserSongs)
                   .HasForeignKey(userSong => userSong.SongId);
        }
    }
}
