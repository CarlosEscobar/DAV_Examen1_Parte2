﻿namespace examen1_api.data_access.Entities
{
    public class UserAlbum
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
