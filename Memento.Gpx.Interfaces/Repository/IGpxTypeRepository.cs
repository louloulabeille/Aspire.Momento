using Memento.Gpx.Domain;
using Memento.Gpx.Domain.DTO.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Interfaces.Repository
{
    public interface IGpxTypeRepository
    {
        public void Add(GpxType fichierGpx);
        public IEnumerable<GpxType> GatAll();
        public void Remove(GpxType fichierGpx);
        public void Update(GpxType fichierGpx);
        public GpxType? GetById(int id);
        public IEnumerable<GpxType> GetGpxByDescDate();
    }
}
