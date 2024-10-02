﻿using Memento.Gpx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Domain.DTO.Json
{
    public class GpxTypeDTO
    {
        #region properties non serializable
        public int Id { get; set; } // clé primaire
        #endregion

        #region properties
        public required string Version { get; set; } = "1.1"; //[1]
        public required string Creator { get; set; } // [1]
        public GpxMetadataTypeDTO? GpxMetadataType { get; set; } // [0..1] Métadonnées du fichier
        public IEnumerable<GpxWptTypeDTO>? GpxWptTypes { get; set; } // [0..*] Waytpoint
        //public IEnumerable<GpxRteType>? RteTypes { get; set; } // [0..*] itinéraires 
        //public IEnumerable<GpxTrkType>? TrkTypes { get; set; } // [0..*] traces
        public string? Extensions { get; set; } // [0..1] Autoriser tout élément provenant d'un espace de noms autre que l'espace de noms de ce schéma (validation laxiste).
        #endregion
    }
}