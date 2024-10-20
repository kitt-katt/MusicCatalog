namespace MusicCatalogAppUI.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;  // Убедитесь, что это пространство имен подключено

    public class Album
    {
        public string Title { get; set; }
        
        [JsonIgnore]  // Игнорируем сериализацию артиста, чтобы избежать циклической зависимости
        public Artist Artist { get; set; }
        
        public List<Track> Tracks { get; set; } = new List<Track>();
        public DateTime ReleaseDate { get; set; }

        public Album(string title, Artist artist, DateTime releaseDate)
        {
            Title = title;
            Artist = artist;
            ReleaseDate = releaseDate;
        }

        public override string ToString()
        {
            return $"{Title} by {Artist.Name} (Released: {ReleaseDate:yyyy-MM-dd})";
        }
    }
}