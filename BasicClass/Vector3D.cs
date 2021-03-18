using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayTracer.BasicClass
{
    class Vector3D
    {
        private double _x;
        private double _y;
        private double _z;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
        public double Z { get => _z; set => _z = value; }

        public Vector3D()
        {
            _x = _y = _z = 0;
        }
        public Vector3D(Point3D v)
        {
            _x = v.X;
            _y = v.Y;
            _z = v.Z;
        }

        public Vector3D(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
        }

        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3D operator +(Vector3D a, Point3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }


        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3D operator -(Point3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3D operator -(Vector3D a, Point3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3D operator *(Vector3D a, double b)
        {
            return new Vector3D(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector3D operator *(double a, Vector3D b)
        {
            return new Vector3D(a * b.X, a * b.Y, a * b.Z);
        }

        //public static Vector3 operator *(Vector3 a, Vector3 b)
        //{
        //    return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        //}
        /// <summary>
        /// 向量*向量
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>常数</returns>
        public static double operator *(Vector3D a, Vector3D b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }



        /// <summary>
        /// 向量/常数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>向量</returns>
        public static Vector3D operator /(Vector3D a, double b)
        {
            return new Vector3D(a.X / b, a.Y / b, a.Z / b);
        }
        /// <summary>
        /// 求向量模长
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            return Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }
        /// <summary>
        /// 归一化
        /// </summary>
        public void Nomalize()
        {
            double Len = Length();
            _x /= Len;
            _y /= Len;
            _z /= Len;
        }
    }
}
