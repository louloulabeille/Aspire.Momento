using Memento.Gpx.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Interfaces.WorkOfUnit
{
    public interface IGpxTypeWorkOfUnit : IDisposable
    {
        public IGpxTypeRepository GetInstance();
        public int Save();
    }
}
