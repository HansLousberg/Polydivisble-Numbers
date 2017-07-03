using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolydivisibleNumbersConsole
{
    class ArrayAllOrders
    {
        int[] serie;
        public int[] Serie
        {
            get
            {
                return serie;
            }
        }
        private int stepsdone;
        public int Stepsdone
        {
            get
            {
                return stepsdone;
            }
        }

        public ArrayAllOrders(int[] serie)
        {
            this.serie = serie;
            stepsdone = 0;
        }

        /// <summary>
        /// this function will generate the next valid array, where a valid array has only unique numbers and only numbers from 1 till n where n is the length of the array
        /// </summary>
        /// <returns></returns>
        public bool GenerateNext()
        {
            bool validNumber = false;
            do//add one to the number array, and then check if it is one off the valid array's (if not do again. unless the max number has been achieved)
            {
                if (!AddOne())
                    return false;

                validNumber = ValidArray();
            }
            while ( !validNumber);
            return true;
        }

        /// <summary>
        /// this function will try to add 1 to the last entity of the array, unless that is already on it's max, than i wil set it to 1, and do the same for the nex
        /// </summary>
        /// <returns>returns true if it suceeded, false if it failed</returns>
        private bool AddOne()
        {
            bool done = false;
            int i = serie.Length - 1;
            while(done == false & i >= 0)
            {
                if (serie[i] < serie.Length)
                {
                    serie[i]++;
                    done = true;
                    return done;
                }
                else
                {
                    serie[i] = 1;
                    i--;
                }
            }
            return done;
        }

        private bool ValidArray()
        {
            for(int i = serie.Length-1; i >0; i--)
            {
                for(int j = i-1;j>=0;j--)
                {
                    if(serie[j]==serie[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //this function will calculate n factorial where n is the given number
        private int Factorial(int number)
        {
            int value = 1;

            while(number>1)
            {
                value = value * number;
                number--;
            }
            return value;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            foreach( int value in serie)
            {
                text.Append(value + " , ");
            }
            return text.ToString();
        }
    }
}
