namespace MusicCatalogAppUI.Models
{
    using System;

    public enum Genre
    {
        Rock,
        Pop,
        Jazz,
        Classical,
        HipHop
    }

    public class Track
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public Genre Genre { get; set; }

        public Track(string title, TimeSpan duration, Genre genre)
        {
            Title = title;
            Duration = duration;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} - {Duration:mm\\:ss} [{Genre}]";
        }
    }
}