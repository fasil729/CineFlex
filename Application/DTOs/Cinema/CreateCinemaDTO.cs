namespace Application.DTOs.Cinema;
public class CreateCinemaDTO
{
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required string ContactInformation { get; set; }
    public required string CreatedBy { get; set; }
}

