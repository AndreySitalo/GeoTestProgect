using GeoProgect.Entuties;
using GeoProgect.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoProgect.Implementations
{
    class OsmApiRepository : IApiGeoRepository
    {
        private readonly ApiContext _apiContext;
        private const string osmUri= "https://nominatim.openstreetmap.org";

        public dynamic Point { get; private set; }

        public OsmApiRepository()
        {
            _apiContext = new ApiContext(osmUri);
        }

        public IEnumerable<Place> GetPlaces(string query,int step)
        {
            string uriParams = GetProps(query);
            dynamic data = JsonConvert.DeserializeObject(_apiContext.GetAsyncData(uriParams).Result);

            return ParseGeoJson(data, step);

        }
        private string GetProps(string query)
        {
            return String.Format("search?q={0}&format=json&polygon_geojson=1", query);
        }

        private IEnumerable<Place> ParseGeoJson(dynamic data,int step)
        {
            List <Place> listPlace = new List<Place>();

            foreach (var item in data)
            {
                if (item.geojson.type.Value == "MultiPolygon" )
                {
                    foreach (var place in item.geojson.coordinates)
                    {
                        var placeObj = GetListPlace(place, step);
                        listPlace.Add(new Place { Type = "multiPlace", Poligons = placeObj });
                    }
                }

                if (item.geojson.type.Value == "Polygon")
                    listPlace.Add(new Place { Type = "place", Poligons = GetListPlace(item.geojson.coordinates, step) });
            }

            return listPlace;
        }
        private List<Poligon> GetListPlace(dynamic poligons,int step)
        {
            var listPoligons = new List<Poligon>();

            foreach (var poligon in poligons)
            {
                var listPoints = new List<Point>();
                step = step > poligon.Count ? 1 : step;
                for (int i = 0; i < poligon.Count; i=i+step)
                {
                    if (i < poligon.Count)
                        listPoints.Add(new Point { Lat = poligon[i][0], Lng = poligon[i][1] });
                } 
               
                listPoligons.Add(new Poligon { Type = "poligon", Points = listPoints });
            }

            return listPoligons;
        }
    }
}
