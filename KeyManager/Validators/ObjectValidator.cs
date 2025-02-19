using KeyManager.Models;

namespace KeyManager.Validators
{

    public class ObjectValidator
    {
        public bool CheckId<T>(T obj) where T : class, IIdentifier
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.Id == 0)
            {
                return false;
            }

            return true;
        }
    }
}