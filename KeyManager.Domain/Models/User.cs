namespace KeyManager.Domain.Models;

public class User
{
    /// <summary>
    /// The unique identifier for the user.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The first name of the user.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// The last name of the user.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// The Personal number of the user.
    /// </summary>
    public long? Pnum { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the user.
    /// </summary>
    public string? Email { get; set; }
}
