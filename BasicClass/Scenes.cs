using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayTracer.BasicClass
{
    /// <summary>
    /// 场景类
    /// </summary>
    class Scenes
    {
        private List<Geometry> _listGeometries =new List<Geometry>();

        public List<Geometry> ListGeometries { get => _listGeometries; set => _listGeometries = value; }
    
        public void Add(Geometry geometry)
        {
            this._listGeometries.Add(geometry);
        }
    }
}
