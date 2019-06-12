using AutoMapper;
using Domain;
using Dto;
using System;

namespace Demo.Mapper
{
    internal class EntityToDtoCommonMapper : Profile
    {
        public EntityToDtoCommonMapper()
        {
            CreateMap<Animal, AnimalDto>().AfterMap((src, dest) =>
            {
                dest.CommonNameValue = Enum.GetName(typeof(CommonName), src.CommonName);
            });
        }
    }
}