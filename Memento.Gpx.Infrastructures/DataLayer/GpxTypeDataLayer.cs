using Memento.Gpx.Domain;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Interfaces.Layout;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Infrastructures.DataLayer
{
    public class GpxTypeDataLayer (MementoDbContext dbContext) : DataLayer<GpxType> (dbContext) , IGpxTypeDataLayer
    {
        #region méthode ovveride
        public override IEnumerable<GpxType> GetAll()
        {
            return [.. base._dbSet.Include(x => x.GpxMetadataType).Include(x => x.GpxWptTypes)];
        }
        public override IEnumerable<GpxType> Find(Expression<Func<GpxType, bool>> predicate)
        {
            return [.. base._dbSet.Where(predicate).Include(x => x.GpxMetadataType)
                .Include(x => x.GpxWptTypes)];
        }
        public override GpxType? GetById(int id)
        {
            return base._dbSet.Include(x => x.GpxMetadataType).Include(x => x.GpxWptTypes)
                .Where(x => x.Id == id).FirstOrDefault();
        }
        #endregion
    }
}
