using AgOpenGPS.Core.Models;
using System.Collections.Generic;

namespace AgOpenGPS.Helpers
{
    public class GeoRefactorHelper
    {

        public static GeoLineSegment GetLineSegment(List<vec3> list, int index)
        {
            int nextIndex = (index + 1) % list.Count;
            return new GeoLineSegment(list[index].ToGeoCoord(), list[nextIndex].ToGeoCoord());
        }
    }
}
