using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //dit is de console interface,de enigste classe die communiceert met de console
            
            const int lastNumberSystem = 25;
            
            for(int i = 4; i<=lastNumberSystem;i++)
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                poly lijst = new poly(i);
                List<PolyNumber> list = lijst.SearchPolyDivisableNumbers();
                foreach (PolyNumber number in list)
                {
                    
                    Console.WriteLine(number.ToString());
                }
                
                Console.WriteLine("end of the numbers with basesystem: " + i.ToString() +". Number of checks performed:" + lijst.NumberOfChecksDone + " It took this long:" + timer.Elapsed.ToString());
                Console.WriteLine("");
            }

            Console.WriteLine("end of program");
            Console.ReadLine();
        }
    }
}
