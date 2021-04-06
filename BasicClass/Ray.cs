using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyRayTracer.BasicClass
{
    class Ray
    {
        private Point3D _origin;
        private Vector3D _direction;
        private Point3D PointByT;
        double KEpsilon = Math.Pow(0.1,5);

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

        /// <summary>
        /// 计算光线与场景中物体最近的交点
        /// </summary>
        /// <param name="scenes"></param>
        /// <returns>HitRecord</returns>
        public HitRecord HitScenes(Scenes scenes)
        {
            HitRecord hitRecord = new HitRecord();
            double tMin = double.MaxValue;
            for (int i = 0; i < scenes.ListGeometries.Count; i++)
            {
                var item = scenes.ListGeometries[i];

                var hr = HitSphere((Sphere)item);
                if (hr.IsHit)
                {
                    if (tMin > hr.hitT)
                    {
                        tMin = hr.hitT;
                        hitRecord = hr;
                    }
                }

            }
            return hitRecord;
        }

        public HitRecord HitSphere(Sphere sphere)
        {
            HitRecord hitRecord = new HitRecord();

            Vector3D oc = _origin - sphere.Center;
            double a = _direction * _direction;
            double b = 2 * oc * _direction;
            double c = oc * oc - sphere.Radius * sphere.Radius;
            double delta = b * b - 4 * a * c;


            if (delta > 0)
            {
                double t = (-b - Math.Sqrt(delta)) / (2 * a);

                if (t < 0)
                {
                    t = (-b - Math.Sqrt(delta)) / (2 * a);
                }

                Point3D hitPoint = GetPointByT(t);

                Vector3D normalVector = (hitPoint - sphere.Center);
                normalVector.Nomalize();//归一化

                hitRecord.IsHit = true;
                hitRecord.HitPoint = hitPoint;
                hitRecord.Nomal = normalVector;
                hitRecord.hitT = t;
                hitRecord.Metiral = sphere.Metiral;
                return hitRecord;
            }
            else
            {
                hitRecord.IsHit = false;
                return hitRecord;
            }
        }

        public HitRecord shadowHit(Sphere sphere)
        {
            HitRecord hitRecord = new HitRecord();

            Vector3D oc = _origin - sphere.Center;
            double a = _direction * _direction;
            double b = 2 * oc * _direction;
            double c = oc * oc - sphere.Radius * sphere.Radius;
            double delta = b * b - 4 * a * c;


            if (delta > 0)
            {
                double t = (-b - Math.Sqrt(delta)) / (2 * a);

                if (t > KEpsilon)
                {
                    Point3D hitPoint = GetPointByT(t);

                    Vector3D normalVector = (hitPoint - sphere.Center);
                    normalVector.Nomalize();//归一化

                    hitRecord.IsHit = true;
                    hitRecord.HitPoint = hitPoint;
                    hitRecord.Nomal = normalVector;
                    hitRecord.hitT = t;
                    hitRecord.Metiral = sphere.Metiral;
                    return hitRecord;
                }
                else
                {
             hitRecord.IsHit = false;
                return hitRecord;
                }
   
            }
            else
            {
                hitRecord.IsHit = false;
                return hitRecord;
            }
        }

        public bool shadowHitScenes(Scenes scenes)
        {
            bool isInShadow;
            for (int i = 0; i < scenes.ListGeometries.Count; i++)
            {
                isInShadow = shadowHit((Sphere)scenes.ListGeometries[i]).IsHit;
                if (isInShadow)
                {
                    return true;
                }
            }
            return false;
        }
    }


}
