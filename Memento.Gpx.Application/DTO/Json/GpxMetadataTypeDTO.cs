﻿using Memento.Gpx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Gpx.Application.DTO.Json
{
    public class GpxMetadataTypeDTO
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; } // [0..1]
        public string? Desc { get; set; } // [0..1]
        public PersonTypeDTO? Author { get; set; } // [0..1]
        public string? Copyright { get; set; } // [0..1]
        public IEnumerable<LinkTypeDTO>? LinkTypesDTO { get; set; } // [0..*] lien extérieur du fichier GPX                                           
        public DateTime? Time { get; set; } // [0..1] date de création du document
        public string? Keywords { get; set; } //[0..1] mots clés 
        /// <summary>
        /// A gérer priorité haute. Création d'un type coordonnée et CoordonnéesBounds
        /// </summary>
        //[NotMapped]
        public BoundsTypeDTO? BoundsTypeDTO { get; set; } // [0..1] limite des coordonnées
        public string? Extensions { get; set; } // [0..1] extension qui peuvent être rajouté dans le fichier
        public int GpxTypeId { get; set; }
        #endregion
    }
}