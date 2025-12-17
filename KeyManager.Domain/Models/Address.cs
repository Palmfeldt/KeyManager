namespace KeyManager.Domain.Models;

public class Address
{
    /// <summary>
    /// The unique identifier for the address.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The start date and time of the lease period.
    /// </summary>
    public DateTime LeaseStart { get; set; }

    /// <summary>
    /// The end date of the lease period. Nullable if the lease is ongoing.
    /// </summary>
    public DateTime? LeaseEnd { get; set; }

    /// <summary>
    /// The full address of the property.
    /// </summary>
    public required string FullAddress { get; set; }

    /// <summary>
    /// The user associated with this address.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Gets or sets the key associated with the current object.
    /// </summary>
    /// <remarks>
    /// Note that this is supposed to be a phyiscal door key associated with the address.
    /// </remarks>
    public Key? Key { get; set; }
}

