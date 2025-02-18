using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KeyManager.Models
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }

        public DateTime LeaseStart { get; set; }

        public DateTime? LeaseEnd { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [ForeignKey("Id")]
        public User User { get; set; }

        [ForeignKey("Id")]
        public Key Key { get; set; }
    }
    
}
