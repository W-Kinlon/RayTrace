using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayTracer.BasicClass
{
    class Color3D
    {
        private double _r;
        private double _g;
        private double _b;

        public double R { get => _r; set => _r = value; }
        public double G { get => _g; set => _g = value; }
        public double B { get => _b; set => _b = value; }

        public Color3D(double k)
        {
            _r = _g = _b = k;
        }

        public Color3D()
        {
            _r = _g = _b = 0;
        }

        public Color3D(double r, double g, double b)
        {
            _r = r;
            _g = g;
            _b = b;
        }
        /// <summary>
        /// double k * Color3D color
        /// </summary>
        /// <param name="k"></param>
        /// <param name="color"></param>
        /// <returns>Color3D</returns>
        public static Color3D operator *(double k, Color3D color)
        {
            return new Color3D(k * color.R, k * color.G, k * color.B);
        }
        /// <summary>
        /// Color3D color * double k
        /// </summary>
        /// <param name="k"></param>
        /// <param name="color"></param>
        /// <returns>Color3D</returns>
        public static Color3D operator *(Color3D color, double k)
        {
            return new Color3D(k * color.R, k * color.G, k * color.B);
        }


        public static Color3D operator +(Color3D colorA, Color3D colorB)
        {
            return new Color3D(colorA.R + colorB.R, colorA.G + colorB.G, colorA.B + colorB.B);
        }

        /// <summary>
        /// 乘法
        /// </summary>
        /// <param name="colorA"></param>
        /// <param name="colorB"></param>
        /// <returns></returns>
        public static Color3D operator *(Color3D colorA, Color3D colorB)
        {
            return new Color3D(colorA.R * colorB.R, colorA.G * colorB.G, colorA.B * colorB.B);
        }

        public Color ToSystemColor()
        {
            int r = (int)(_r * 255);
            int g = (int)(_g * 255);
            int b = (int)(_b * 255);

            if (r < 0)
            {
                r = 0;
            }

            if (r > 255)
            {
                r = 255;
            }

            if (g < 0)
            {
                g = 0;
            }

            if (g > 255)
            {
                g = 255;
            }

            if (b < 0)
            {
                b = 0;
            }

            if (b > 255)
            {
                b = 255;
            }

            return Color.FromArgb(r, g, b);
        }
    }
}
