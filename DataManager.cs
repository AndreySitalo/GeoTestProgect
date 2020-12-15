using GeoProgect.Entuties;
using GeoProgect.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoProgect
{
    public class DataManager
    {
        private readonly IGeoRepository _geoRepository;
        private IEnumerable<Place> _places;

        public DataManager(IGeoRepository geoRepository)
        {
            _geoRepository = geoRepository; 
        }

        public string GetPlaces(string query, int step=1)
        {
            string message = "";
            try
            {
                var places = _geoRepository.GetPlaces(query, step);
                _places = places;
                if (_places.ToList().Count > 0)
                   message = String.Format("Колличество найденых данных:{0}", _places.ToList().Count);
                else
                   message = "Данные не найдены";


            }
            catch
            {
                message = "Ошибка";
            }
            return message;
        }

        public string SaveFile(string fileName) 
        {
            if(_places.ToList().Count>0)
                return FileManager.SaveFile(fileName, JsonConvert.SerializeObject(_places));
            var message = "Файл не создан";
            return message;
        }
        

    }
}
