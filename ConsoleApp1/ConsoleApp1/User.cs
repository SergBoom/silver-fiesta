using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebric
{
    public class User
    {
        public readonly int Id;
        public string PhoneNumber { get; private set; }

        public User(int id, string phoneNumber)
        {
            Id = id;
            PhoneNumber = phoneNumber;
        }
    }
}
