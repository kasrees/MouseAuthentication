using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseAuthentication.Signature.Models;

namespace MouseAuthentication.Extensions
{
    public static class ListExtensions
    {
        public static string MovementToString(this List<Movement> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach ( var item in list )
            {
                sb.Append( item.Direction );
            }
            return sb.ToString();
        }
    }
}
