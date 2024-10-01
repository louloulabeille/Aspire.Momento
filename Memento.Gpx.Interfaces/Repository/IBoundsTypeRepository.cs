using Memento.Gpx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Interfaces.Repository
{
    public interface IBoundsTypeRepository
    {
        public void Add(BoundsType limiteCoordonnee);
        public void Remove(BoundsType limiteCoordonnee);
        public void Update(BoundsType limiteCoordonnee);
        public BoundsType? GetById(int id);
    }
}
