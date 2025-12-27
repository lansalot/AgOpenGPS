using System;
using System.Collections.Generic;

namespace AgOpenGPS.Core.AgShare
{
    public class CoordinateDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class AgShareGetOwnFieldDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CoordinateDto> OuterBoundary { get; set; }
        public double AreaHa => GeoUtils.CalculateAreaInHa(OuterBoundary);

    }
}
