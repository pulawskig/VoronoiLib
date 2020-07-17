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
                   .Select(site => FindCentroid(site.Points
                                                    .Select(point => (point.X, point.Y))
                                                    .ToList()))
                   .Select(tuple => new FortuneSite(tuple.X, tuple.Y))
                   .ToList();
        }

        private static (double X, double Y) FindCentroid(List<(double X, double Y)> vertices)
        {
            var x = 0d;
            var y = 0d;
            var area = 0d;

            for (var i = 0; i < vertices.Count; i++)
            {
                var (x0, y0) = vertices[i];
                var (x1, y1) = vertices[(i + 1) % vertices.Count];

                var a = (x0 * y1) - (x1 * y0);
                area += a;
                x += (x0 + x1) * a;
                y += (y0 + y1) * a;
            }

            if (area.ApproxEqual(0d))
            {
                area *= 3d;
                x /= area;
                y /= area;
            }

            return (x, y);
        }

        
    }
}