namespace Application.DTOs.Cinema;
public class UpdateCinemaDTO : BaseDTO
{
    public int CinemaId { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? ContactInformation { get; set; }
    public required string UpdatedBy { get; set; }

}