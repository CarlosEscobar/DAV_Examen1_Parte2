using examen1_api.data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examen1_api.data_access.Context
{
    public class UserAlbumConfiguration : IEntityTypeConfiguration<UserAlbum>
    {
        public void Configure(EntityTypeBuilder<UserAlbum> builder)
        {
            builder.HasKey(userAlbum => new { userAlbum.UserId, userAlbum.AlbumId });

            builder.HasOne(userAlbum => userAlbum.User)
                   .WithMany(user => user.UserAlbums)
                   .HasForeignKey(userAlbum => userAlbum.UserId);

            builder.HasOne(userAlbum => userAlbum.Album)
                   .WithMany(album => album.UserAlbums)
                   .HasForeignKey(userAlbum => userAlbum.AlbumId);
        }
    }
}
