namespace Tarea6Pweb.Models
{
    public  class Noticia
    {
        public Title? Title { get; set; }
        public Excerpt? Excerpt { get; set; }
    }

    public  class Excerpt
    {
        public string? Rendered { get; set; }
        public bool Protected { get; set; }
    }

    public  class Title
    {
        public string? Rendered { get; set; }
    }
}
