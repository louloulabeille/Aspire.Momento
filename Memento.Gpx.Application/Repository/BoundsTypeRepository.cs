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
    public class BoundsTypeRepository (MementoDbContext dbContext) : IBoundsTypeRepository
    {
        #region Properties
        private readonly BoundsTypeDataLayer _layer = new (dbContext);
        #endregion

        #region Methode Interface IBoundsTypeRepository
        public void Add(BoundsType limiteCoordonnee)
        {
            _layer.Add(limiteCoordonnee);
        }

        public BoundsType? GetById(int id)
        {
            return _layer.GetById(id);
        }

        public void Remove(BoundsType limiteCoordonnee)
        {
            _layer.Remove(limiteCoordonnee);
        }

        public void Update(BoundsType limiteCoordonnee)
        {
            _layer.Update(limiteCoordonnee);
        }
        #endregion
    }
}
