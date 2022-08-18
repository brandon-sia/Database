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
                return connection.Query<People>("dbo.Person_GetByLastName @LastName", new {LastName = lastName}).ToList();
            }
        }
    }
}
