using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    internal class Passport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }

        public Passport(int number, string name, string surname, string country)
        {
            Id = number;
            Name = name;
            Surname = surname;
            Country = country;
        }
    }
}
