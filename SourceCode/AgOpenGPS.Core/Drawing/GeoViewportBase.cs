using AgOpenGPS.Core.DrawLib;
using AgOpenGPS.Core.Models;
using System;

namespace AgOpenGPS.Core.Drawing
{
    public abstract class GeoViewportBase
    {
        private const double PanStep = 0.15;
        private const double ZoomStep = 2.0;
        private const double MinZoom = 0.015625;
        private const double MaxZoom = 1.0;

        public GeoViewportBase()
        {
            ResetZoomPan();
        }

        public static void Initialize()
        {
            GLW.EnableCullFace();
            GLW.SetCullFaceModeBack();
            GLW.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        public void Resize(int width, int height)
        {
            GLW.Viewport(width, height);
            MakeCurrent();
            GLW.CreatePerspectiveFieldOfView();
        }

        protected abstract void MakeCurrent();

        public GeoBoundingBox BoundingBox { get; set; }
        private double BoundingBoxWidth => BoundingBox.MaxEasting - BoundingBox.MinEasting;
        private double BoundingBoxHeight => BoundingBox.MaxNorthing - BoundingBox.MinNorthing;
        private double BoundingBoxDistance => Math.Max(BoundingBoxWidth, BoundingBoxHeight);

        public double Zoom { get; private set; }
        public GeoCoord ViewportCenter { get; set; }

        public abstract XyDelta ViewportSize { get; }

        private double scaleBoundingBoxToViewport;

        public void SetBoundingBox(GeoCoord center, double size)
        {
            GeoBoundingBox bb = GeoBoundingBox.CreateEmpty();
            bb.Include(center);
            GeoDelta margin = new GeoDelta(0.5 * size, 0.5 * size);
            bb.Include(center + margin);
            bb.Include(center - margin);
            BoundingBox = bb;
            ViewportCenter = center;
        }

        public void BeginPaint()
        {
            MakeCurrent();
            GLW.ClearColorAndDepthBuffer();
            GLW.LoadIdentity();

            XyDelta viewportSize = ViewportSize;
            GeoDelta boundingBoxSize = BoundingBox.MaxCoord - BoundingBox.MinCoord;
            double scaleEastingToX = viewportSize.DeltaX / boundingBoxSize.EastingDelta;
            double scaleNorthingToY = viewportSize.DeltaY / boundingBoxSize.NorthingDelta;
            scaleBoundingBoxToViewport = Math.Min(scaleEastingToX, scaleNorthingToY);

            GLW.Translate(0, 0, -BoundingBoxDistance * Zoom);
            GLW.Translate(-ViewportCenter.Easting, -ViewportCenter.Northing, 0);
        }

        public virtual void EndPaint()
        {
            GLW.Flush();
        }

        public GeoCoord GetGeoCoord(XyCoord xyClientCoord)
        {
            double scaleViewportToBoundingBox = 1.0 / scaleBoundingBoxToViewport;
            XyCoord xyCenteredCoord = xyClientCoord - 0.5 * ViewportSize;
            // Magic number 0.903
            GeoDelta delta = (scaleViewportToBoundingBox / Zoom / 0.903) * new GeoDelta(-xyCenteredCoord.Y, xyCenteredCoord.X);
            return ViewportCenter + delta;
        }

        public void ResetZoomPan()
        {
            Zoom = 1.0;
            ViewportCenter = BoundingBox.CenterCoord;
        }

        public void ZoomInStep()
        {
            Zoom = Math.Max(Zoom / ZoomStep, MinZoom);
        }

        public void ZoomOutStep()
        {
            Zoom = Math.Min(Zoom * ZoomStep, MaxZoom);
        }

        public void PanRight()
        {
            ViewportCenter += PanStep * Zoom * new GeoDelta(0.0, BoundingBoxWidth);
        }

        public void PanLeft()
        {
            ViewportCenter -= PanStep * Zoom * new GeoDelta(0.0, BoundingBoxWidth);
        }

        public void PanDown()
        {
            ViewportCenter -= PanStep * Zoom * new GeoDelta(BoundingBoxHeight, 0.0);
        }

        public void PanUp()
        {
            ViewportCenter += PanStep * Zoom * new GeoDelta(BoundingBoxHeight, 0.0);
        }

        public void PointZoom(GeoCoord newViewportCenter, double zoom)
        {
            ViewportCenter = newViewportCenter;
            Zoom = zoom;
        }
    }

}
