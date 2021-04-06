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
        private void btnView_Click(object sender, EventArgs e)
        
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //摄像头
            Point3D cameraPos = new Point3D(0, 0, -4);

            //球
            Sphere sphere1 = new Sphere(new Point3D(0, -31, 1), 30);
            sphere1.Metiral.Color = new Color3D(1, 0, 0);
            sphere1.Metiral.Kd = 1;
            sphere1.Metiral.Ks = 0.3;
            sphere1.Metiral.Ns = 20;
            Sphere sphere2 = new Sphere(new Point3D(0.8, 0, 1), 0.1);
            sphere2.Metiral.Color = new Color3D(0, 1, 0);
            sphere2.Metiral.Kd = 1.0;
            sphere2.Metiral.Ks = 0.3;
            sphere2.Metiral.Ns = 20;
            Sphere sphere3 = new Sphere(new Point3D(-1.2, 0, 1), 0.5);
            sphere3.Metiral.Color = new Color3D(0, 0, 1);
            sphere3.Metiral.Kd = 1.0;
            sphere3.Metiral.Ks = 0.3;
            sphere3.Metiral.Ns = 20;



            //添加场景
            Scenes scenes = new Scenes();
            scenes.Add(sphere1);
            scenes.Add(sphere2);
            scenes.Add(sphere3);

            //成像平面
            ViewPlane vp = new ViewPlane();
            vp.LeftTopCorner = new Point3D(-2, 1, 1);
            vp.Width = 4;
            vp.Height = 2;
            vp.ResW = 800;
            vp.ResH = 400;

            //光源的位置
            Point3D lightPos = new Point3D(3, -4, 6);
            //光源的强度
            Color3D lightColor = new Color3D(0.4);


            //环境光
            Color3D ambientColor = new Color3D(1);
            double ka = 0.1;



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
                    HitRecord hitRecord = primaryRay.HitScenes(scenes);

                    if (hitRecord.IsHit)
                    {
                        //交点到光源的方向
                        Vector3D L = hitRecord.HitPoint - lightPos;
                        L.Nomalize();

                        double cosTheta = (L * hitRecord.Nomal) / Math.Sqrt(L.Length() * L.Length() + hitRecord.Nomal.Length() * hitRecord.Nomal.Length());
                        //double cosTheta = (L * hitRecord.Nomal);
                        if (cosTheta > 0)
                        {
                            cosTheta = 0;
                        }

                        //交点到眼睛方向
                        Vector3D V = hitRecord.HitPoint - cameraPos;
                        V.Nomalize();


                        //阴影光线
                        Ray shadowRay = new Ray(hitRecord.HitPoint, L);

                        if (shadowRay.shadowHitScenes(scenes) == false)
                        {

                        

                        //镜面反射光路
                        Vector3D R = 2 * hitRecord.Nomal * (hitRecord.Nomal * L) - L;
                        R.Nomalize();

                        //计算漫反射颜色+环境光+镜面反射
                        Color3D diffuseColor = ka * ambientColor
                                            + hitRecord.Metiral.Kd * hitRecord.Metiral.Color * lightColor * (L * hitRecord.Nomal)
                                            //+ hitRecord.Metiral.Kd * hitRecord.Metiral.Color * lightColor * cosTheta
                                            + hitRecord.Metiral.Ks * hitRecord.Metiral.Color * lightColor * Math.Pow((V * R), hitRecord.Metiral.Ns);


                        bmp.SetPixel(i, j, diffuseColor.ToSystemColor());
                        }
                        else
                        {
                            bmp.SetPixel(i, j, Color.Black);
                        }
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