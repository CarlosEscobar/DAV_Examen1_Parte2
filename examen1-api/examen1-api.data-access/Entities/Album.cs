using System;
using System.Collections.Generic;

namespace examen1_api.data_access.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Score { get; set; }
        public string AlbumCoverUrl { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        public ICollection<UserAlbum> UserAlbums { get; set; }
        public ICollection<AlbumSong> AlbumSongs { get; set; }
    }
}
