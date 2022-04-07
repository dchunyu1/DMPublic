using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace InterviewProject.Data
{
    public class MySetting
    {
        private static IConfiguration configuration;
        static MySetting()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("myconfig.json", optional: true, reloadOnChange: true);
                configuration = builder.Build();
            }
            catch (Exception e)
            {
                //all those console write I need implement the error log utility class
                Console.WriteLine(e);
                //throw the e back out so the error will not be swallowed.
                throw(e);
            }
        }

        public static string Get(string name)
        {
            try
            {
                string appSettings = configuration.GetValue<string>(
                    name); ;
                return appSettings;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw(e);
            }
        }
    }
}
