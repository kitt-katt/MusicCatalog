using MusicCatalogAppUI.Services;

namespace MusicCatalogAppUI.ViewModels
{
    public class MainWindowViewModel
    {
        private MusicCatalog _musicCatalog;
        private SearchService _searchService;

        public MainWindowViewModel()
        {
            _musicCatalog = new MusicCatalog();
            if (!_musicCatalog.DataExists())
            {
                _musicCatalog.CreateInitialData();
            }
            else
            {
                _musicCatalog.LoadFromFile();
            }

            _searchService = new SearchService(_musicCatalog);
        }

        // Метод для поиска по типу и запросу
        public string Search(string searchType, string searchQuery)
        {
            string result = string.Empty;

            switch (searchType)
            {
                case "Артист":
                    var artist = _searchService.SearchArtistByName(searchQuery);
                    if (artist != null)
                    {
                        result = $"Артист: {artist.Name}\nАльбомы:\n";
                        foreach (var album in artist.Albums)
                        {
                            result += $"{album.Title} - Дата выпуска: {album.ReleaseDate}\n";
                            foreach (var track in album.Tracks)
                            {
                                result += $"  Песня: {track.Title} - {track.Duration:mm\\:ss}\n";
                            }
                        }
                    }
                    else
                    {
                        result = "Артист не найден.";
                    }
                    break;

                case "Альбом":
                    var albumResult = _searchService.SearchAlbumByTitle(searchQuery);
                    if (albumResult != null)
                    {
                        result = $"Альбом: {albumResult.Title}\nАртист: {albumResult.Artist.Name}\nТреки:\n";
                        foreach (var track in albumResult.Tracks)
                        {
                            result += $"  {track.Title} - {track.Duration:mm\\:ss}\n";
                        }
                    }
                    else
                    {
                        result = "Альбом не найден.";
                    }
                    break;

                case "Песня":
                    var trackResult = _searchService.SearchTrackByTitle(searchQuery);
                    if (trackResult != null)
                    {
                        result = $"Песня: {trackResult.Title}\nЖанр: {trackResult.Genre}\nПродолжительность: {trackResult.Duration:mm\\:ss}\n";

                        var album = _searchService.FindAlbumByTrack(trackResult);
                        if (album != null)
                        {
                            result += $"Альбом: {album.Title}\nАртист: {album.Artist.Name}\n";
                        }
                        var compilations = _searchService.FindCompilationsByTrack(trackResult);
                        if (compilations.Count > 0)
                        {
                            result += "Сборники:\n";
                            foreach (var compilation in compilations)
                            {
                                result += $"  {compilation.Title}\n";
                            }
                        }
                    }
                    else
                    {
                        result = "Песня не найдена.";
                    }
                    break;

                case "Сборник":
                    var compilationResult = _searchService.SearchCompilationByTitle(searchQuery);
                    if (compilationResult != null)
                    {
                        result = $"Сборник: {compilationResult.Title}\nТреки:\n";
                        foreach (var track in compilationResult.Tracks)
                        {
                            // Получаем альбом трека для правильного отображения артиста
                            var album = _searchService.FindAlbumByTrack(track);
                            var artistName = album != null ? album.Artist.Name : "Неизвестный артист";
                            result += $"  {track.Title} - {track.Duration:mm\\:ss} [{track.Genre}] (Артист: {artistName})\n";
                        }
                    }
                    else
                    {
                        result = "Сборник не найден.";
                    }
                    break;

                default:
                    result = "Неверный выбор.";
                    break;
            }

            return result;
        }

        // Метод для отображения всех данных
        public string ShowAll()
        {
            string result = "Все артисты:\n";
            foreach (var artist in _musicCatalog.Artists)
            {
                result += $"{artist.Name}\nАльбомы:\n";
                foreach (var album in artist.Albums)
                {
                    result += $"  {album.Title} - Дата выпуска: {album.ReleaseDate}\n";
                    foreach (var track in album.Tracks)
                    {
                        result += $"    {track.Title} - {track.Duration:mm\\:ss}\n";
                    }
                }
            }

            result += "\nВсе сборники:\n";
            foreach (var compilation in _musicCatalog.Compilations)
            {
                result += $"{compilation.Title}\nТреки:\n";
                foreach (var track in compilation.Tracks)
                {
                    // Получаем альбом трека для правильного отображения артиста
                    var album = _searchService.FindAlbumByTrack(track);
                    var artistName = album != null ? album.Artist.Name : "Неизвестный артист";
                    result += $"  {track.Title} - {track.Duration:mm\\:ss} [{track.Genre}] (Артист: {artistName})\n";
                }
            }

            return result;
        }
    }
}
