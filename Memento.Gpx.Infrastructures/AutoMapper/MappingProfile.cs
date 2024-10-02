using AutoMapper;
using Memento.Gpx.Domain;
using Memento.Gpx.Domain.DTO.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Infrastructures.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<BoundsType, BoundsTypeDTO>();
            CreateMap<BoundsTypeDTO, BoundsType>();
            CreateMap<GpxMetadataType, GpxMetadataTypeDTO>();
            CreateMap<GpxMetadataTypeDTO, GpxMetadataType>();
            CreateMap<GpxType, GpxTypeDTO>();
            //.ForMember(dest => dest.GpxMetadataTypeDTO, opt => opt.MapFrom(x => x.GpxMetadataType))
            //.ForMember(dest => dest.GpxWptTypesDTO, opt => opt.MapFrom(x => x.GpxWptTypes));
            CreateMap<GpxTypeDTO, GpxType>();
                //.ForMember(dest => dest.GpxMetadataType, opt => opt.MapFrom(x => x.GpxMetadataTypeDTO))
                //.ForMember(dest => dest.GpxWptTypes, opt => opt.MapFrom(x => x.GpxWptTypesDTO)); ;
            CreateMap<GpxWptType, GpxWptTypeDTO>();
            CreateMap<GpxWptTypeDTO, GpxWptType>();
            CreateMap<LinkType, LinkTypeDTO>();
            CreateMap<LinkTypeDTO, LinkType>();
            CreateMap<PersonType, PersonTypeDTO>();
            CreateMap<PersonTypeDTO, PersonType>();
        }
    }
}
