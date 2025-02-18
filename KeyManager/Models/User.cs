using System.ComponentModel.DataAnnotations;

namespace KeyManager.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public long? SSN { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
