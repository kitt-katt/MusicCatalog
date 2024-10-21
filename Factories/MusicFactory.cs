namespace MusicCatalogAppUI.Factories
{
    using MusicCatalogAppUI.Models;
    using System;

    public static class MusicFactory
    {
        public static Artist CreateArtist(string name)
        {
            return new Artist(name);
        }

        public static Track CreateTrack(string title, TimeSpan duration, Genre genre)
        {
            return new Track(title, duration, genre);
        }

        public static Album CreateAlbum(string title, Artist artist, DateTime releaseDate)
        {
            return new Album(title, artist, releaseDate);
        }

        public static Compilation CreateCompilation(string title)
        {
            return new Compilation(title);
        }
    }
}