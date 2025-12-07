using AgOpenGPS.Core.Drawing;
using AgOpenGPS.Core.DrawLib;
using AgOpenGPS.Core.Models;
using System.Collections.Generic;

namespace AgOpenGPS.Core.Visuals
{
    public static class TouchPointsLineVisual
    {
        private static readonly PointStyle pointsBackgroundStyle = new PointStyle(24, Colors.Black);
        private static readonly PointStyle pointAStyle = new PointStyle(16, new ColorRgba(0.950f, 0.75f, 0.50f));
        private static readonly PointStyle pointBStyle = new PointStyle(16, new ColorRgba(0.5f, 0.5f, 0.935f));
        private static readonly PointStyle pointCStyle = new PointStyle(16, new ColorRgba(0.95f, 0.95f, 0.35f));
        private static readonly ColorRgb lineOrange = new ColorRgb(0.90f, 0.5f, 0.25f);


        public static void DrawTouchPoints(GeoCoord? coordA, GeoCoord? coordB, GeoCoord? coordC = null)
        {
            // Draw backgrounds first. Looks better when points overlap.
            List<GeoCoord> backGrounds = new List<GeoCoord>();
            if (coordA.HasValue) { backGrounds.Add(coordA.Value); }
            if (coordB.HasValue) { backGrounds.Add(coordB.Value); }
            if (coordC.HasValue) { backGrounds.Add(coordC.Value); }
            GLW.SetPointStyle(pointsBackgroundStyle);
            GLW.DrawPointsPrimitive(backGrounds.ToArray());

            if (coordA.HasValue)
            {
                GLW.SetPointStyle(pointAStyle);
                GLW.DrawPoint(coordA.Value);
            }
            if (coordB.HasValue)
            {
                GLW.SetPointStyle(pointBStyle);
                GLW.DrawPoint(coordB.Value);
            }
            if (coordC.HasValue)
            {
                GLW.SetPointStyle(pointCStyle);
                GLW.DrawPoint(coordC.Value);
            }
        }

        public static void DrawTouchPointsLine(GeoCoord? coordA, GeoCoord? coordB, GeoCoord? coordC = null)
        {
            DrawTouchPoints(coordA, coordB, coordC);
            if (coordA.HasValue && coordB.HasValue)
            {
                GLW.SetLineWidth(4);
                GLW.SetColor(lineOrange);
                List<GeoCoord> orangeLineStrip = new List<GeoCoord> { coordA.Value, coordB.Value };

                if (coordC.HasValue) orangeLineStrip.Insert(1, coordC.Value);
                GLW.DrawLineStripPrimitive(orangeLineStrip.ToArray());
            }
        }
    }
}
