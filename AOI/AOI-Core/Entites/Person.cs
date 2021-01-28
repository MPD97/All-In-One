using System;
using System.Collections.Generic;
using System.Text;

namespace AOI_Core.Entites
{
    public class Person
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public GenderType Gender { get; set; }

        public string Phone { get; set; }
        public enum GenderType
        {
            Male = 0,
            Female = 1
        }
    }
}
