using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Home
{
    internal class Builder : Worker
    {
        public int BuilderImpactIndex { get; set; }

        public Builder(string name, string surname, Passport passport, DateTime birthdate, SqlMoney salary, int builderImpactIndex)
        : base(name, surname, passport, birthdate, salary)
        {
            BuilderImpactIndex = builderImpactIndex;
        }
        public bool CompareBuilders(Builder other)
        {
            return this.BuilderImpactIndex <= other.BuilderImpactIndex;
        }
        public bool IsTheSame(Builder other)
        {
            return this.BuilderImpactIndex == other.BuilderImpactIndex;
        }
        public static bool operator <(Builder a, Builder b)
        {
            return a.CompareBuilders(b);
        }
        public static bool operator >(Builder a, Builder b)
        {
            return b.CompareBuilders(a);
        }
        public static bool operator ==(Builder a, Builder b)
        {
            return a.IsTheSame(b);
        }
        public static bool operator !=(Builder a, Builder b)
        {
            return !(a.IsTheSame(b));
        }
    }
}
