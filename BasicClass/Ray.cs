using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayTracer.BasicClass
{
    class Ray
    {
        private Point3D _origin;
        private Vector3D _direction;
        private Point3D PointByT;

        public Ray() { }

        public Ray(Point3D origin, Vector3D direction)
        {
            Origin = origin;
            Direction = direction;
        }

        internal Point3D Origin { get => _origin; set => _origin = value; }
        internal Vector3D Direction { get => _direction; set => _direction = value; }

        public Vector3D PointAtPara(double t)
        {
            return new Vector3D(_origin + new Point3D(t * _direction.X, t * _direction.Y, t * _direction.Z));
        }

        public Point3D GetPointByT(double t)
        {
            return Origin + t * _direction;
        }

        public HitRecord Hit(Sphere s)
        {
            HitRecord hitRecord = new HitRecord();

            Vector3D oc = _origin - s.Center;
            double a = _direction * _direction;
            double b = 2 * oc * _direction;
            double c = oc * oc - s.Radius * s.Radius;
            double delta = b * b - 4 * a * c;


            if (delta > 0)
            {
                double t = (-b - Math.Sqrt(delta)) / (2 * a);

                if (t < 0)
                {
                    t = (-b - Math.Sqrt(delta)) / (2 * a);
                }

                Point3D hitPoint = GetPointByT(t);

                Vector3D normalVector = (hitPoint - s.Center);
                normalVector.Nomalize();//归一化

                hitRecord.IsHit = true;
                hitRecord.HitPoint = hitPoint;
                hitRecord.Nomal = normalVector;
                return hitRecord;
            }
            else
            {
                hitRecord.IsHit = false;
                return hitRecord;
            }
        }


    }


}
