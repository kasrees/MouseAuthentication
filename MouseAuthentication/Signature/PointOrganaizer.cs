using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MouseAuthentication.Extensions;
using MouseAuthentication.Signature.Models;

namespace MouseAuthentication.Signature
{
    internal class PointOrganaizer
    {
        internal static List<Movement> Organize( List<Point> points )
        {
            List<Movement> result = new List<Movement>();
            points = GroupPointsByDistance( points );

            for ( int i = 1; i < points.Count; i++ )
            {
                result.Add( new Movement
                (
                    points[ i - 1 ],
                    points[ i ]
                ) );
            }

            return result;
        }

        private static List<Point> GroupPointsByDistance( List<Point> points )
        {
            List<Point> result = new List<Point>();

            for ( int i = 0; i < points.Count; i++ )
            {
                if ( i == 0 )
                {
                    result.Add( points[ i ] );
                    continue;
                }

                if ( points[ i ].GetDistance( result[ result.Count - 1 ] ) > Config.LineDistance )
                {
                    result.Add( points[ i ] );
                }

                if ( i == points.Count - 1 && result.Count == 1 )
                {
                    result.Add( points[ i ] );
                }
            }

            return result;
        }
    }
}
