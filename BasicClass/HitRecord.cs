using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayTracer.BasicClass
{
    class HitRecord
    {
        bool _isHit;//是否击中
        Point3D _hitPoint;//击中的坐标
        Vector3D _nomal;//归一化向量

        public bool IsHit { get => _isHit; set => _isHit = value; }
        internal Point3D HitPoint { get => _hitPoint; set => _hitPoint = value; }
        internal Vector3D Nomal { get => _nomal; set => _nomal = value; }
    }
}
