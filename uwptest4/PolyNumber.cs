using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwptest4
{
    class PolyNumber
    {
        private List<int> numbers = new List<int>(); //int[0] is msb int[n] is lsb
        private int basesystem;
        public PolyNumber(int basesystem)
        {
            this.basesystem = basesystem;
        }
        public int count
        {
            get
            {
                return numbers.Count;
            }
        }

        /// <summary>
        /// this function will try to add the given number on the end of the list. this will fail if the number is already in the list.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>returns true if it succeeded, else false</returns>
        public bool AddNumber(int number)
        {
            if (number >= basesystem | number<=0)
                return false;
            else if (Contains(number))
                return false;
            numbers.Add(number);
            return true;
        }

        /// <summary>
        /// this will determin if this number (in the given number system) modulo "the amount of entry's" equals zero
        /// </summary>
        public bool LastModulusEquelsZero
        {
            get
            {
                if (numbers.Count == 0)
                    return false;//argueable
                int remainder = 0;
                for(int i = 0; i<numbers.Count;i++)
                {
                    int divider = this.count;
                    remainder = CalcRemainder(divider, numbers[i], remainder);
                }
                if (remainder == 0)
                    return true;
                else
                    return false;
            }
        }

        //this function will calculate what the remainder is of number + the previous number * the current number system
        private int CalcRemainder(int divider ,int number,int prevRemainder)
        {
            int value = prevRemainder * basesystem +number;
            return value % divider;
        }

        //this function will check if the given number is already in the list
        private bool Contains(int testnumber)
        {
            foreach(int number in numbers)
            {
                if (number == testnumber)
                    return true;
            }
            return false;
        }

        //this function will create an exact copy of the class
        public PolyNumber Copy()
        {
            PolyNumber copy = new PolyNumber(basesystem);
            foreach(int number in numbers)
            {
                copy.AddNumber(number);
            }
            return copy;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            foreach(int number in numbers)
            {
                text.Append(number.ToString() + ", ");
            }
            return text.ToString();
        }
    }
}
