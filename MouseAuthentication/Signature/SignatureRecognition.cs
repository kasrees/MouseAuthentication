using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MouseAuthentication.Extensions;
using MouseAuthentication.Signature.Models;

namespace MouseAuthentication.Signature
{
    internal static class SignatureRecognition
    {
        internal static string GetSignature( List<Point> points )
        {
            List<Movement> movements = PointOrganaizer.Organize( points );
            movements = GroupMovements( movements );
            return movements.MovementToString();
        }

        private static List<Movement> GroupMovements( List<Movement> movements )
        {
            List<Movement> result = new List<Movement>();

            for ( int i = 0; i < movements.Count; i++ )
            {
                if ( i == 0 )
                {
                    result.Add( movements[ i ] );
                }

                if ( movements[ i ].Direction != result[ result.Count - 1 ].Direction )
                {
                    result.Add( movements[ i ] );
                }
                else
                {
                    result[ result.Count - 1 ].Length += movements[ i ].Length;
                }
            }

            return result;
        }
    }
}
