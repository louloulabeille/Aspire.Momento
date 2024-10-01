using Memento.Gpx.Domain;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Infrastructures.DataLayer;
using Memento.Gpx.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Application.Repository
{
    public class GpxWptTypeRepository (MementoDbContext dbContext) : IGpxWptTypeRepository
    {
        #region Properties
        private readonly GpxWptTypeDataLayer _layer = new(dbContext);
        #endregion

        #region Méthode interface IGpxWptTypeRepository
        public void Add(GpxWptType wayPoint)
        {
            _layer.Add(wayPoint);
        }

        public IEnumerable<GpxWptType> GatAll()
        {
            return _layer.GetAll();
        }

        public GpxWptType? GetById(int id)
        {
            return _layer.GetById(id);
        }

        public void Remove(GpxWptType wayPoint)
        {
            _layer.Remove(wayPoint);
        }

        public void Update(GpxWptType wayPoint)
        {
            _layer.Update(wayPoint);
        }
        #endregion
    }
}
