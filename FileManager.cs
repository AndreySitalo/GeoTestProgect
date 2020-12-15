using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeoProgect
{
    public static class FileManager
    {
        public static string SaveFile(string name, string info)
        {
            string message = "Файл успешно создан";
            string fileName = $"{name}.json";

            using (StreamWriter writer = File.CreateText(fileName))
            {
                    writer.WriteLine(info);
                    return message;
            }
        }
    }
}
