namespace KeyManager.Domain.Models;

public class Property
{
    /// <summary>
    /// The unique identifier for the address.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The full address of the property.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// The start date and time of the lease period.
    /// </summary>
    public DateTime LeaseStart { get; set; }

    /// <summary>
    /// The end date of the lease period. Nullable if the lease is ongoing.
    /// </summary>
    public DateTime? LeaseEnd { get; set; }


    public int ResidentId { get; set; }
    /// <summary>
    /// A Property can be associated with one user
    /// </summary>
    public Resident? Resident { get; set; }

    /// <summary>
    /// Gets or sets the key associated with the current object.
    /// </summary>
    /// <remarks>
    /// Note that this is supposed to be a physical door key associated with the address.
    /// </remarks>
    public List<Key>? Keys { get; set; }
}
