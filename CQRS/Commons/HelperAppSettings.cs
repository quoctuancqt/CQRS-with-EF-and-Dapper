namespace CQRS.Commons
{
    using Microsoft.Extensions.Configuration;

    public class HelperAppSettings
    {
        private static IConfiguration _configuration;

        public HelperAppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string ConnectionString
        {
            get
            {
                return _configuration.GetConnectionString("Default");
            }
        }
    }
}
