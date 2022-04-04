using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MouseAuthentication.Signature.Enums;

namespace MouseAuthentication.Signature.Models
{
    public class Movement
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public LineDirection Direction { get; set; }
        public double Length { get; set; }

        public Movement( Point startPoint, Point endPoint )
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            DeterminateDirection();
            CalculateLength();
        }

        public void DeterminateDirection()
        {
            double diffX = EndPoint.X - StartPoint.X;
            double diffY = EndPoint.Y - StartPoint.Y;
            double degree = Math.Atan2( diffX, diffY ) * 180 / Math.PI;

            if ( degree < -135 || degree >= 135 )
            {
                Direction = LineDirection.Up;
            }
            if ( degree < -45 && degree >= - 135 )
            {
                Direction = LineDirection.Left;
            }
            if ( degree < 45 && degree >= -45 )
            {
                Direction = LineDirection.Down;
            }
            if ( degree < 135 && degree >= 45 )
            {
                Direction = LineDirection.Right;
            }
        }

        public void CalculateLength()
        {
            Length = Math.Sqrt(Math.Pow(EndPoint.X - StartPoint.X, 2) + Math.Pow(EndPoint.Y - StartPoint.Y, 2));
        }

        public override string ToString()
        {
            return $"{StartPoint}, {EndPoint}, {Direction}, {Length}";
        }
    }
}
