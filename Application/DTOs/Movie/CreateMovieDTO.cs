namespace Application.DTOs.Movie;
public class CreateMovieDTO
{
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public int MovieLength { get; set; }
    public required string Plot { get; set; }
    public required string CreatedBy { get; set; }
}
