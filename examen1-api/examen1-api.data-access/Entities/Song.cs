using System.Collections.Generic;

namespace examen1_api.data_access.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public int Popularity { get; set; }
        public double Price { get; set; }

        public ICollection<AlbumSong> AlbumSongs { get; set; }
        public ICollection<UserSong> UserSongs { get; set; }
    }
}
