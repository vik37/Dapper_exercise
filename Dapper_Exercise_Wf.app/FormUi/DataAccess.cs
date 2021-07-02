using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FormUi
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //var outut = connection.Query<Person>($"select * from People where Lastname = '{lastName}'").ToList();
                var outut = connection.Query<Person>($"dbo.People_GetByLastname @lName",new { lName = lastName}).ToList();
                return outut;
            }
        }

        public void InsertPerson(string fName, string lName, string mail, string phone)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //Person newPerson = new Person { Firstname = firstName, Lastname = lastName,
                                              // Email = emailAddress, Phone = phoneNumber};
                List<Person> people = new List<Person>();
                people.Add(new Person
                {
                    Firstname = fName,
                    Lastname = lName,
                    Email = mail,
                    Phone = phone
                });
                //connection.Execute("dbo.People_Insert @fName, @lName, @mail, @phone", people);
                connection.Execute("dbo.People_Insert @Firstname, @Lastname, @Email, @Phone", people);
            }
        }
    }
}
