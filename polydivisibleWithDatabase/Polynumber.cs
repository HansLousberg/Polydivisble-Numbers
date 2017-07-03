using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polydivisibleWithDatabase
{
    //TODO: at the end check if length is being updated
    //make a test class or something.
    class Polynumber
    {
        //property's
        
        private List<int> numbers = new List<int>();
        public List<int> Content
        {
            get {
                List<int> returnList = new List<int>();
                foreach(int number in numbers)
                    returnList.Add(number);
                return numbers;
            }
            set {
                if(numbers.Count!=0)
                    numbers.Clear();
                foreach(int number in value)
                    numbers.Add(number);
            }
        }
        
        //try to avoid this funcction since it is quite calculations heavy.
        //what does it check, all possible lengths of the number if it is divisible by length
        public bool IsPolynumber
        {
            get
            {
                bool IsPossiblyPolydivisible = true;
                int i = numbers.Count;
                while ((IsPossiblyPolydivisible == true) & (i> 0))
                {
                    if (calcRemainder(i) != 0)
                        IsPossiblyPolydivisible = false;
                    i--;
                }
                return IsPossiblyPolydivisible;
            }
        }

        public bool IsDivisableByLength
        {
            get
            {
                if (calcRemainder(numbers.Count) == 0)
                    return true;
                else
                    return false;
            }
        }

        public int Length
        {
            get { return numbers.Count; }
        }

        private int numberSystem;
        public int NumberSystem
        {
            get { return numberSystem; }
            set { numberSystem = value; }
        }

        //constructor
        public Polynumber()
        {

        }
        public Polynumber(int numberSystem)
        {
            this.numberSystem = numberSystem;
        }

        //public functions
        public override string ToString()
        {
            string resultString = "";
            foreach(int value in numbers)
            {
                resultString += value.ToString() + " ,";
            }
            return resultString;
        }

        // public functions
        public bool Append(int number)
        {
            if (number >= numberSystem)
                return false;
            if (number <= 0)
                return false;
            numbers.Add(number);
            return true;
        }

        //the rimairy use of this function is to create copy faster
        public void UnsafeAppend(int number)
        {
            numbers.Add(number);
        }

        public bool Contains(int number)
        {
            return numbers.Contains(number);
        }

        public Polynumber Copy()
        {
            Polynumber copy = new Polynumber(numberSystem);
            foreach(int number in numbers)
            {
                copy.UnsafeAppend(number);
            }
            return copy;
        }


        //private functions

        /// this function will handel the first n numbers as one number in the numbersystem that has been given.
        /// it will calculate the remaider of that number divided by n
        private int calcRemainder(int n)
        {
            int remainder = 0;
            for(int i = 0; i<n; i++)
            {
                remainder = (numbers[i] + (remainder * NumberSystem))%n;
            }
            return remainder;
        }
        
        
    }
}
