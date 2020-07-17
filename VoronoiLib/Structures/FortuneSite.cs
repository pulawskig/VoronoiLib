using System;
using System.Collections.Generic;

namespace VoronoiLib.Structures
{
    public class FortuneSite
    {
        public double X { get; }
        public double Y { get; }

        public List<VEdge> Cell { get; private set; }

        public List<FortuneSite> Neighbors { get; private set; }

        public FortuneSite(double x, double y)
        {
            X = x;
            Y = y;
            Cell = new List<VEdge>();
            Neighbors = new List<FortuneSite>();
        }

        internal void AddEdge(VEdge value)
        {
            if (value.Start == null || value.End == null
                                    || double.IsNaN(value.Start.X) || double.IsNaN(value.Start.Y)
                                    || double.IsNaN(value.End.X) || double.IsNaN(value.End.Y))
            {
                return;
            }

            Cell.Add(value);
        }
    }
}
