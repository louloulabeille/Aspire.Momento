using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Domain
{
    public class GpxWptType
    {
        public int Id { get; set; }
        private float lat; // [1] latitude compris entre -90<= x <=+90
        public required float Lat { 
            get { return this.lat; }
            set {
                this.lat = value >= -90f && value <= 90f ? value : throw new ArgumentOutOfRangeException(nameof(value), "la latitude doit être compris entre -90 & 90 degrès.");
            } 
        }
        private float lon; // [1] longitude compris entre  -180<= y <180
        public required float Lon {
            get { return this.lon; }
            set {
                this.lon = value >= -180f && value < 180f ? value : throw new ArgumentOutOfRangeException(nameof(value), "la longitude doit être compris en -180 & 180 degrès.");
                } 
        } 
        public float? Ele { get; set; } // [0..1] altitude 
        public DateTime? Time { get; set; } // [0..1] date time du Waypoint
        private float? magvar; // [0..1] déclinaison magnétique en degrès compris entre 0.0<= x <360.0
        public float? Magvar {
            get { return this.magvar; }
            set
            {
                this.magvar = value >= 0f & value < 360f ? value : throw new ArgumentOutOfRangeException(nameof(value),"la déclinaison magnétique est compris entre 0 & 360 degrès.");
            } 
        } 
        public float? Geoidheight { get; set; } // [0..1] la hauteur Géoide
        public string? Name { get; set; } // [0..1] Nom du WayPoint (point d'intérêt ou point de passage)
        public string? Cmt {  get; set; } // [0..1] Commentaire
        public string? Desc { get; set; } // [0..1] Description
        public string? Src { get; set; } // [0..1] Le modèle et le fabricant de l'appareil à l'origine de la géolocalisation du point
        public IEnumerable<LinkType>? LinkTypes { get; set; } // [0..*] un ou plusieurs liens vers des informations additionnels
        public string? Sym {  get; set; } // [0..1] le nom exact du symbole illustrant le point sur l'appareil GPS
        public string? Type { get; set; } // [0..1] le type de point
        public string? Fix { get; set; } // [0..1] le type de GPX utilisé exemple <xsd:enumeration value="pps"/> pps = gps militaire
        public byte? Sat { get; set; } // [0..1] nombre de satellite qui ont géolocalisé le point
        public float? Hdop { get; set; } // [0..1] (Horizontal dilution of precision.) précision de la mesure (horizontal) voir https://fr.wikipedia.org/wiki/Geometric_dilution_of_precision
        public float? Vdop { get; set; } // [0..1] (Vertical dilution of precision.) précision de la mesure (verticale)
        public float? Pdop { get; set; } // [0..1] (Position dilution of precision.)
        public float? Ageofgpsdata { get; set; } // [0..1] la durée depuis la dernière mise à jour du GPS
        
        private int? dgpsid; // [0..1] identifiant de la station
        public int? Dgpsid
        {
            get { return this.dgpsid; }
            set {
                // test la valeur doit être compris entre 0 & 1023 satellite
                if (value > 1023 || value < 0) throw new ArgumentOutOfRangeException(nameof(value),"la valeur doit être compris entre 0 & 1023.");
                this.dgpsid = value;
            }
        }
        public string? Extensions { get; set; } // [0..1] extension qui peuvent être rajouté dans le fichier
        public required GpxType GpxType { get; set; }


    }
}
