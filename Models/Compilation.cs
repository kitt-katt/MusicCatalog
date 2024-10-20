namespace MusicCatalogAppUI.Models
{
    using System.Collections.Generic;

    public class Compilation
    {
        public string Title { get; set; }
        public List<Track> Tracks { get; set; } = new List<Track>();

        public Compilation(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} [Compilation]";
        }
    }
}