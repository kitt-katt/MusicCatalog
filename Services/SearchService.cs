namespace MusicCatalogAppUI.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using MusicCatalogAppUI.Models;

    public class SearchService
    {
        private readonly MusicCatalog _catalog;

        public SearchService(MusicCatalog catalog)
        {
            _catalog = catalog;
        }

        public Artist SearchArtistByName(string name)
        {
            return _catalog.Artists.FirstOrDefault(a => a.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }

        public Album SearchAlbumByTitle(string title)
        {
            return _catalog.Artists
                .SelectMany(a => a.Albums)
                .FirstOrDefault(al => al.Title.Equals(title, System.StringComparison.OrdinalIgnoreCase));
        }

        public Track SearchTrackByTitle(string title)
        {
            var track = _catalog.Artists
                .SelectMany(a => a.Albums)
                .SelectMany(al => al.Tracks)
                .FirstOrDefault(t => t.Title.Equals(title, System.StringComparison.OrdinalIgnoreCase));

            if (track != null)
                return track;

            return _catalog.Compilations
                .SelectMany(c => c.Tracks)
                .FirstOrDefault(t => t.Title.Equals(title, System.StringComparison.OrdinalIgnoreCase));
        }

        public Compilation SearchCompilationByTitle(string title)
        {
            return _catalog.Compilations.FirstOrDefault(c => c.Title.Equals(title, System.StringComparison.OrdinalIgnoreCase));
        }

        // Метод для поиска альбома по треку
        public Album FindAlbumByTrack(Track track)
        {
            return _catalog.Artists
                .SelectMany(a => a.Albums)
                .FirstOrDefault(al => al.Tracks.Contains(track));
        }

        // Метод для поиска всех сборников, в которые входит трек
        public List<Compilation> FindCompilationsByTrack(Track track)
        {
            return _catalog.Compilations
                .Where(c => c.Tracks.Contains(track))
                .ToList();
        }
    }
}
