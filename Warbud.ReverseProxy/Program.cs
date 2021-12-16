using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Warbud.Shared.Configurations;

namespace Warbud.ReverseProxy
{
    public class Program
    {
        private const string ConfigPath = "C:/Users/afranczak/source/repos/Nairda015/Warbud/ports.json";
        private static Dictionary<string, int> _ports;
        public static void Main(string[] args)
        {
            var config = File.ReadAllText(ConfigPath);
            _ports = JsonSerializer.Deserialize<Dictionary<string, int>>(config);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    var port = UseUrlsConfiguration.Configure()
                        .SetConfigPath("C:/Users/afranczak/source/repos/Nairda015/Warbud/ports.json")
                        .GetPort("Proxy");
                    webBuilder.UseUrls($"http://localhost:{port.ToString()}");
                });
    }
}