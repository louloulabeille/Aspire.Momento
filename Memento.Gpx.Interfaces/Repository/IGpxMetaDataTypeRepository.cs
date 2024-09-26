using Memento.Gpx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Interfaces.Repository
{
    public interface IGpxMetaDataTypeRepository
    {
        public void Add(GpxMetadataType metaData);
        public void Remove(GpxMetadataType metaData);
        public void Update(GpxMetadataType metaData);
        public GpxMetadataType? Find(int id);
    }
}
