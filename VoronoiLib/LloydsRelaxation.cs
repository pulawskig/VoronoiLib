using System;
using System.Collections.Generic;
using System.Linq;
using VoronoiLib.Structures;

namespace VoronoiLib
{
    public static class LloydsRelaxation
    {
        public static List<FortuneSite> Relax(List<FortuneSite> sites)
        {
            return sites
                   .Select(site => new Tuple<VPoint, int>(FindCentroid(site.Points), site.Id))
                   .Select(point => new FortuneSite(point.Item1.X, point.Item1.Y) { Id = point.Item2 })
                   .ToList();
        }

        private static VPoint FindCentroid(IReadOnlyList<VPoint> vertices)
        {
            var point = new VPoint(0d, 0d);
            var area = 0d;

            for (var i = 0; i < vertices.Count; i++)
            {
                var nextI = (i + 1) % vertices.Count;
                var x0 = vertices[i].X;
                var y0 = vertices[i].Y;
                var x1 = vertices[nextI].X;
                var y1 = vertices[nextI].Y;

                var a = (x0 * y1) - (x1 * y0);
                area += a;
                point.X += (x0 + x1) * a;
                point.Y += (y0 + y1) * a;
            }

            if (!area.ApproxEqual(0d))
            {
                area *= 3d;
                point.X /= area;
                point.Y /= area;
            }

            return point;
        }
    }
}