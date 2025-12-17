using KeyManager.DTOs;

namespace KeyManager.Dtos;

public record AddressDto
{

    public required int Id { get; set; }

    public DateTime LeaseStart { get; set; }

    public DateTime? LeaseEnd { get; set; }

    public required string FullAddress { get; set; }

    public UserDto? User { get; set; }

    public KeyDto? Key { get; set; }
}
