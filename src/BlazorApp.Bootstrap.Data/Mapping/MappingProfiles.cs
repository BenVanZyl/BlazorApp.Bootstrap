using AutoMapper;
using BlazorApp.Bootstrap.Data.Domain;
using BlazorApp.Bootstrap.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Data.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Region, SelectLitsDto>()
                .ForMember(d => d.Value, m => m.MapFrom(c => c.Id.ToString()))
                .ForMember(d => d.DisplayText, m => m.MapFrom(c => c.RegionName));

            //CreateMap<Activity, ActivityDto>()
            //    .ForMember(d => d.ActivityType, m => m.MapFrom(c => c.ActivityType.Name));
        }
    }
}
