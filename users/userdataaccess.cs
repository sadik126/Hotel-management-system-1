using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_system
{
    class Userdataaccess
    {
        Dataaccess dataAccess;
        public Userdataaccess()
        {
            this.dataAccess = new Dataaccess();
        }
        public bool LoginValidation(string username, string password)
        {
            string sql = "SELECT * FROM users WHERE Username='" + username + "' AND Password='" + password + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
