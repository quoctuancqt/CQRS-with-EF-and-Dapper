using AutoMapper;
using Domain;
using Dto;
using System;

namespace Demo.Mapper
{
    public class DtoToEntityCommonMapper : Profile
    {
        public DtoToEntityCommonMapper()
        {
            CreateMap<AnimalDto, Animal>().AfterMap((src, dest) =>
            {
                dest.CommonName = Enum.Parse<CommonName>(src.CommonNameValue);
            });
        }
    }
}
