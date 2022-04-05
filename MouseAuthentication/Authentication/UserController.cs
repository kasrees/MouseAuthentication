using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseAuthentication.Authentication.Models;
using MouseAuthentication.Authentication.Repository;

namespace MouseAuthentication.Authentication
{
    public class UserController
    {
        private IUserRepository _userRepository = new UserJsonRepository();
        public bool IsUserExists(User user)
        {
            var users = _userRepository.GetAll();
            return users.FirstOrDefault( x => x.Name == user.Name && x.Signature == user.Signature) != null;
        }
        
        public bool SaveUser(User user)
        {
            var users = _userRepository.GetAll();
            if ( users.FirstOrDefault( x => x.Name == user.Name ) == null )
            {
                users.Add( user );
                _userRepository.SaveAll( users );
                return true;
            }
            return false;
        }
    }
}
