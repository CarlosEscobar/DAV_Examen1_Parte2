﻿namespace examen1_api.data_access.Entities
{
    public class AlbumSong
    {
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
