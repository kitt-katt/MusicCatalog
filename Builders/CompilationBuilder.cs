namespace MusicCatalogAppUI.Builders
{
    using MusicCatalogAppUI.Models;

    public class CompilationBuilder
    {
        private Compilation _compilation;

        public CompilationBuilder(string title)
        {
            _compilation = new Compilation(title);
        }

        public CompilationBuilder AddTrack(Track track)
        {
            _compilation.Tracks.Add(track);
            return this;
        }

        public Compilation Build()
        {
            return _compilation;
        }
    }
}