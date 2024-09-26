using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Domain
{
    public class BoundsType
    {
        public int Id { get; set; }
        private float minlat;
        public required float Minlat { get {
                return this.minlat; 
            }
            set {
                this.minlat = value >= -90f & value <= 90f ? value : throw new ArgumentOutOfRangeException(nameof(this.Minlat), "La latitude minimale doit être compris entre -90 & 90 degrès.");
            } 
        }
        private float minlon;
        public required float Minlon { get { return this.minlon; } 
            set { this.minlon = value >= -180f & value < 180f ? value : throw new ArgumentOutOfRangeException(nameof(this.Minlon), "La latitude minimale doit être compris entre -180 & 179 degrès."); } }
        private float maxlat;
        public required float Maxlat { get { return this.maxlat; } set {
                this.maxlat = value >= -90f & value <= 90f ? value : throw new ArgumentOutOfRangeException(nameof(this.Maxlat), "La latitude minimale doit être compris entre -90 & 90 degrès.");
            } }
        private float maxlon;
        public required float Maxlon { get{ return this.maxlon; } set { 
            this.maxlon = value >= -180f & value < 180f ? value : throw new ArgumentOutOfRangeException(nameof(this.Maxlon), "La latitude minimale doit être compris entre -180 & 179 degrès.");
            } }
        public int GpxMetadataTypeId {  get; set; } // clé étrangère
        public GpxMetadataType? GpxMetadataType { get; set; }

    }
}
