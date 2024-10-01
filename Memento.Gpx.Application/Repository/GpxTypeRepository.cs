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
    public class GpxTypeRepository (MementoDbContext dbContext) : IGpxTypeRepository
    {
        #region Propriété
        private readonly GpxTypeDataLayer _layer = new(dbContext);
        #endregion

        #region Methode Interface IGpxTypeRepository
        public void Add(GpxType fichierGpx)
        {
            _layer.Add(fichierGpx);
        }

        public IEnumerable<GpxType> GatAll()
        {
            return _layer.GetAll();
        }

        public IEnumerable<GpxType> GetGpxByDescDate()
        {
            return _layer.GetAll().OrderByDescending(item => item.Created);
        }

        public GpxType? GetById(int id)
        {
            return _layer.GetById(id);
        }

        public void Remove(GpxType fichierGpx)
        {
            _layer.Remove(fichierGpx);
        }

        public void Update(GpxType fichierGpx)
        {
            _layer.Update(fichierGpx);
        }
        #endregion
    }
}
