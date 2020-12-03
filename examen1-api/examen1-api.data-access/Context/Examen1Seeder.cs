using examen1_api.data_access.Entities;
using examen1_api.data_access.UnitOfWork;
using System;

namespace examen1_api.data_access.Context
{
    public static class Examen1Seeder
    {
        public static void SeedData(IUnitOfWork unitOfWork)
        {
            //Test User
            User testUser = new User()
            {
                Id = 1,
                Username = "TestUser"
            };

            //Test albums
            Album album1 = new Album()
            {
                Id = 1,
                Name = "Album1",
                Artist = "Artist1",
                Score = 1,
                AlbumCoverUrl = "https://www.attackmagazine.com/wp-content/uploads/2014/11/artworks-000097027932-szvmrm-t500x500-500x479.jpg",
                Genre = "Genre1",
                ReleaseDate = DateTime.Now,
                Description = "Description1"
            };

            Album album2 = new Album()
            {
                Id = 2,
                Name = "Album2",
                Artist = "Artist2",
                Score = 2,
                AlbumCoverUrl = "https://miro.medium.com/focal/1200/1200/50/40/1*8FkvzbSdSJ4HNxtuZo5kLg.jpeg",
                Genre = "Genre2",
                ReleaseDate = DateTime.Now,
                Description = "Description2"
            };

            Album album3 = new Album()
            {
                Id = 3,
                Name = "Album3",
                Artist = "Artist3",
                Score = 3,
                AlbumCoverUrl = "https://cms-assets.tutsplus.com/uploads/users/114/posts/34296/image/Final-image.jpg",
                Genre = "Genre3",
                ReleaseDate = DateTime.Now,
                Description = "Description3"
            };

            //Test Songs
            Song album1_song1 = new Song()
            {
                Id = 1,
                Name = "A1Song1",
                Artist = "Artist1",
                Duration = 100,
                Popularity = 1,
                Price = 0.99
            };

            Song album1_song2 = new Song()
            {
                Id = 2,
                Name = "A1Song2",
                Artist = "Artist1",
                Duration = 10,
                Popularity = 2,
                Price = 0.99
            };

            Song album1_song3 = new Song()
            {
                Id = 3,
                Name = "A1Song3",
                Artist = "Artist1",
                Duration = 1,
                Popularity = 3,
                Price = 0.99
            };

            Song album2_song1 = new Song()
            {
                Id = 4,
                Name = "A2Song1",
                Artist = "Artist2",
                Duration = 200,
                Popularity = 1,
                Price = 0.99
            };

            Song album2_song2 = new Song()
            {
                Id = 5,
                Name = "A2Song2",
                Artist = "Artist2",
                Duration = 20,
                Popularity = 2,
                Price = 0.99
            };

            Song album3_song1 = new Song()
            {
                Id = 6,
                Name = "A3Song1",
                Artist = "Artist3",
                Duration = 3000,
                Popularity = 1,
                Price = 0.99
            };

            Song album3_song2 = new Song()
            {
                Id = 7,
                Name = "A3Song2",
                Artist = "Artist3",
                Duration = 300,
                Popularity = 2,
                Price = 0.99
            };

            Song album3_song3 = new Song()
            {
                Id = 8,
                Name = "A3Song3",
                Artist = "Artist3",
                Duration = 30,
                Popularity = 3,
                Price = 0.99
            };

            Song album3_song4 = new Song()
            {
                Id = 9,
                Name = "A3Song4",
                Artist = "Artist3",
                Duration = 3,
                Popularity = 4,
                Price = 0.99
            };

            //Album Songs
            AlbumSong album1song1 = new AlbumSong()
            {
                Album = album1,
                AlbumId = 1,
                Song = album1_song1,
                SongId = 1
            };

            AlbumSong album1song2 = new AlbumSong()
            {
                Album = album1,
                AlbumId = 1,
                Song = album1_song2,
                SongId = 2
            };

            AlbumSong album1song3 = new AlbumSong()
            {
                Album = album1,
                AlbumId = 1,
                Song = album1_song3,
                SongId = 3
            };

            AlbumSong album2song1 = new AlbumSong()
            {
                Album = album2,
                AlbumId = 2,
                Song = album2_song1,
                SongId = 4
            };

            AlbumSong album2song2 = new AlbumSong()
            {
                Album = album2,
                AlbumId = 2,
                Song = album2_song2,
                SongId = 5
            };

            AlbumSong album3song1 = new AlbumSong()
            {
                Album = album3,
                AlbumId = 3,
                Song = album3_song1,
                SongId = 6
            };

            AlbumSong album3song2 = new AlbumSong()
            {
                Album = album3,
                AlbumId = 3,
                Song = album3_song2,
                SongId = 7
            };

            AlbumSong album3song3 = new AlbumSong()
            {
                Album = album3,
                AlbumId = 3,
                Song = album3_song3,
                SongId = 8
            };

            AlbumSong album3song4 = new AlbumSong()
            {
                Album = album3,
                AlbumId = 3,
                Song = album3_song4,
                SongId = 9
            };

            //Add Data
            unitOfWork.UserRepository.Create(testUser);

            unitOfWork.AlbumRepository.Create(album1);
            unitOfWork.AlbumRepository.Create(album2);
            unitOfWork.AlbumRepository.Create(album3);

            unitOfWork.SongRepository.Create(album1_song1);
            unitOfWork.SongRepository.Create(album1_song2);
            unitOfWork.SongRepository.Create(album1_song3);
            unitOfWork.SongRepository.Create(album2_song1);
            unitOfWork.SongRepository.Create(album2_song2);
            unitOfWork.SongRepository.Create(album3_song1);
            unitOfWork.SongRepository.Create(album3_song2);
            unitOfWork.SongRepository.Create(album3_song3);
            unitOfWork.SongRepository.Create(album3_song4);

            unitOfWork.AlbumSongRepository.Create(album1song1);
            unitOfWork.AlbumSongRepository.Create(album1song2);
            unitOfWork.AlbumSongRepository.Create(album1song3);
            unitOfWork.AlbumSongRepository.Create(album2song1);
            unitOfWork.AlbumSongRepository.Create(album2song2);
            unitOfWork.AlbumSongRepository.Create(album3song1);
            unitOfWork.AlbumSongRepository.Create(album3song2);
            unitOfWork.AlbumSongRepository.Create(album3song3);
            unitOfWork.AlbumSongRepository.Create(album3song4);

            unitOfWork.Commit();
        }
    }
}
