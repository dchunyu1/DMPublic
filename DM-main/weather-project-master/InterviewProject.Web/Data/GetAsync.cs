using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace InterviewProject.Data
{
    public class GetAsync
    {

        public static async Task<List<JObject>> Get(string path)
        {
            try
            {
                List<JObject> contentJson = new List<JObject>();
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //contentJson = JsonSerializer.Deserialize<JsonTokenType>(content);
                    if (content.Substring(0, 1) != "[")
                    {
                        content = "[" + content + "]";
                    }
                    JArray jsonArray = JArray.Parse(content);
                    contentJson = jsonArray.OfType<JObject>().ToList();
                    //var t = result["someObj"]; //contains 5
                }
                return contentJson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
    } 
}
