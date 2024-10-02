using AutoMapper;
using Memento.Gpx.Domain;
using Memento.Gpx.Domain.DTO.Json;

namespace Memento.Gpx.Infrastructures.AutoMapper
{
    /// <summary>
    /// utilisation de AutoMapper pour automatiser la correcpondance entre le DTO et le model
    /// </summary>
    public class MapperConfig
    {
        public static Mapper InitializeMapper()
        {
            var config = new MapperConfiguration(item => {
                item.AllowNullCollections = true;
                item.CreateMap<BoundsType, BoundsTypeDTO>();
                item.CreateMap<GpxMetadataType, GpxMetadataTypeDTO> ();
                item.CreateMap<GpxType,GpxTypeDTO>();
                item.CreateMap<GpxWptType,GpxWptTypeDTO>();
                item.CreateMap<LinkType,LinkTypeDTO>();
                item.CreateMap<PersonType,PersonTypeDTO>();
            });

            return new(config);
        }
    }
}
