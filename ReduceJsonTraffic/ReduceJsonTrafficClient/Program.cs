﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReduceJsonTrafficModels;

namespace ReduceJsonTrafficClient
{
    public class Program
    {
        private const string BaseUrl = "http://reducejsontraffic.azurewebsites.net/api/";

        private static void Main(string[] args)
        {
            Task.Factory.StartNew(RunAsync);
            Console.WriteLine("Waiting...");
            Console.WriteLine();
            Console.Read();
        }

        private static async Task RunAsync()
        {
            var httpClient = new HttpClient();
            
            // Default
            var defaultData = await httpClient.GetStringAsync(new Uri(BaseUrl + "default"));
            Console.WriteLine("default size: {0}b ({1:F}%)", defaultData.Length, Reduction(defaultData, defaultData));
            var defaultMessages = JsonConvert.DeserializeObject<Message[]>(defaultData);

            // Default Value Handling
            var settings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate };

            var defaultValueHandlingData = await httpClient.GetStringAsync(new Uri(BaseUrl + "defaultvaluehandling"));
            Console.WriteLine("default value handling size: {0}b ({1:F}%)", defaultValueHandlingData.Length, Reduction(defaultData, defaultValueHandlingData));
            var defaultHandlingMessages = JsonConvert.DeserializeObject<Message[]>(defaultValueHandlingData, settings);

            // Skip Empty Collections
            var skipEmptyCollectionsData = await httpClient.GetStringAsync(new Uri(BaseUrl + "skipemptycollection"));
            Console.WriteLine("skip empty collections size: {0}b ({1:F}%)", skipEmptyCollectionsData.Length, Reduction(defaultData, skipEmptyCollectionsData));
            var skipEmptyCollectionsMessages = JsonConvert.DeserializeObject<Message[]>(skipEmptyCollectionsData, settings);
        }

        private static double Reduction(string original, string @new)
        {
            return (@new.Length - original.Length)/(original.Length*0.01);
        }
    }
}