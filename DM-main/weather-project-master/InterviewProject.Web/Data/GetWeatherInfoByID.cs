using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewProject.Models;
using Newtonsoft.Json.Linq;

namespace InterviewProject.Data
{
    public class GetWeatherInfoByID
    {
        public async Task<List<WeatherInfo>> GetWeatherAsync(int id)
        {

            try
            {
                List<WeatherInfo> weatherInfos = null;
                string weatherUrl = MySetting.Get("WeatherStringById:Url");
                var searchString = weatherUrl + id.ToString();
                List<JObject> resultJson = await GetAsync.Get(searchString);
                if (resultJson != null)
                {
                    weatherInfos = new List<WeatherInfo>();
                    foreach (var item in resultJson)
                    {
                        foreach (var item2 in item["consolidated_weather"])
                        {

                            var weatherInfo = new WeatherInfo();
                            weatherInfo.Date = (DateTime)item2["applicable_date"];
                            weatherInfo.TempMin = (int)item2["min_temp"];
                            weatherInfo.TempMax = (int)item2["max_temp"];
                            weatherInfos.Add(weatherInfo);
                        }
                    }
                }

                return weatherInfos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw(e);
            }
        }
    }
}
