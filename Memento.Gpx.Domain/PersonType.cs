using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Domain
{
    public class PersonType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public LinkType? LinkType { get; set; } 
        public IEnumerable<GpxMetadataType>? GpxMetadataType { get; set; }
    }
}
