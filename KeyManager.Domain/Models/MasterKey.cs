using KeyManager.Domain.Models.KeyAttribures;

namespace KeyManager.Domain.Models;

public class MasterKey
{

    /// <summary>
    /// The unique identifier for the key.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The key identifier of the key. Often represents the serial number or bitting key code.
    /// </summary>
    public required string KeyIdentifier { get; set; }

    /// <summary>
    /// The brand of the key.
    /// </summary>
    public required Brand Brand { get; set; }

    /// <summary>
    /// A master key can be used to unlock multiple properties, and a property can be associated with multiple master keys. This is a many-to-many relationship.
    /// </summary>
    public List<Property>? Properties { get; set; }
}
