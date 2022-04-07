using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InterviewProject.Data;
using InterviewProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewProjectTest.Data
{
    [TestClass]
    public class GetWeatherInfoByIDTest
    {

        public GetWeatherInfoByIDTest()
        {


        }
        [DataTestMethod]
        [DataRow(44418)]
        [DataRow(2487956)]

        public async Task GetWeatherInfoByIDTest_GetData_NullAsync(int id)
        {
            var getWeatherInfoByID = new GetWeatherInfoByID();
            List<WeatherInfo> result = await getWeatherInfoByID.GetWeatherAsync(id);
            Assert.IsNull(result);
        }
        [DataTestMethod]
        [DataRow(44418)]
        [DataRow(2487956)]

        public async Task GetWeatherInfoByIDTest_GetData_GreatZero(int id)
        {
            var getWeatherInfoByID = new GetWeatherInfoByID();
            List<WeatherInfo> result = await getWeatherInfoByID.GetWeatherAsync(id);
            Assert.IsTrue(result.Count > 0);
        }
        [DataTestMethod]
        [DataRow(44418)]
        [DataRow(2487956)]
        public async Task GetWeatherInfoByIDTest_GetData_EqualZero(int id)
        {
            var getWeatherInfoByID = new GetWeatherInfoByID();
            List<WeatherInfo> result = await getWeatherInfoByID.GetWeatherAsync(id);
            Assert.IsTrue(result.Count == 0);
        }

    }
}
