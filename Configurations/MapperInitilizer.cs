using AutoMapper;
using Trevoir.Data;
using Trevoir.DTOS;

namespace Trevoir.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotels, HotelDTOS>().ReverseMap();
            CreateMap<HotelDTOS, CreateHotelDTO>().ReverseMap();
        }
    }
}
