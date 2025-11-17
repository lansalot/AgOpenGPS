using AgOpenGPS.Core.Models;
using NUnit.Framework;

namespace AgOpenGPS.Core.Tests.Models
{
    public class GeoLineSegmentTests
    {
        const double _minNorthing = -1.0;
        const double _maxNorthing = 3.0;
        const double _minEasting = 2.0;
        const double _maxEasting = 4.0;
        readonly GeoCoord _neCoord = new GeoCoord(_maxNorthing, _maxEasting);
        readonly GeoCoord _seCoord = new GeoCoord(_minNorthing, _maxEasting);
        readonly GeoCoord _swCoord = new GeoCoord(_minNorthing, _minEasting);
        readonly GeoCoord _nwCoord = new GeoCoord(_maxNorthing, _minEasting);


        [Test]
        public void Test_SymetricalSegmentsCrossInTheMiddle()
        {
            GeoLineSegment nwseLineSegment = new GeoLineSegment(_nwCoord, _seCoord);
            GeoLineSegment swneLineSegment = new GeoLineSegment(_swCoord, _neCoord);
            GeoCoord? interSectionPoint = nwseLineSegment.IntersectionPoint(swneLineSegment);

            // Assert
            Assert.That(interSectionPoint.HasValue, Is.EqualTo(true));
            Assert.That(interSectionPoint.Value.Distance(_nwCoord), Is.EqualTo(interSectionPoint.Value.Distance(_seCoord)));
        }

        [Test]
        public void Test_ParallelSegmentsDoNotIntersect()
        {
            GeoDelta shift = new GeoDelta(1.0, 0.0);
            GeoLineSegment nwseLineSegment = new GeoLineSegment(_nwCoord, _seCoord);
            GeoLineSegment shiftedSegment = new GeoLineSegment(_nwCoord + shift, _seCoord + shift);
            GeoCoord? intersectionPoint = nwseLineSegment.IntersectionPoint(shiftedSegment);

            Assert.That(intersectionPoint, Is.EqualTo(null));
        }

        [Test]
        public void Test_LongLineSegment()
        {
            GeoDelta delta = new GeoDelta(_nwCoord, _seCoord);
            GeoLineSegment nwseLineSegment = new GeoLineSegment(_nwCoord, _nwCoord + 1000.0 * delta);
            GeoCoord almostEnd = _nwCoord + 999.0 * delta;

            GeoLineSegment otherSegment = new GeoLineSegment(
                almostEnd - 1.0 * new GeoDir(delta).PerpendicularLeft,
                almostEnd + 1.0 * new GeoDir(delta).PerpendicularLeft);
            GeoCoord? intersectionPoint = nwseLineSegment.IntersectionPoint(otherSegment);

            Assert.That(intersectionPoint.HasValue, Is.EqualTo(true));
            Assert.That(intersectionPoint.Value.Northing, Is.EqualTo(almostEnd.Northing));
            Assert.That(intersectionPoint.Value.Easting, Is.EqualTo(almostEnd.Easting));
        }

        [Test]
        public void Test_SameEndPoints()
        {
            GeoCoord coordA = new GeoCoord(16.88, -15.488);
            GeoCoord otherCoordA = new GeoCoord(16.88, -15.488);
            GeoCoord sharedEndPoint = new GeoCoord(16.99, -13.55);
            GeoLineSegment segment = new GeoLineSegment(coordA, sharedEndPoint);
            GeoLineSegment otherSegment = new GeoLineSegment(otherCoordA, sharedEndPoint);

            GeoCoord? intersectionPoint = segment.IntersectionPoint(otherSegment);

            Assert.That(intersectionPoint.HasValue, Is.EqualTo(true));
            Assert.That(intersectionPoint.Value, Is.EqualTo(sharedEndPoint));
        }
    }
}
