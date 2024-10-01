using Memento.Gpx.Domain;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Infrastructures.DataLayer;
using Memento.Gpx.Interfaces.Layout;
using Memento.Gpx.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Application.Repository
{
    public class GpxMetadataTypeRepository (MementoDbContext dbContext) : IGpxMetaDataTypeRepository
    {
        #region Properties
        private readonly GpxMetaDataTypeDataLayer _layer = new (dbContext);
        #endregion 

        #region Méhode Interface IGpxMetaDataTypeRepository
        public void Add(GpxMetadataType metaData)
        {
            _layer.Add(metaData);
        }

        public GpxMetadataType? GetById(int id)
        {
            return _layer.GetById(id);
        }

        public void Remove(GpxMetadataType metaData)
        {
            _layer.Remove(metaData);
        }

        public void Update(GpxMetadataType metaData)
        {
            _layer.Update(metaData);
        }
        #endregion
    }
}
