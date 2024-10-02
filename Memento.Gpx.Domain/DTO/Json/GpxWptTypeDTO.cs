using Memento.Gpx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Domain.DTO.Json
{
    public class GpxWptTypeDTO
    {
        public int Id { get; set; }
        public float Lat; // [1] latitude compris entre -90<= x <=+90
        public float Lon; // [1] longitude compris entre  -180<= y <180
        public float? Ele { get; set; } // [0..1] altitude 
        public DateTime? Time { get; set; } // [0..1] date time du Waypoint
        public float? Magvar; // [0..1] déclinaison magnétique en degrès compris entre 0.0<= x <360.0
        public float? Geoidheight { get; set; } // [0..1] la hauteur Géoide
        public string? Name { get; set; } // [0..1] Nom du WayPoint (point d'intérêt ou point de passage)
        public string? Cmt { get; set; } // [0..1] Commentaire
        public string? Desc { get; set; } // [0..1] Description
        public string? Src { get; set; } // [0..1] Le modèle et le fabricant de l'appareil à l'origine de la géolocalisation du point
        public IEnumerable<LinkTypeDTO>? LinkTypes { get; set; } // [0..*] un ou plusieurs liens vers des informations additionnels
        public string? Sym { get; set; } // [0..1] le nom exact du symbole illustrant le point sur l'appareil GPS
        public string? Type { get; set; } // [0..1] le type de point
        public string? Fix { get; set; } // [0..1] le type de GPX utilisé exemple <xsd:enumeration value="pps"/> pps = gps militaire
        public byte? Sat { get; set; } // [0..1] nombre de satellite qui ont géolocalisé le point
        public float? Hdop { get; set; } // [0..1] (Horizontal dilution of precision.) précision de la mesure (horizontal) voir https://fr.wikipedia.org/wiki/Geometric_dilution_of_precision
        public float? Vdop { get; set; } // [0..1] (Vertical dilution of precision.) précision de la mesure (verticale)
        public float? Pdop { get; set; } // [0..1] (Position dilution of precision.)
        public float? Ageofgpsdata { get; set; } // [0..1] la durée depuis la dernière mise à jour du GPS
        // [0..1] identifiant de la station
        public int? Dgpsid;
        public string? Extensions { get; set; } // [0..1] extension qui peuvent être rajouté dans le fichier
    }
}
