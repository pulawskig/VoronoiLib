using System;
using System.Collections.Generic;

namespace VoronoiLib.Structures
{
    public class FortuneSite
    {
        public double X { get; }
        public double Y { get; }

        public List<VEdge> Cell { get; set; }

        public List<FortuneSite> Neighbors { get; private set; }

        private List<VPoint> _points;
        public List<VPoint> Points
        {
            get
            {
                if (_points == null)
                {
                    // it would probably be better to sort these as they are added to improve performance
                    _points = new List<VPoint>();

                    foreach (var edge in Cell)
                    {
                        _points.Add(edge.Start);
                        _points.Add(edge.End);
                    }
                    _points.Sort(SortCornersClockwise);
                }

                return _points;
            }
        }

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

        private int SortCornersClockwise(VPoint a, VPoint b)
        {
            // based on: https://social.msdn.microsoft.com/Forums/en-US/c4c0ce02-bbd0-46e7-aaa0-df85a3408c61/sorting-list-of-xy-coordinates-clockwise-sort-works-if-list-is-unsorted-but-fails-if-list-is?forum=csharplanguage

            // comparer to sort the array based on the points relative position to the center
            var atanA = Math.Atan2(a.Y - Y, a.X - X);
            var atanB = Math.Atan2(b.Y - Y, b.X - X);

            return atanA < atanB ? -1 : (atanA > atanB ? 1 : 0);
        }
    }
}
