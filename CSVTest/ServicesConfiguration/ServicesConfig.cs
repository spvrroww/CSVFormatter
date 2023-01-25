using CSVTest.Services;

namespace CSVTest.ServicesConfiguration
{
    public static class ServicesConfig
    {
        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) => builder.
            AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));
    }
}
