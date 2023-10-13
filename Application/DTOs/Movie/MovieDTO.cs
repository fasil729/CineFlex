namespace Application.DTOs.Movie
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        
        public string Rating { get; set; }
        public int MovieLength { get; set; }
        public string Plot { get; set; }
    }
}