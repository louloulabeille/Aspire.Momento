using Memento.Gpx.Domain;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Interfaces.Layout;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Infrastructures.DataLayer
{
    public class GpxWptTypeDataLayer(MementoDbContext dbContext) : DataLayer<GpxWptType>(dbContext) , IGpxWptTypeDataLayer
    {
        #region méthode ovveride
        public override IEnumerable<GpxWptType> GetAll()
        {
            return [.. base._dbSet.Include(x => x.GpxType).Include(x => x.LinkTypes)];
        }

        public override GpxWptType? GetById(int id)
        {
            return base._dbSet.Include(x => x.GpxType).Include(x => x.LinkTypes)
                .Where(x => x.Id == id).FirstOrDefault();
        }
        #endregion
    }
}
