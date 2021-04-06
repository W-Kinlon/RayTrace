using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayTracer.BasicClass
{
    class HitRecord
    {
        private bool _isHit;//是否击中
        private Point3D _hitPoint;//击中的坐标
        private Vector3D _nomal;//归一化向量
        private double _hitT;//距离光源的距离
        private Metiral _metiral;//击中点材料

        public bool IsHit { get => _isHit; set => _isHit = value; }
        public double hitT { get => _hitT; set => _hitT = value; }
        internal Point3D HitPoint { get => _hitPoint; set => _hitPoint = value; }
        internal Vector3D Nomal { get => _nomal; set => _nomal = value; }
        internal Metiral Metiral { get => _metiral; set => _metiral = value; }
    }
}
