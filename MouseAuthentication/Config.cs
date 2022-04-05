using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAuthentication
{
    public static class Config
    {
        public static int MinLoginLength { get; set; } = 5;
        public static int MinSignatureLength { get; set; } = 10;
    }
}
