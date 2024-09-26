using Memento.Gpx.Domain;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Interfaces.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Infrastructures.DataLayer
{
    public class GpxWptTypeDataLayer(MementoDbContext dbContext) : DataLayer<GpxWptType>(dbContext) , IGpxWptTypeDataLayer
    {
    }
}
