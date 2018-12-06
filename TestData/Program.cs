using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData
{
    public class Recover
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=ORDINATEUR-KISU\\SQLEXPRESS;Database=C#_Project;Trusted_Connection=true";
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT Name FROM Customer", conn);
                command.Parameters.Add(new SqlParameter("0", 1));


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    string str;
                    Console.WriteLine("FirstColumn\n");
                    while (reader.Read())
                    {
                        str = (String.Format("{0} \n",
                            reader[0]));
                        Console.WriteLine(str);
                    }
                }
                Console.WriteLine("Data displayed! Now press enter to move to the next section!");
                Console.ReadLine();
                Console.Clear();
            }
            Console.ReadLine();

            Console.WriteLine("INSERT INTO command");

            // Create the command, to insert the data into the Table!
            // this is a simple INSERT INTO command!

            SqlCommand insertCommand = new SqlCommand("INSERT INTO test (ID, Name, ThirdColumn, ForthColumn) VALUES (@0, @1, @2, @3)", conn);

            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.

            insertCommand.Parameters.Add(new SqlParameter("0", 10));
            insertCommand.Parameters.Add(new SqlParameter("1", "Test Column"));
            insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));
            insertCommand.Parameters.Add(new SqlParameter("3", false));

            // Execute the command, and print the values of the columns affected through
            // the command executed.

            Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
            Console.WriteLine("Done! Press enter to move to the next step");
            Console.ReadLine();
            Console.Clear();
        }
       
    }

}
