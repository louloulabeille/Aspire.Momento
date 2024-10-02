using Memento.Gpx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Memento.Gpx.Domain.DTO.Json
{
    public class LinkTypeDTO
    {
        public int Id { get; set; }
        public required string Url { get; set; } // [1] url du lien
        public string? Text { get; set; } // [0..1] texte du lien
        public string? Type { get; set; } // [0..1] type de lien
        //[JsonIgnore]
        //public IEnumerable<GpxWptType>? GpxWptTypes { get; set; }
        //[JsonIgnore]
        //public IEnumerable<GpxMetadataType>? GpxMetadataTypes { get; set; }
        //[JsonIgnore]
        //public IEnumerable<PersonType>? PersonTypes { get; set; }
    }
}
