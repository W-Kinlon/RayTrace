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
            //摄像头
            Point3D cameraPos = new Point3D(0, 0, 0);

            //球
            Sphere sphere1 = new Sphere(new Point3D(0, 0, 1.5), 0.5);
            //漫反射系数
            double kd = 0.8;

            //成像平面
            ViewPlane vp = new ViewPlane();
            vp.LeftTopCorner = new Point3D(-2, 1, -1);
            vp.Width = 4;
            vp.Height = 2;
            vp.ResW = 800;
            vp.ResH = 400;

            //光源的位置
            Point3D lightPos = new Point3D(-1, 2, 0);
            //光源的强度
            Color3D lightColor = new Color3D(1, 1, 1);
            //环境光
            Color3D ambientColor = new Color3D(1);
            double ka = 0.3;


            double xOffset = vp.GetxOffset();
            double yOffset = vp.GetyOffset();
            bmp = new Bitmap(vp.ResW, vp.ResH);
            for (int i = 0; i < vp.ResW; i++)
            {
                for (int j = 0; j < vp.ResH; j++)
                {
                    //计算成像平面上的每一个像素点坐标
                    Point3D vpPoint = new Point3D(-2 + i * xOffset, 1 - j * yOffset, vp.LeftTopCorner.Z);

                    //方向
                    Vector3D dir = vpPoint - cameraPos;


                    //初始光线
                    Ray primaryRay = new Ray(cameraPos, dir);

                    //计算交点
                    HitRecord hitRecord = primaryRay.Hit(sphere1);
                    if (hitRecord.IsHit)
                    {
                        //交点到光源的方向
                        Vector3D L = hitRecord.HitPoint - lightPos;
                        L.Nomalize();

                        //计算漫反射颜色
                        Color3D diffuseColor = ka * ambientColor + kd * lightColor * (L * hitRecord.Nomal);


                        bmp.SetPixel(i, j, diffuseColor.ToSystemColor());
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