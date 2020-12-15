using GeoProgect.Implementations;
using GeoProgect.Interfaces;
using System;

namespace GeoProgect
{
    class Program
    {
        static void Main(string[] args)
        {
            string query = "";
            string fileName = "file";
            
            int step = 1;
            int numberGeoResurse = 1;

            Console.Write("Введите поисковую строку:");
            query = Console.ReadLine();

            Console.Write("Введите кратность координат(число):");
            step = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Выберите сервис(число):");
            Console.WriteLine("1.Open Street Map");
            Console.WriteLine("2.Google");
            Console.WriteLine("3.Yandex");
            Console.WriteLine("4.Bing");
            Console.Write("Введите:");
            numberGeoResurse = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите имя файла:");
            fileName = Console.ReadLine();

            Start(query, step, numberGeoResurse, fileName);

            Console.WriteLine("!!!!!!!!!!!");
        }

        public static void Start(string query, int step, int numberGeoResurse, string fileName)
        {
            string message = "";
            var rep = GetgeoRepository(step);
            var dataManager = new DataManager(rep);

            message = dataManager.GetPlaces(query, step);
            Console.WriteLine(message);

            message = dataManager.SaveFile(fileName);
            Console.WriteLine(message);
        }
        public static IGeoRepository GetgeoRepository(int step)
        {

            switch (step) 
            {
                case 1:
                    return new OsmApiRepository();
                case 2:
                    return new OsmApiRepository();
                case 3:
                    return new OsmApiRepository();
                case 4:
                    return new OsmApiRepository();
                default:
                    return new OsmApiRepository();
            }
        }
    }
}
