using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MouseAuthentication.Authentication.Models;

namespace MouseAuthentication.Authentication.Repository
{
    internal class UserJsonRepository : IUserRepository
    {
        public List<User> GetAll()
        {
            string json = File.ReadAllText( Config.TextDB );
            var users = JsonSerializer.Deserialize<List<User>>( json );
            return users ?? new List<User>();
        }

        public void SaveAll( List<User> users )
        {
            File.WriteAllText(Config.TextDB, JsonSerializer.Serialize( users ) );
        }
    }
}
