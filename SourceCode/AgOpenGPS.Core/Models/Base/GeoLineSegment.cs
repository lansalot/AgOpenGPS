namespace AgOpenGPS.Core.Models
{
    public class GeoLineSegment
    {
        public GeoLineSegment(GeoCoord coordA, GeoCoord coordB)
        {
            CoordA = coordA;
            CoordB = coordB;
        }

        public GeoCoord CoordA { get; }
        public GeoCoord CoordB { get; }
        public GeoDelta Delta => new GeoDelta(CoordA, CoordB);

        public GeoDir Direction => new GeoDir(Delta);

        public GeoCoord? IntersectionPoint(GeoLineSegment otherSegment)
        {
            GeoCoord? intersectionPoint = null;
            GeoDelta delta = Delta;
            GeoDelta otherDelta = otherSegment.Delta;
            double denominator = delta.CrossProductZ(otherDelta);
            if (denominator != 0.0)
            {
                GeoDelta aToOtherADelta = new GeoDelta(CoordA, otherSegment.CoordA);

                double s = aToOtherADelta.CrossProductZ(delta) / denominator;
                if (0.0 <= s && s <= 1.0)
                {
                    double t = aToOtherADelta.CrossProductZ(otherDelta) / denominator;
                    if (0.0 <= t && t <= 1.0)
                    {
                        intersectionPoint = CoordA + t * delta;
                    }
                }
            }
            return intersectionPoint;
        }

    }

}
