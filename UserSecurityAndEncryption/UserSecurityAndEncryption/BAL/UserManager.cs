using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Documents;
using System.Xml.Linq;
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

        public static string SaveUser(string userName, string passWord)
        {
            var userSecurityAndEncryptionDbEntities = new UserSecurityAndEncryptionDBEntities();
            var user = new T_User() { UserName = userName, Password = Sha1Encryptor.GetSHA1HashData(passWord) };
            userSecurityAndEncryptionDbEntities.T_User.Add(user);
            userSecurityAndEncryptionDbEntities.SaveChanges();
            return String.Empty;
        }

        public static bool CheckUserBasedOnUserName(string userName)
        {
            var userSecurityAndEncryptionDbEntities = new UserSecurityAndEncryptionDBEntities();
            return userSecurityAndEncryptionDbEntities.T_User.Count(user => user.UserName == userName) > 0;
        }

        public static string DeleteUser(string userName)
        {
            var userSecurityAndEncryptionDbEntities = new UserSecurityAndEncryptionDBEntities();
            T_User userToRemove =
                userSecurityAndEncryptionDbEntities.T_User.FirstOrDefault(user => user.UserName == userName);
            userSecurityAndEncryptionDbEntities.T_User.Remove(userToRemove);
            userSecurityAndEncryptionDbEntities.SaveChanges();
            return String.Empty;
        }

        public static void UpdateUser(string existingUserName, string userName, string passWord)
        {
         var userSecurityAndEncryptionDbEntities = new UserSecurityAndEncryptionDBEntities();
            T_User userToUpdate = userSecurityAndEncryptionDbEntities.T_User.FirstOrDefault(user => user.UserName == existingUserName);
            if (userToUpdate == null) return;
            userToUpdate.UserName = userName;
            userToUpdate.Password = Sha1Encryptor.GetSHA1HashData(passWord);
            userSecurityAndEncryptionDbEntities.SaveChanges();
        }
    }
}
