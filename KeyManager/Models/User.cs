namespace KeyManager.Models
{
    public class User(string firstName, string lastName, int clientNumber, string keyIndentifier)
    {
        private string FirstName { get; set; } = firstName;
        private string LastName { get; set; } = lastName;
        private int ClientNumber { get; } = clientNumber;

 
    }
}
