using MusicCatalogAppUI.Models;
using MusicCatalogAppUI.Builders;
using MusicCatalogAppUI.Factories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicCatalogAppUI.Services
{
    public class MusicCatalog
    {
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<Compilation> Compilations { get; set; } = new List<Compilation>();
        private readonly string _filePath = "music_catalog.json";

        public void AddArtist(Artist artist)
        {
            Artists.Add(artist);
        }

        public void AddCompilation(Compilation compilation)
        {
            Compilations.Add(compilation);
        }

        public bool DataExists()
        {
            return File.Exists(_filePath);
        }

        public void SaveToFile()
        {
            var data = new
            {
                Artists = Artists,
                Compilations = Compilations
            };
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        public void LoadFromFile()
        {
            if (File.Exists(_filePath))
            {
                var data = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(_filePath));
                Artists = JsonConvert.DeserializeObject<List<Artist>>(Convert.ToString(data.Artists));
                Compilations = JsonConvert.DeserializeObject<List<Compilation>>(Convert.ToString(data.Compilations));

                RestoreArtistAlbumRelationships();
            }
        }

        private void RestoreArtistAlbumRelationships()
        {
            foreach (var artist in Artists)
            {
                foreach (var album in artist.Albums)
                {
                    album.Artist = artist;
                }
            }
        }

        public void CreateInitialData()
        {
            // Артист 1: Кино
            var kino = MusicFactory.CreateArtist("Кино");

            var kinoAlbum1 = new AlbumBuilder("46", kino, new DateTime(1983, 12, 1))
                .AddTrack(MusicFactory.CreateTrack("Электричка", new TimeSpan(0, 5, 14), Genre.Rock))
                .AddTrack(MusicFactory.CreateTrack("Троллейбус", new TimeSpan(0, 3, 22), Genre.Rock))
                .Build();

            var kinoAlbum2 = new AlbumBuilder("47", kino, new DateTime(1984, 5, 15))
                .AddTrack(MusicFactory.CreateTrack("Группа крови", new TimeSpan(0, 4, 46), Genre.Rock))
                .AddTrack(MusicFactory.CreateTrack("Война", new TimeSpan(0, 4, 03), Genre.Rock))
                .Build();

            kino.Albums.Add(kinoAlbum1);
            kino.Albums.Add(kinoAlbum2);

            // Артист 2: Король и Шут
            var korolIShut = MusicFactory.CreateArtist("Король и Шут");

            var kishAlbum1 = new AlbumBuilder("Жаль, нет ружья", korolIShut, new DateTime(1994, 9, 10))
                .AddTrack(MusicFactory.CreateTrack("Лесник", new TimeSpan(0, 4, 57), Genre.Rock))
                .AddTrack(MusicFactory.CreateTrack("Кукла колдуна", new TimeSpan(0, 5, 36), Genre.Rock))
                .Build();

            var kishAlbum2 = new AlbumBuilder("Камнем по голове", korolIShut, new DateTime(1997, 8, 20))
                .AddTrack(MusicFactory.CreateTrack("Прыгну со скалы", new TimeSpan(0, 3, 42), Genre.Rock))
                .AddTrack(MusicFactory.CreateTrack("Мёртвый анархист", new TimeSpan(0, 4, 21), Genre.Rock))
                .Build();

            korolIShut.Albums.Add(kishAlbum1);
            korolIShut.Albums.Add(kishAlbum2);

            // Артист 3: Машина Времени
            var mashinaVremeni = MusicFactory.CreateArtist("Машина Времени");

            var mvAlbum1 = new AlbumBuilder("Лучшие песни", mashinaVremeni, new DateTime(1985, 7, 1))
                .AddTrack(MusicFactory.CreateTrack("Поворот", new TimeSpan(0, 4, 31), Genre.Rock))
                .AddTrack(MusicFactory.CreateTrack("Скачки", new TimeSpan(0, 4, 20), Genre.Rock))
                .Build();

            var mvAlbum2 = new AlbumBuilder("В добрый час", mashinaVremeni, new DateTime(1979, 3, 15))
                .AddTrack(MusicFactory.CreateTrack("Марионетки", new TimeSpan(0, 5, 32), Genre.Rock))
                .AddTrack(MusicFactory.CreateTrack("Синяя птица", new TimeSpan(0, 4, 42), Genre.Rock))
                .Build();

            mashinaVremeni.Albums.Add(mvAlbum1);
            mashinaVremeni.Albums.Add(mvAlbum2);

            // Артист 4: Сплин
            var splin = MusicFactory.CreateArtist("Сплин");

            var splinAlbum1 = new AlbumBuilder("Альтависта", splin, new DateTime(1999, 5, 1))
                .AddTrack(MusicFactory.CreateTrack("Орбит без сахара", new TimeSpan(0, 3, 57), Genre.Rock))
                .AddTrack(MusicFactory.CreateTrack("Выхода нет", new TimeSpan(0, 4, 10), Genre.Rock))
                .Build();

            var splinAlbum2 = new AlbumBuilder("Фонарь под глазом", splin, new DateTime(1997, 10, 20))
                .AddTrack(MusicFactory.CreateTrack("Линия жизни", new TimeSpan(0, 4, 12), Genre.Rock))
                .AddTrack(MusicFactory.CreateTrack("Романс", new TimeSpan(0, 5, 05), Genre.Rock))
                .Build();

            splin.Albums.Add(splinAlbum1);
            splin.Albums.Add(splinAlbum2);

            // Артист 5: ДДТ
            var ddt = MusicFactory.CreateArtist("ДДТ");

            var ddtAlbum1 = new AlbumBuilder("Пропавший без вести", ddt, new DateTime(2000, 12, 3))
                .AddTrack(MusicFactory.CreateTrack("Что такое осень", new TimeSpan(0, 4, 43), Genre.Rock))
                .AddTrack(MusicFactory.CreateTrack("Это всё", new TimeSpan(0, 5, 30), Genre.Rock))
                .Build();

            var ddtAlbum2 = new AlbumBuilder("Мир номер ноль", ddt, new DateTime(1998, 9, 12))
                .AddTrack(MusicFactory.CreateTrack("Родина", new TimeSpan(0, 4, 10), Genre.Rock))
                .AddTrack(MusicFactory.CreateTrack("Танцуй", new TimeSpan(0, 4, 55), Genre.Rock))
                .Build();

            ddt.Albums.Add(ddtAlbum1);
            ddt.Albums.Add(ddtAlbum2);

            AddArtist(kino);
            AddArtist(korolIShut);
            AddArtist(mashinaVremeni);
            AddArtist(splin);
            AddArtist(ddt);

            // Создаем несколько сборников
            var compilation1 = new CompilationBuilder("Русский рок - Легенды")
                .AddTrack(kinoAlbum1.Tracks[0])
                .AddTrack(kishAlbum1.Tracks[0])
                .AddTrack(mvAlbum1.Tracks[0])
                .AddTrack(splinAlbum1.Tracks[0])
                .AddTrack(ddtAlbum1.Tracks[0])
                .Build();

            var compilation2 = new CompilationBuilder("Классика русского рока")
                .AddTrack(kinoAlbum2.Tracks[0])
                .AddTrack(kishAlbum2.Tracks[1])
                .AddTrack(mvAlbum2.Tracks[1])
                .AddTrack(splinAlbum2.Tracks[1])
                .AddTrack(ddtAlbum2.Tracks[1])
                .Build();

            AddCompilation(compilation1);
            AddCompilation(compilation2);

            SaveToFile();
        }

    }
}
