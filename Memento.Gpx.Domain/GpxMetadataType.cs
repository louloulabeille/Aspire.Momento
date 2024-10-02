using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Domain
{
    /// <summary>
    /// voir lien https://www.topografix.com/GPX/1/1/#type_metadataType
    /// & https://fr.wikipedia.org/wiki/GPX_(format_de_fichier)
    /// version GPX 1.1
    /// </summary>
    public class GpxMetadataType
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; } // [0..1]
        public string? Desc { get; set; } // [0..1]
        public PersonType? Author { get; set; } // [0..1]
        public string? Copyright { get; set; } // [0..1]
        public IEnumerable<LinkType>? LinkTypes { get; set; } // [0..*] lien extérieur du fichier GPX                                           
        public DateTime? Time { get; set; } // [0..1] date de création du document
        public string? Keywords { get; set; } //[0..1] mots clés 
        /// <summary>
        /// A gérer priorité haute. Création d'un type coordonnée et CoordonnéesBounds
        /// </summary>
        //[NotMapped]
        public BoundsType? BoundsType { get; set; } // [0..1] limite des coordonnées
        public string? Extensions { get; set; } // [0..1] extension qui peuvent être rajouté dans le fichier
        public int GpxTypeId { get; set; }
        public GpxType? GpxType { get; set; }
        #endregion
    }

    //public readonly struct BoundsType
    //{
    //    public BoundsType(float minlat, float minlon, float maxlat, float maxlon)
    //    {
    //        Minlat = minlat >= -90f & minlat <= 90f ? minlat : throw new ArgumentOutOfRangeException(nameof(minlat),"La latitude minimale doit être compris entre -90 & 90 degrès."); 
    //        Minlon = minlon >= -180f & minlon < 180f ? minlon : throw new ArgumentOutOfRangeException(nameof(minlat), "La latitude minimale doit être compris entre -180 & 179 degrès."); 
    //        Maxlat = maxlat >= -90f & maxlat <= 90f ? maxlat : throw new ArgumentOutOfRangeException(nameof(maxlat), "La latitude minimale doit être compris entre -90 & 90 degrès."); ; 
    //        Maxlon = maxlon >= -180f & minlon < 180f ? minlon : throw new ArgumentOutOfRangeException(nameof(minlat), "La latitude minimale doit être compris entre -180 & 179 degrès.");

    //    }
    //    public float Minlat { get; init; }
    //    public float Minlon { get; init; }
    //    public float Maxlat { get; init; }
    //    public float Maxlon {  get; init; }
    //}
}
