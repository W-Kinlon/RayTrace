using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayTracer.BasicClass
{
    class ViewPlane
    {
        private int resW;
        private int resH;
        private Point3D leftTopCorner;
        private double width;
        private double height;


        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }
        public int ResH { get => resH; set => resH = value; }
        public int ResW { get => resW; set => resW = value; }
        internal Point3D LeftTopCorner { get => leftTopCorner; set => leftTopCorner = value; }
        /// <summary>
        /// xOffset
        /// </summary>
        /// <returns>xOffset</returns>
        public double GetxOffset()
        {
            return Width / resW;
        }
        /// <summary>
        /// yOffset
        /// </summary>
        /// <returns>yOffset</returns>
        public double GetyOffset()
        {
            return Height / resH;
        }

    }
}
