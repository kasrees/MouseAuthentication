using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseAuthentication.ENum;

namespace MouseAuthentication.Models
{
    internal class Movement
    {
        public double DiffX { get; set; }
        public double DiffY { get; set; }
        public MovementDirection DirectionX { get; set; }
        public MovementDirection DirectionY { get; set; }
        public double Length { get; set; }

        public static MovementDirection GetDirectionX(double diffX)
        {
            switch ( diffX )
            {
                case < 0:
                    return MovementDirection.Left;
                case > 0:
                    return MovementDirection.Right;

                default:
                    return MovementDirection.None;
            }
        }

        public static MovementDirection GetDirectionY( double diffY )
        {
            switch ( diffY )
            {
                case < 0:
                    return MovementDirection.Down;
                case > 0:
                    return MovementDirection.Up;

                default:
                    return MovementDirection.None;
            }
        }

        public static double GetLength(double diffX, double diffY)
        {
            return Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
        }

        public override string ToString()
        {
            return $"{DiffX}, {DiffY}, {DirectionX}, {DirectionY}, {Length}";
        }
    }
}
