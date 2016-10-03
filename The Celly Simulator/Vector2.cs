using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Celly_Simulator
{
    public class Vector2
    {
        private double _x, _y;
        public double x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public double y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public Vector2(double x, double y)
        {
            this._x = x;
            this._y = y;
        }
        public double magnitude
        {
            get
            {
                return Math.Sqrt((_x * _x) + (_y * _y));
            }
        }
    }
}
