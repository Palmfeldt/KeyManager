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
}
