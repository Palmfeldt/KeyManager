namespace KeyManager.Dtos;

public record UserDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public long? Pnum { get; set; }
    public string? Email { get; set; }
}
