using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using MouseAuthentication.ENum;
using MouseAuthentication.Models;

namespace MouseAuthentication.Services
{
    internal class MovementDetection
    {
        private IEnumerable<Point> _points;
        private Point _previousPoint;
        private Point _currentPoint;


        public MovementDetection( IEnumerable<Point> points )
        {
            _points = points;
        }

        public List<Movement> Get()
        {
            List<Movement> result = new List<Movement>();

            foreach ( var point in _points )
            {
                _previousPoint = _currentPoint;
                _currentPoint = point;

                if ( _previousPoint == new Point { X = 0, Y = 0 } )
                {
                    continue;
                }

                result.Add( GetPointsMovement() );
            }

            return ClearMovements( result );
        }

        private List<Movement> ClearMovements( List<Movement> movements )
        {
            List<Movement> result = new List<Movement>();

            for ( int i = 0; i < movements.Count; i++ )
            {
                Trace.WriteLine( movements[ i ] );
                if ( i == 0 )
                {
                    result.Add( movements[ i ] );
                    continue;
                }

                if ( movements[ i ].DirectionX != movements[ i - 1 ].DirectionX || movements[ i ].DirectionY != movements[ i - 1 ].DirectionY )
                {
                    result.Add( movements[ i ] );
                }
            }

            return result;
        }

        private Movement GetPointsMovement()
        {
            double diffX = _currentPoint.X - _previousPoint.X;
            double diffY = _previousPoint.Y - _currentPoint.Y;
            return new Movement
            {
                DiffX = diffX,
                DiffY = diffY,
                DirectionX = Movement.GetDirectionX( diffX ),
                DirectionY = Movement.GetDirectionY( diffY ),
                Length = Movement.GetLength(diffX, diffY)
            };
        }
    }
}
