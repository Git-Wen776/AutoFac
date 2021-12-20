using AutoMapper;

namespace AutoFac.Extentions.AutoMapperConfig
{
    public class AutoMapperProfile<TModle,TDto>:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TModle,TDto>();
        }
    }
}
