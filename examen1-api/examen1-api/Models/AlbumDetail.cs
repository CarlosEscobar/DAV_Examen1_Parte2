using examen1_api.data_access.Entities;
using System.Collections.Generic;

namespace examen1_api.Models
{
    public class AlbumDetail
    {
        public Album Album { get; set; }
        public List<Song> Songs { get; set; }
    }
}
