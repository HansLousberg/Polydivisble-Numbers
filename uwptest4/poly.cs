using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwptest4
{
    class poly
    {
        // deze klasse word op het moment nog niet gebruikt

        // base system mag niet 1 of kleiner zijn

        private int numberOfChecks = 0;
        public int NumberOfChecksDone
        {
            get
            {
                return numberOfChecks;
            }
        }
        private int count;
        private int basesystem;//the number system this number is using. (should not be less than 2)
        private List<PolyNumber> toCheck = new List<PolyNumber>();// to check moet een list woorden
        public List<PolyNumber> ToCheckList
        {
            get
            {
                return toCheck;
            }
        }
        private List<PolyNumber> checkedNumbers = new List<PolyNumber>();

        //constructor
        public poly(int basesystem)
        {
            this.basesystem = basesystem;
            GenerateList();
            count = 1;
        }

        public List<PolyNumber> SearchPolyDivisableNumbers()
        {
            while(count<basesystem-2)
            {
                OneCheckRun();
            }
            Check();
            return checkedNumbers;
        }

        public void OneCheckRun()
        {
            Check();
            Move();
        }

        private void Check()
        {
            checkedNumbers.Clear();
            foreach (PolyNumber number in toCheck)
            {
                for(int i = basesystem -1; i>0;i--)
                {
                    PolyNumber newNumber = number.Copy();
                    if(newNumber.AddNumber(i))
                    {
                        if (newNumber.LastModulusEquelsZero)
                            checkedNumbers.Add(newNumber);
                        numberOfChecks++;
                    }
                    
                }
                
            }
            count++;
        }
        
        private void Move()
        {
            toCheck.Clear();
            toCheck = checkedNumbers;
            checkedNumbers = new List<PolyNumber>();
            /*
            foreach(PolyNumber number in checkedNumbers)
            {
                if(number.count<basesystem)
                {
                    for(int i = basesystem -1; i>0; i--)
                    {
                        PolyNumber newNumber = number.Copy();
                        if(newNumber.AddNumber(i))
                            toCheck.Add(newNumber);
                    }
                }
            }*/
        }
        //private AddOne

        private void GenerateList()
        {
            for(int i=basesystem-1; i>0;i--)
            {
                PolyNumber number = new PolyNumber(basesystem);
                number.AddNumber(i);
                toCheck.Add(number);
            }
        }
        // not in use atm
        private void FillArray()
        {
            for (int i = 1; i < basesystem; i++)
            {
                //number[i - 1] = i;
            }
        }


        /*
        /// <summary>
        /// converts a array to a base 10 number. //out of use atm
        /// </summary>
        /// <param name="NumberoOfDigits"></param>
        /// <returns></returns>
        private UInt64 Base10Number(int NumberoOfDigits)//will check the first entry in ToCheck[][]
        {
            UInt64 total = 0;
            for (int i = NumberoOfDigits - 1; i >= 0; i--)
            {



                total = total + (UInt64)toCheck[0][i] * (UInt64)Math.Pow((double)(basesystem), (double)(NumberoOfDigits - i - 1));
            }
            return total;
        */
    }
}
