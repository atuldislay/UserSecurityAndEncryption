using System;
using System.Security.Cryptography;
using System.Text;

namespace UserSecurityAndEncryption.EncryptionLayer
{
    internal class Sha1Encryptor
    {
        /// <summary>
        /// take any string and encrypt it using SHA1 then
        /// return the encrypted data
        /// </summary>
        /// <param name="data">input text you will enterd to encrypt it</param>
        /// <returns>return the encrypted text as hexadecimal string</returns>
        private string GetSHA1HashData(string data)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();

            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            var returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            foreach (byte b in hashData)
            {
                returnValue.Append(b.ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }

        /// <summary>
        /// encrypt input text using SHA1 and compare it with
        /// the stored encrypted text
        /// </summary>
        /// <param name="inputData">input text you will enterd to encrypt it</param>
        /// <param name="storedHashData">the encrypted text stored on file or database ... etc</param>
        /// <returns>true or false depending on input validation</returns>
        private bool ValidateSHA1HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = GetSHA1HashData(inputData);

            if (String.CompareOrdinal(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            return false;
        }
    }
}
