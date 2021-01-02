using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_system
{
    class Userservice
    {
        Userdataaccess userDataAccess;
        public Userservice()
        {
            this.userDataAccess = new Userdataaccess();
        }
        public bool LoginValidation(string username, string password)
        {
            return userDataAccess.LoginValidation(username, password);
        }
    }
}
