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
    public class SearchByLocationTest
    {
        string weatherUrl;
        public SearchByLocationTest()
        {

        }
        [DataTestMethod]
        [DataRow("")]
        [DataRow("san")]
        [DataRow("columbia")]
        [DataRow("london")]
        public async Task SearchByLocation_GetData_NullAsync(string location)
        {
            var searchBylocation = new SearchByLocation();
            List<Location> result = await searchBylocation.SearchAsync(location);
            //Console.WriteLine("I am here");
            Assert.IsNull(result);
        }
        [DataTestMethod]
        [DataRow("")]
        [DataRow("san")]
        [DataRow("columbia")]
        [DataRow("london")]
        public async Task SearchByLocation_GetData_GreatZeroAsync(string location)
        {
            var searchBylocation = new SearchByLocation();
            List<Location> result = await searchBylocation.SearchAsync(location);
            //Console.WriteLine("I am here");
            Assert.IsTrue(result.Count > 0);
        }
        [DataTestMethod]
        [DataRow("")]
        [DataRow("san")]
        [DataRow("columbia")]
        [DataRow("london")]
        public async Task SearchByLocation_GetData_EqualZeroAsync(string location)
        {
            var searchBylocation = new SearchByLocation();
            List<Location> result = await searchBylocation.SearchAsync(location);
            //Console.WriteLine("I am here");
            Assert.IsTrue(result.Count== 0);
        }

    }
}
