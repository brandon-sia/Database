using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DataAccess
    {
        public List<People> GetPeople (string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorksDB")))
            {
                return connection.Query<People>("dbo.People_GetByLastName @LastName", new {LastName = lastName}).ToList();
            }
        }

        public void InsertPerson(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorksDB")))
            {
                //People newPerson = new People { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber};

                List<People> people = new List<People>();

                people.Add(new People { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, EmailAddress = emailAddress });

                connection.Execute("dbo.People_Insert @FirstName, @LastName, @PhoneNumber, @EmailAddress", people);
            }
        }
    }
}
