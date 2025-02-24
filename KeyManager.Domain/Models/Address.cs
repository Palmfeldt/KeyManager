using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KeyManager.Domain.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime LeaseStart { get; set; }

        public DateTime? LeaseEnd { get; set; }

        [MaxLength(50)]
        public string FullAddress { get; set; }

        [ForeignKey("Id")]
        public User User { get; set; }

        [ForeignKey("Id")]
        public Key Key { get; set; }
    }
    
}
