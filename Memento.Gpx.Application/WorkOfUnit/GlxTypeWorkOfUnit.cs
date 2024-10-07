using Memento.Gpx.Application.Repository;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Interfaces.Repository;
using Memento.Gpx.Interfaces.WorkOfUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Application.WorkOfUnit
{
    /// <summary>
    /// comme d'hab modifié ce WorkOfUnit
    /// </summary>
    /// <param name="dbContext"></param>
    public class GlxTypeWorkOfUnit(MementoDbContext dbContext) : IGpxTypeWorkOfUnit
    {
        #region Properties
        private readonly MementoDbContext _context = dbContext;
        private readonly IGpxTypeRepository _entitie = new GpxTypeRepository(dbContext);
        #endregion

        #region Méthode d'interface IGpxTypeWorkOfUnit
        public virtual void Dispose() => GC.SuppressFinalize(this);

        public IGpxTypeRepository GetInstance()
        {
            return _entitie;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
        #endregion
    }
}
