using GeoProgect.Entuties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoProgect.Interfaces
{
    public interface IGeoRepository
    {
        public IEnumerable<Place> GetPlaces(string query, int step);
    }
}
