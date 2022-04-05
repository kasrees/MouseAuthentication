using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseAuthentication.Authentication.Models;
using MouseAuthentication.Extensions;

namespace MouseAuthentication.Authentication
{
    internal class UserService
    {
        private UserController _userController = new UserController();
        private int failedCount = 0;

        public bool Login( string login, string signature )
        {
            if ( !login.IsValidLogin() )
            {
                failedCount++;
                return false;
            }
            if ( !signature.IsValidSignature() )
            {
                failedCount++;
                return false;
            }

            User user = new User
            {
                Name = login,
                Signature = signature
            };

            return _userController.IsUserExists( user );
        }

        internal bool Register( string login, string signature )
        {
            if ( !login.IsValidLogin() )
            {
                failedCount++;
                return false;
            }
            if ( !signature.IsValidSignature() )
            {
                failedCount++;
                return false;
            }

            User user = new User
            {
                Name = login,
                Signature = signature
            };

            return _userController.SaveUser( user );
        }
    }
}
