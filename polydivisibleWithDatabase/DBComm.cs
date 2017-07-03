using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace polydivisibleWithDatabase
{
    class DBComm
    {
        //readonly static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory.ToString().Substring(0, AppDomain.CurrentDomain.BaseDirectory.ToString().LastIndexOf("\\bin\\Debug")) + @"\Database.mdf;Integrated Security=True";
        readonly static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=C:\Users\Hans\Documents\CloudStation\Programming\PolydivisibleNumbersConsole\program\polydivisibleWithDatabase\PolyDivisableNumbers.mdf;Integrated Security=True";
        static public bool AddPolynumber(Polynumber number)
        {
            
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                //make the query
                string writeQuery = "INSERT INTO [TESTING] ([numbersystem],[length]";
                for(int i = 0; i<number.Length;i++)
                {
                    writeQuery += ",[number" + i.ToString() + "]";
                }
                writeQuery += ") VALUES ('"+number.NumberSystem+"','"+number.Length.ToString()+"'";

                List<int> intList = number.Content;
                foreach(int nummberpart in intList)
                {
                    writeQuery += ",'" + nummberpart.ToString() + "'";
                }
                writeQuery += ")";
                //end of query
                SqlCommand writecmd = new SqlCommand(writeQuery, conn);
                writecmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }
        

        /// <summary>
        /// this is a destructive read
        /// </summary>
        /// <returns></returns>
        static public Polynumber GetOldestPolynumber()
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            //string readQuery = "SELECT * FROM [Testing] WHERE [ID]=(SELECT MAX([ID]) FROM [Testing])";
            string readQuery = "SELECT TOP 1 * FROM [Testing]";
            SqlCommand readcmd = new SqlCommand(readQuery, conn);
            Polynumber returnNumber = new Polynumber();
            int ID=-1;
            using (SqlDataReader reader = readcmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    ID = reader.GetInt32(0);
                    returnNumber.NumberSystem = reader.GetInt32(1);
                    int length = reader.GetInt32(2);
                    for(int i = 0; i<length;i++)
                    {
                        returnNumber.Append(reader.GetInt32(i + 3));
                    }
                }
            }
            if(ID==-1)
            {
                //waarschijnlijk gaat er dan wat mis
                conn.Close();
                return returnNumber;
            }
            string deleteQuery = "DELETE FROM [Testing] WHERE [ID] = " + ID.ToString()+ ";";
            SqlCommand deletecmd = new SqlCommand(deleteQuery, conn);
            deletecmd.ExecuteNonQuery();
            conn.Close();
            return returnNumber;
        }
        

        //TODO: check what it does if you request too much
        static public List<Polynumber> GetOldestPolynumbers(int amount)
        {
            int numberInTesting = NumberInTesting();
            if (numberInTesting < amount)
                amount = numberInTesting;
            List<Polynumber> returnList = new List<Polynumber>();
            for(int i = 0; i<amount;i++)
                returnList.Add(GetOldestPolynumber());
            return returnList;
        }
        
        static public int NumberInTesting()
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "SELECT COUNT(ID) FROM [Testing]";
            int returnvalue = -1;
            
            SqlCommand readcmd = new SqlCommand(query, conn);
            using (SqlDataReader reader = readcmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnvalue = reader.GetInt32(0);
                }
            }
            return returnvalue;
        }

        static public void ClearTesting()
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "DELETE from [Testing];";
            SqlCommand deletecmd = new SqlCommand(query, conn);
            deletecmd.ExecuteNonQuery();
        }
        
    }
}
