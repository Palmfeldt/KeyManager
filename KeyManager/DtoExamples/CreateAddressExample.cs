using KeyManager.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace KeyManager.DtoExamples;

public class CreateAddressExample : IExamplesProvider<AddressDto>
{
    public AddressDto GetExamples()
    {
        return new AddressDto
        {
            Id = 11,
            FullAddress = "TestGatan 8",
            LeaseStart = new DateTime(2025, 1, 12),
            LeaseEnd = new DateTime(2027, 1, 12)
        };
    }
}
