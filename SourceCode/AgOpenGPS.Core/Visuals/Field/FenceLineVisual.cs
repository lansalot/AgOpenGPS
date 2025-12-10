using AgOpenGPS.Core.Drawing;
using AgOpenGPS.Core.DrawLib;
using AgOpenGPS.Core.Models;

namespace AgOpenGPS.Core.Visuals
{
    public static class FenceLineVisual
    {
        private static LineStyle normalLineStyle = new LineStyle(3.0f, new ColorRgba(0.62f, 0.635f, 0.635f));
        private static LineStyle selectedLineStyle = new LineStyle(3.0f, Colors.White);

        public static void DrawFenceLine(GeoCoord[] fenceLineEar, bool isSelected)
        {
            if (isSelected)
            {
                GLW.SetLineStyle(selectedLineStyle);
            }
            else
            {
                GLW.SetLineStyle(normalLineStyle);
            }
            GLW.DrawLineLoopPrimitive(fenceLineEar);
        }
    }
}
