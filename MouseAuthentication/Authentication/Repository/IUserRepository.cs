using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseAuthentication.Authentication.Models;

namespace MouseAuthentication.Authentication.Repository
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public void SaveAll( List<User> users );
    }
}
