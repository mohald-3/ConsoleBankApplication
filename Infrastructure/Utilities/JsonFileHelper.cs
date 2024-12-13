﻿using System.Text.Json;

namespace ConsoleBankApplication.Infrastructure.Utilities
{
    public static class JsonFileHelper
    {
        public static List<T> LoadFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public static void SaveToFile<T>(string filePath, List<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
