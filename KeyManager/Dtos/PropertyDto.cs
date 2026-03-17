using KeyManager.DTOs;

namespace KeyManager.Dtos;

public record PropertyDto
{

    public required int Id { get; set; }

    public DateTime LeaseStart
    {
        get;
        set
        {
            field = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

    }

    public DateTime? LeaseEnd
    {
        get;
        set
        {
            if (value.HasValue)
                field = DateTime.SpecifyKind(value.Value, DateTimeKind.Utc);
        }
    }

    public required string FullAddress { get; set; }

    public ResidentDto? User { get; set; }

    public List<KeyDto>? Keys { get; set; }
}
