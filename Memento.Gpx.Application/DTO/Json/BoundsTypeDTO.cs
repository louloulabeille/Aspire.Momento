using Memento.Gpx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Application.DTO.Json
{
    public class BoundsTypeDTO
    {
        public int Id { get; set; }
        public required float Minlat;
        public required float Minlon;
        public required float Maxlat;
        public required float Maxlon;
        public int GpxMetadataTypeId { get; set; } // clé étrangère
        //public GpxMetadataType? GpxMetadataType { get; set; }
    }
}
