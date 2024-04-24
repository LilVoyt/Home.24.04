using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    internal class Worker
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Passport> Passports { get; set; }
        public DateTime Birthdate { get; set; }
        public SqlMoney Salary { get; set; }

        public Worker(string name, string surname, Passport passport, DateTime birthdate, SqlMoney salary)
        {
            Name = name;
            Surname = surname;
            Passports = new List<Passport>
            {
                passport
            };
            Birthdate = birthdate;
            Salary = salary;
        }

        public void EnlargeSalary(SqlMoney amount)
        {
            this.Salary += amount;
        }
        public void ReduceSalary(SqlMoney amount)
        {
            if (Salary >= amount)
            {
                this.Salary -= amount;
            }
            else if (Salary < amount)
            {
                this.Salary = 0;
            }
        }
        public static SqlMoney operator +(Worker worker, SqlMoney amount)
        {
            worker.EnlargeSalary(amount);
            return worker.Salary;
        }
        public static SqlMoney operator -(Worker worker, SqlMoney amount)
        {
            worker.ReduceSalary(amount);
            return worker.Salary;
        }
        public string PrintPassports()
        {
            StringBuilder sb = new StringBuilder(); //Класна штука для роботи з стрінгом, бо вона може міняти вже створений стрінг
            foreach (Passport passport in Passports)
            {
                sb.Append($"Id: {passport.Id}, Name: {passport.Name} {passport.Surname}, Country: {passport.Country}");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"Name: {Name} {Surname}, Passports: [{PrintPassports()}], Birthdate: {Birthdate:yyyy-MM-dd}, Salary: {Salary} ";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Worker operator +(Worker worker, Passport passport)
        {
            worker.Passports.Add(passport);
            return worker;
        }
        public static Worker operator -(Worker worker, Passport passport)
        {
            if (worker.Passports.Contains(passport))
            {
                worker.Passports.Remove(passport);
                return worker;
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}
