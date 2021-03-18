using MyRayTracer.BasicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRayTracer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        int resW, resH;//宽度、高度
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Point3D eye = new Point3D(0,0,5);
            Sphere sphere1 = new Sphere(new Point3D(0, 0, -4), 0.3);
            ViewPlane vp = new ViewPlane();
            vp.LeftTopCorner = new Point3D(-2, -1, 0);
            vp.Width = 4;
            vp.Height = 2;
            vp.ResW = 800;
            vp.ResH = 600;
            double xOffset = 4 / 800.0;
            double yOffset = 2 / 600.0;
            bmp = new Bitmap(vp.ResW, vp.ResH);
            for (int i = 0; i < vp.ResW; i++)
            {
                for (int j = 0; j < vp.ResH; j++)
                {
                    Point3D p = new Point3D(-2+i*xOffset,1-j*yOffset,0);
                    Vector3D dir = p - eye;
                    Ray ray = new Ray(eye, dir);

                    bool isHit = ray.Hit(sphere1);
                    if (isHit)
                    {
                        bmp.SetPixel(i, j, Color.Red);
                    }
                    else
                    {
                        bmp.SetPixel(i, j, Color.Gray);
                    }
                }
            }
            pictureBox1.BackgroundImage = bmp;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bmp.Save("1.bmp");
        }
    }
}