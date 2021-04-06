using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayTracer.BasicClass
{
    class Sphere:Geometry
    {
        private Point3D _center;
        private double _radius;
        private Metiral _metiral = new Metiral();

        public double Radius { get => _radius; set => _radius = value; }
        internal Point3D Center { get => _center; set => _center = value; }
        internal Metiral Metiral { get => _metiral; set => _metiral = value; }

        //材质
        /// <summary>
        /// 暂无
        /// </summary>
        public Sphere()
        {
            _center = new Point3D();
            _radius = 1.0;
        }

        public Sphere(Point3D c, double r)
        {
            _center = c;
            _radius = r;
        }
    }


}
