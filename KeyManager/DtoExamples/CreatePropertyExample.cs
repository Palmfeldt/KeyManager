using KeyManager.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace KeyManager.DtoExamples;

public class CreatePropertyExample : IExamplesProvider<PropertyDto>
{
    public PropertyDto GetExamples()
    {
        return new PropertyDto
        {
            Id = 11,
            FullAddress = "TestGatan 8",
            LeaseStart = DateTime.SpecifyKind(new DateTime(2025, 1, 12), DateTimeKind.Utc),
            LeaseEnd = DateTime.SpecifyKind(new DateTime(2027, 1, 12), DateTimeKind.Utc)
        };
    }
}
