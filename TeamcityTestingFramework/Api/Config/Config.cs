using Microsoft.Extensions.Configuration;

namespace TeamcityTestingFramework.Api.Config
{
    public class Config
    {
        private static Config _config;
        public IConfiguration _configuration { get; private set; }

        private Config()
        {
            Initialize();
        }

        private static Config GetConfig()
        {
            _config ??= new Config();
            return _config;
        }

        public static T GetProperty<T>(string key)
        {
            var value = GetConfig()._configuration[key];

            return value == null
                ? throw new KeyNotFoundException($"Key '{key}' not found in configuration.")
                : (T)Convert.ChangeType(value, typeof(T));
        }

        private void Initialize()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            _configuration = config;
        }
    }
}
