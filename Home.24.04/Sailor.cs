using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home._24._04
{
    internal class Sailor : Worker
    {
        public int HourExperience { get; set; }
        public Sailor(string name, string surname, Passport passport, DateTime birthdate, SqlMoney salary, int hourExperience)
        : base(name, surname, passport, birthdate, salary)
        {
            HourExperience = hourExperience;
        }
        public bool CompareSailors(Sailor other)
        {
            return this.HourExperience <= other.HourExperience;
        }
        public bool IsTheSame(Sailor other)
        {
            return this.HourExperience == other.HourExperience;
        }
        public static bool operator <(Sailor a, Sailor b)
        {
            return a.CompareSailors(b);
        }
        public static bool operator >(Sailor a, Sailor b)
        {
            return b.CompareSailors(a);
        }
        public static bool operator ==(Sailor a, Sailor b)
        {
            return a.IsTheSame(b);
        }
        public static bool operator !=(Sailor a, Sailor b)
        {
            return !(a.IsTheSame(b));
        }
    }
}
