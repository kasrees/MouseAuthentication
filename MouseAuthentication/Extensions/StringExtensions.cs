using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAuthentication.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidLogin(this string str)
        {
            if ( String.IsNullOrWhiteSpace( str ) || str.Length < Config.MinLoginLength )
            {
                return false;
            }
            return true;
        }

        public static bool IsValidSignature(this string str)
        {
            if ( String.IsNullOrWhiteSpace( str ) || str.Length < Config.MinSignatureLength )
            {
                return false;
            }
            return true;
        }
    }
}
