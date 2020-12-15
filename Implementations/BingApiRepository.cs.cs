using GeoProgect.Entuties;
using GeoProgect.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoProgect.Implementations
{
    // TODO: Сделать реализацию интерфейчаса, получения данных от Bing
    public class BingApiRepository : IApiGeoRepository
    {
        public IEnumerable<Place> GetPlaces(string query, int step)
        {
            throw new NotImplementedException();
        }
    }
}
