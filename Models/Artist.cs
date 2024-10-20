namespace MusicCatalogAppUI.Models
{
    using System.Collections.Generic;

    public class Artist
    {
        public string Name { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();

        public Artist(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}