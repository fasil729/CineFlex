namespace Application.DTOs.Movie;
public class UpdateMovieDTO : BaseDTO
{
    public int MovieId { get; set; }
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public int? ReleaseYear { get; set; }
    
    public int? MovieLength { get; set; }
    public string? Plot { get; set; }
    public required string UpdatedBy { get; set; }
}