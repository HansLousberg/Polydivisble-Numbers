using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polydivisibleWithDatabase
{
    class PolynumberFinder
    {
        List<Polynumber> testnumbers = new List<Polynumber>();
        List<Polynumber> EndResultNumbers = new List<Polynumber>();

        private int DBpushes = 0;
        public int DBPushes
        {
            get { return DBpushes; }
        }

        private int numbersystem;
        public int Numbersystem
        {
            get { return numbersystem; }
            set { numbersystem = value; }
        }

        private int length;
        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        private bool duplicateNumbers = false;
        public bool DuplicateNumbers
        {
            get { return duplicateNumbers; }
            set { duplicateNumbers = value; }
        }

        private int batchSize = 1;
        public int BatchSize
        {
            get { return batchSize; }
            set { batchSize = value; }
        }
        private int maxListSize = 1000000;
        public int MaxListSize
        {
            get { return maxListSize; }
            set { maxListSize = value; }
        }

        //constructor
        public PolynumberFinder()
        {

        }

        //public functions
        /// <summary>
        /// this is the main function
        /// </summary>
        /// <returns></returns>
        public List<Polynumber> GenerateList()
        {
            
            SetStartnumbers();
            EndResultNumbers = new List<Polynumber>();
            do
            {
                TestChildNumbers();
            }
            while (testnumbers.Count > 0);//end of do while
            return EndResultNumbers;
        }

        //private functions
        private void SetStartnumbers()
        {
            for(int i = 1; i < numbersystem;i++)
            {
                Polynumber number = new Polynumber();
                number.NumberSystem = numbersystem;
                number.UnsafeAppend(i);
                testnumbers.Add(number);
            }
        }

        private void TestChildNumbers()
        {
            Polynumber testnumber = testnumbers[testnumbers.Count - 1];
            testnumbers.RemoveAt(testnumbers.Count - 1);
            for (int i = numbersystem-1; i>0;i--)
            {
                if(!testnumber.Contains(i))
                {
                    Polynumber num1 = testnumber.Copy();
                    num1.UnsafeAppend(i);
                    if(num1.IsDivisableByLength)
                    {
                        if (num1.Length == length)
                        {
                            EndResultNumbers.Add(num1);
                        }
                        else
                        {
                            testnumbers.Add(num1);
                        }
                    }
                }
            }
            
        }
        /********* not working as is
        private void TestChildNumbersDuplicates()
        {
            for (int i = 1; i < numbersystem; i++)
            {
                Polynumber num1 = testnumbers[testnumbers.Count - 1].Copy();
                num1.Append(i);
                if (num1.IsDivisableByLength)
                {
                    if (num1.Length == length)
                    {
                        EndResultNumbers.Add(num1);
                    }
                    else if (testnumbers.Count < maxListSize)
                    {
                        testnumbers.Add(num1);
                    }
                    else
                        DBComm.AddPolynumber(num1);
                }
            }
            testnumbers.RemoveAt(testnumbers.Count - 1);
        }
        */
        
    }
}
