using Memento.Gpx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Application.DTO.Json
{
    public class PersonTypeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public LinkTypeDTO? LinkType { get; set; }
        //public required IEnumerable<GpxMetadataType> GpxMetadataType { get; set; }
    }
}
