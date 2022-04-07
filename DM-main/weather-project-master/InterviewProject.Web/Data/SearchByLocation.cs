using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewProject.Models;
using Newtonsoft.Json.Linq;

namespace InterviewProject.Data
{
    public class SearchByLocation
    {
        public async Task<List<Location>> SearchAsync(string searchString)
        {

            try
            {
                List<Location> locations = null;
                string weatherUrl = MySetting.Get("WeatherString:Url");
                List<JObject> resultJson = await GetAsync.Get(weatherUrl + searchString);
                if (resultJson != null)
                {
                    locations = new List<Location>();
                    foreach (var item in resultJson)
                    {
                        var location = new Location();
                        location.WoeID = (int)item["woeid"];
                        location.LocationName = (string)item["title"];
                        locations.Add(location);
                    }
                }

                return locations;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
