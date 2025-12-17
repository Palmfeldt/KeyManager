using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KeyManager.Domain.Models;

namespace KeyManager.Persistence.DatabaseModels;

public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime LeaseStart { get; set; }

    public DateTime? LeaseEnd { get; set; }

    [Required, MaxLength(50)]
    public required string FullAddress { get; set; }

    [ForeignKey("Id")]
    public User? User { get; set; }

    [ForeignKey("Id")]
    public Key? Key { get; set; }
}

