using System;
using System.Collections.Generic;
using System.Text;

namespace VoronoiLib.Structures
{
    internal struct BoundingBoxInfo
    {
        public VEdge Edge { get; set; }
        public VPoint Vertex { get; set; }
        public bool Start { get; set; }
    }
}
