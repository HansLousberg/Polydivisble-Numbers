using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolydivisibleNumbersConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //dit is een oude versie van het programma dat ineffiecient is.

            //7tallig stelsel
            int[] serie = new int[9] { 1, 2, 3, 4, 5, 6 , 7,8,9};

            //veertien tallig stelsel
            //int[] serie = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};//
            ArrayAllOrders series = new ArrayAllOrders(serie);

            do
            {
                if(IsPolyDivisual(serie))
                Console.WriteLine(series.ToString());
            }
            while (series.GenerateNext());

            Console.WriteLine("end of program");
            Console.ReadLine();
        }

        /// <summary>
        /// this function will calculate if the given array converted to a number (in the base length+1) is a polydivisable number
        /// </summary>
        /// <param name="serie"></param>
        /// <returns></returns>
        static bool IsPolyDivisual(int[] serie)
        {
            for(int i = 0; i<serie.Length;i++)
            {
                if(!CalcIfDivisible(serie,i+1))
                {
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// deze functie maakt van de eerste "amount" aantal cijfers een getal. (waar de lengte van de array + 1 het getallen stelsel is.) en bepaald of het deelbaar is door "amount"
        /// </summary>
        /// <param name="serie"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        static bool CalcIfDivisible(int[] serie, int amount)
        {
            if (amount > serie.Length)
                return false;
            UInt64 total = 0;
            for(int i = amount - 1 ; i>= 0; i--)
            {



                total = total + (UInt64)serie[i] * (UInt64)Math.Pow((double)(serie.Length + 1), (double)(amount - i -1));
            }
            if (total % (UInt64)amount == 0)
                return true;
            else
                return false;
        }
    }
}
