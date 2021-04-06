using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayTracer.BasicClass
{
    class Metiral
    {
        private Color3D _color = new Color3D();
        private double kd;//漫反射率
        private double ks;//镜面反射率
        private double ns;//镜面反射指数

        public double Kd { get => kd; set => kd = value; }
        public double Ks { get => ks; set => ks = value; }
        public double Ns { get => ns; set => ns = value; }
        internal Color3D Color { get => _color; set => _color = value; }
    }
}
