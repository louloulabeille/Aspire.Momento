using AutoMapper;
using Memento.Gpx.Application.Repository;
using Memento.Gpx.Domain;
using Memento.Gpx.Domain.DTO.Json;
using Memento.Gpx.Infrastructures.AutoMapper;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Interfaces.Repository;
using Memento.Gpx.Interfaces.WorkOfUnit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.API.Memento.Controllers
{
    [Route("api/v1/Memento/[controller]")]
    [ApiController]
    public class GpxController(ILogger<GpxController>? logger, IMapper mapper, IGpxTypeWorkOfUnit workOfUnit) : ControllerBase
    {
        #region Properties
        //private readonly MementoDbContext _context = context;
        private readonly ILogger<GpxController>? _logger = logger;
        //private readonly GpxTypeRepository _repository = new (context);
        private readonly IGpxTypeWorkOfUnit _workOfUnit = workOfUnit;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region Constructeur
        //public GpxController(MementoDbContext context) {
        //    _context = context; 
        //}
        #endregion
        [HttpGet(Name ="GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                #region DTO Manuel
                //DTO facon manuelle
                //var datas = _repository.GatAll().Select(
                //    x => new GpxTypeDTO
                //    {
                //        Id = x.Id,
                //        Version = x.Version,
                //        Creator = x.Creator,
                //        // Object GpxMetadataType
                //        GpxMetadataType = x.GpxMetadataType is null ? null : new GpxMetadataTypeDTO
                //        {
                //            Id = x.GpxMetadataType.Id,
                //            // object PersonType
                //            Author = x.GpxMetadataType.Author is null ? null : new PersonTypeDTO
                //            {
                //                Id = x.GpxMetadataType.Author.Id,
                //                Name = x.GpxMetadataType.Author.Name,
                //                Email = x.GpxMetadataType.Author.Email,
                //                // LinkType object lien
                //                LinkType = x.GpxMetadataType.Author.LinkType is null ? null :
                //                new LinkTypeDTO
                //                {
                //                    Id = x.GpxMetadataType.Author.LinkType.Id,
                //                    Url = x.GpxMetadataType.Author.LinkType.Url,
                //                    Text = x.GpxMetadataType.Author.LinkType.Text,
                //                    Type = x.GpxMetadataType.Author.LinkType.Type
                //                }
                //            },
                //            Name = x.GpxMetadataType.Name,
                //            Desc = x.GpxMetadataType.Desc,
                //            Copyright = x.GpxMetadataType.Copyright,
                //            // collection Linktype de l'object MetaData
                //            LinkTypes = x.GpxMetadataType.LinkTypes?.Select(x => new LinkTypeDTO
                //            {
                //                Id = x.Id,
                //                Url = x.Url,
                //                Text = x.Text,
                //                Type = x.Type,
                //            }),
                //            Time = x.GpxMetadataType.Time,
                //            Keywords = x.GpxMetadataType.Keywords,
                //            // object de BoundsType 
                //            BoundsType = x.GpxMetadataType.BoundsType is null ? null :
                //            new BoundsTypeDTO
                //            {
                //                Id = x.GpxMetadataType.BoundsType.Id,
                //                Maxlat = x.GpxMetadataType.BoundsType.Maxlat,
                //                Maxlon = x.GpxMetadataType.BoundsType.Maxlon,
                //                Minlat = x.GpxMetadataType.BoundsType.Minlat,
                //                Minlon = x.GpxMetadataType.BoundsType.Minlon,
                //                GpxMetadataTypeId = x.GpxMetadataType.BoundsType.GpxMetadataTypeId
                //            },
                //            Extensions = x.GpxMetadataType.Extensions,
                //            GpxTypeId = x.GpxMetadataType.GpxTypeId
                //        },
                //        // object Waypoint à programmer
                //        GpxWptTypes = null, // le remplir par la suite
                //        Extensions = x.Extensions
                //    });
                #endregion

                //var gpx = _repository.GatAll();
                var gpx = _workOfUnit.GetInstance().GetAll();
                var datas = _mapper.Map<IEnumerable<GpxTypeDTO>>(gpx);

                if (datas is not null)
                {
                    return this.Ok(datas);
                }
                return this.NoContent();
            }
            catch(Exception exp)
            {
                var customResponse = new
                {
                    Code = 500,
                    Message = "Internal Server Error",

                    // Do not expose the actual error to the client
                    ErrorMessage = exp.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, customResponse);
            }
        }

        [HttpPost]
        public IActionResult Post(GpxTypeDTO gpx)
        {
            IActionResult retour = BadRequest();
            var gpxValue = new GpxType() { Version = "1.1", Creator = "Memento V1.0" };
            //gpxValue.GpxMetadataType = new GpxMetadataType()
            //{
            //    GpxType = gpxValue,
            //    Time = DateTime.Now,
            //    Author = new PersonType()
            //    {
            //        Name = "Lili",
            //        Email = "lili@hotmail.com",
            //        LinkType = new LinkType()
            //        {
            //            Url = "https://www.photo-paysage.com/albums/userpics/10001/Cascade_-15.JPG",
            //            Text = "Photo d'une cascade quelque part dans le monde.",
            //            Type = "Image"
            //        },
            //    }
            //};
            //var gpxValue = _mapper.Map<GpxType>(gpx);

            _workOfUnit.GetInstance().Add(gpxValue);
            int nbEng = _workOfUnit.Save();
            if ( nbEng > 0)
            {
                retour = this.Ok();
            }

            return retour;
        }
    }
}
