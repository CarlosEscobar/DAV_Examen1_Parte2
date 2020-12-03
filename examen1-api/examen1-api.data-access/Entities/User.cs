using System.Collections.Generic;

namespace examen1_api.data_access.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public ICollection<UserAlbum> UserAlbums { get; set; }
        public ICollection<UserSong> UserSongs { get; set; }
    }
}
