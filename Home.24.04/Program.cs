using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    internal class Program
    {
        static void Main()
        {
            Worker worker = new Worker("Oleg", "Voyt", new Passport(12, "Oleg", "Voyt", "Ua"), new DateTime(1990, 1, 1), new SqlMoney(1000));
            worker.Salary = worker + new SqlMoney(1000);
            Console.WriteLine(worker);
            worker.Salary = worker - new SqlMoney(500);
            Console.WriteLine(worker);

            Builder builder1 = new Builder("Roman", "First", new Passport(11, "Roman", "First", "Ua"), new DateTime(2000, 1, 1), new SqlMoney(500), 10);
            Builder builder2 = new Builder("Ihor", "Second", new Passport(10, "Oleg", "Second", "Ua"), new DateTime(2003, 1, 1), new SqlMoney(600), 15);
            Console.WriteLine(builder1 > builder2);
            Console.WriteLine(builder1 != builder2);
            Console.WriteLine(builder1.Equals(builder2));

            builder2 = (Builder)(builder2 + new Passport(11, "Ihor", "Second", "Us"));
            Console.WriteLine(builder2);
            worker = worker + new Passport(11, "Roman", "First", "Ua");
        }
    }
}
