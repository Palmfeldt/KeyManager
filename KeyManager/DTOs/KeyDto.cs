using KeyManager.Domain.Models.KeyAttribures;

namespace KeyManager.DTOs;

public record KeyDto
{
    // TODO: Create a seperate DTO for creating a key
    public int Id { get; set; }
    public required string KeyIdentifier { get; set; }
    public required Brand Brand { get; set; }
}
