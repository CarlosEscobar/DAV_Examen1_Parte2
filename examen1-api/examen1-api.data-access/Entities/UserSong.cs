namespace examen1_api.data_access.Entities
{
    public class UserSong
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
