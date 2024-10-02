using Memento.Gpx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Memento.Gpx.Domain.DTO.Json
{
    public class BoundsTypeDTO
    {
        public int Id { get; set; }
        public required float Minlat;
        public required float Minlon;
        public required float Maxlat;
        public required float Maxlon;
        public int GpxMetadataTypeId { get; set; } // clé étrangère
        //[JsonIgnore]
        //public GpxMetadataTypeDTO? GpxMetadataType { get; set; }
    }
}
