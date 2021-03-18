using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayTracer.BasicClass
{
    class Point3D
    {
        //heal the world and make it a better place for you and for me any entirl human racing there are people dying if you care eough for the living
        private double _x;
        private double _y;
        private double _z;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
        public double Z { get => _z; set => _z = value; }

        //默认无参构造函数
        public Point3D()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        //单参数构造
        public Point3D(double singleVal)
        {
            _x = _y = _z = singleVal;
        }

        //含参构造函数
        public Point3D(double X, double Y, double Z)
        {
            _x = X;
            _y = Y;
            _z = Z;
        }

        public static Point3D operator +(Point3D a,Point3D b)
        {
            return new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// 两个点组成的向量
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3D operator -(Point3D a, Point3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3D operator *(Point3D a, Point3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Point3D operator +(Point3D a, Vector3D b)
        {
            return new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
    }
}
