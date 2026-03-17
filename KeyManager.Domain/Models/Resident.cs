namespace KeyManager.Domain.Models;

public class Resident
{
    /// <summary>
    /// The unique identifier for the resident living in the propety.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The first name of the resident.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// The last name of the resident.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// The Personal number of the resident.
    /// </summary>
    public long? Pnum { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the resident.
    /// </summary>
    public string? Email { get; set; }

    // A user can have multiple addresses
    public List<Key>? Keys { get; set; }

    // A user can have multiple addresses
    public List<Property>? Properties { get; set; }
}
