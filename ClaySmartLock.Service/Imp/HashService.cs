using ClaySmartLock.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Imp
{
    public class HashService : IHashService
    {
        public string HashBySha512(string value)
        {
            using (var algorithm = SHA512.Create())
            {
                var hashedBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
