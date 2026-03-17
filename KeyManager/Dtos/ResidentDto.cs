namespace KeyManager.Dtos;

public record ResidentDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public long? Pnum { get; set; }
    public string? Email { get; set; }
}
