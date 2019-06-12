namespace Demo.Mapper
{
    using AutoMapper;

    public class ConfigurationMapper
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new EntityToDtoCommonMapper());
                cfg.AddProfile(new DtoToEntityCommonMapper());
            });
        }

    }
}
