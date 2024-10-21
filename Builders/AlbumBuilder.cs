namespace MusicCatalogAppUI.Builders
{
    using MusicCatalogAppUI.Models;
    using System;

    public class AlbumBuilder
    {
        private Album _album;

        public AlbumBuilder(string title, Artist artist, DateTime releaseDate)
        {
            _album = new Album(title, artist, releaseDate);
        }

        public AlbumBuilder AddTrack(Track track)
        {
            _album.Tracks.Add(track);
            return this;
        }

        public Album Build()
        {
            return _album;
        }
    }
}