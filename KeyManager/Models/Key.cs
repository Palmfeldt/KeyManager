using System.ComponentModel.DataAnnotations;

namespace KeyManager.Models
{
    public class Key
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string KeyIdentifier { get; set; }
    }
}
