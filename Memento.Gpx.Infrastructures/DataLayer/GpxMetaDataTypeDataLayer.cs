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
    public class GpxMetaDataTypeDataLayer(MementoDbContext dbContext) : DataLayer<GpxMetadataType>(dbContext) , IGpxMetaDataTypeDataLayer
    {
        #region méthode ovveride
        public override GpxMetadataType? GetById(int id)
        {
            return base._dbSet.Include(x => x.GpxType).Include(x => x.LinkTypes)
                .Include(x => x.Author).Include(x => x.BoundsType)
                .Where(x => x.Id == id).FirstOrDefault();
        }
        #endregion
    }
}
