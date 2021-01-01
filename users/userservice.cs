using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_system
{
    class userservice
    {
        userdataaccess userDataAccess;
        public userservice()
        {
            this.userDataAccess = new userdataaccess();
        }
        public bool LoginValidation(string username, string password)
        {
            return userDataAccess.LoginValidation(username, password);
        }
    }
}
