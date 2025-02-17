namespace KeyManager.Models
{
    public class UserKey(
        string adress,
        User user,
        Key Key,
        DateTime startDate,
        DateTime endDate
        )
    {
        private string Adress { get; } = adress;
        private User User { get;  } = user;
        private Key Key = Key;
        // The date that the key was registed to the user
        private DateTime StartDate { get; } = startDate;
        private DateTime EndDate { get; set; } = endDate;

        /// <summary>
        /// Returns a formatted string of all the data
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return User + Key.ToString();
        }
    }
}
