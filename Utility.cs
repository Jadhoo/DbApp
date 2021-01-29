using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Globalization;
namespace DbApp
{
    public class Utility
    {
        public static int AddDetails(Person person)
        {
            string connectionString = "Server=LAPTOP-JO1RRIJ1;Database=TrainingDB;Integrated Security=true;";
            int status = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"INSERT PERSON VALUES('{person.PId}', '{person.PName}','{person.DOB.ToString("yyyy-MM-dd")}');";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    status = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return status;
        }

        public static List<Person> DisplayDetails()
        {
            List<Person> personList = new List<Person>();
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=LAPTOP-JO1RRIJ1;Database=TrainingDB;Integrated Security=true"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Person;", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Person person = new Person();
                            person.PId = reader[0].ToString();
                            person.PName = reader[1].ToString();
                            person.DOB = reader.GetDateTime(2);
                            personList.Add(person);
                        }
                    }
                    else
                        Console.WriteLine("No records found!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return personList;
        }
    }
}