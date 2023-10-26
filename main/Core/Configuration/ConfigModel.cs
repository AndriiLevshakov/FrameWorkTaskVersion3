using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


namespace Core.Configuration
{
    public class ConfigModel
    {
        public string? Browser { get; set; }
        public string? Log { get; set; }
    }
}
