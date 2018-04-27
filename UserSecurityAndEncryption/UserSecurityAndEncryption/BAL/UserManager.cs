using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Documents;
using UserSecurityAndEncryption.DAL;

namespace UserSecurityAndEncryption.BAL
{
    public class UserManager
    {

        public static IEnumerable<T_User> GetAllUsers()
        {
            var userSecurityAndEncryptionDbEntities = new UserSecurityAndEncryptionDBEntities();
            List<T_User> userList = userSecurityAndEncryptionDbEntities.T_User.ToList();
            return userList;
        }
    }
}
