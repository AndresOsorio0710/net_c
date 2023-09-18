using System;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BaseAPI.Util
{
	public class MasterBase
    {
        public static string ApplicationPath { get; set; }
        public readonly IConfiguration configuration;

        public static void GetApplicationPath()
        {
            var builder = Host.CreateDefaultBuilder();
            ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public MasterBase()
        {
            GetApplicationPath();
            this.configuration = new ConfigurationBuilder()
                .SetBasePath(ApplicationPath)
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();
        }
	}
}

