using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeyManager.Persistence.DatabaseModels;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public required string FirstName { get; set; }

    [Required, MaxLength(50)]
    public required string LastName { get; set; }

    public long? Pnum { get; set; }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}
