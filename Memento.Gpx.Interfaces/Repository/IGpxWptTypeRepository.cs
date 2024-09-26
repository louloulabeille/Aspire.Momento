using Memento.Gpx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Interfaces.Repository
{
    public interface IGpxWptTypeRepository
    {
        public GpxWptType? GetById(int id);
        public IEnumerable<GpxWptType> GatAll();
        public void Add(GpxWptType wayPoint);
        public void Remove(GpxWptType wayPoint);
        public void Update(GpxWptType wayPoint);
    }
}
