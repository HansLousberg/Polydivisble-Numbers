using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace polydivisibleWithDatabase
{
    class Program
    {
        
        static void Main(string[] args)
        {
            PolynumberFinder finder1 = new PolynumberFinder();
            for (int numbersystem = 4; numbersystem <= 35; numbersystem=numbersystem+2)
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                finder1.Numbersystem = numbersystem;
                finder1.Length = numbersystem-1;
                finder1.DuplicateNumbers = false;
                finder1.BatchSize = 1000;

                List<Polynumber> resultList = finder1.GenerateList();

                foreach (Polynumber number in resultList)
                {
                    Console.WriteLine(number.ToString());
                }
                timer.Stop();
                Console.WriteLine("this was numbersystem: " + numbersystem.ToString() + " , and it took: " + timer.Elapsed.ToString() + " the number of numbers pushed to the DB: " + finder1.DBPushes.ToString() );
            }
            Console.WriteLine("end of program");
            Console.ReadLine();
        }
    }
}
