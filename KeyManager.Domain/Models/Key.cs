using KeyManager.Domain.Models.KeyAttribures;

namespace KeyManager.Domain.Models;

public class Key
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

    public bool IsLost { get; set; }

    public int? PropertyId { get; set; }

    // A key can be used to unlock a single property, but a property can have multiple keys. This is a one-to-many relationship.
    public Property? Property { get; set; }

    public int? ResidentId { get; set; }
    public Resident? Resident { get; set; }
}
