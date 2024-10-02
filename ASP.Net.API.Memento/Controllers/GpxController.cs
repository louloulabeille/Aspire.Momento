using AutoMapper;
using Memento.Gpx.Application.Repository;
using Memento.Gpx.Domain;
using Memento.Gpx.Domain.DTO.Json;
using Memento.Gpx.Infrastructures.AutoMapper;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.API.Memento.Controllers
{
    [Route("api/v1/Memento/[controller]")]
    [ApiController]
    public class GpxController(MementoDbContext context, ILogger<GpxController>? logger, IMapper mapper) : ControllerBase
    {
        #region Properties
        private readonly MementoDbContext _context = context;
        private readonly ILogger<GpxController>? _logger = logger;
        private readonly GpxTypeRepository _repository = new (context);
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
                // DTO facon manuelle
                //var datas = _repository.GatAll().Select(
                //    x => new GpxTypeDTO
                //    {
                //        Id = x.Id,
                //        Version = x.Version,
                //        Creator = x.Creator,
                //        // Object GpxMetadataType
                //        GpxMetadataTypeDTO = x.GpxMetadataType is null ? null : new GpxMetadataTypeDTO
                //        {
                //            Id = x.GpxMetadataType.Id,
                //            // object PersonType
                //            Author = x.GpxMetadataType.Author is null ? null : new PersonTypeDTO
                //            {
                //                Id = x.GpxMetadataType.Author.Id,
                //                Name = x.GpxMetadataType.Author.Name,
                //                Email = x.GpxMetadataType.Author.Email,
                //                // LinkType object lien
                //                LinkTypeDTO = x.GpxMetadataType.Author.LinkType is null ? null :
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
                //            LinkTypesDTO = x.GpxMetadataType.LinkTypes?.Select(x => new LinkTypeDTO
                //            {
                //                Id = x.Id,
                //                Url = x.Url,
                //                Text = x.Text,
                //                Type = x.Type,
                //            }),
                //            Time = x.GpxMetadataType.Time,
                //            Keywords = x.GpxMetadataType.Keywords,
                //            // object de BoundsType 
                //            BoundsTypeDTO = x.GpxMetadataType.BoundsType is null ? null :
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
                //        GpxWptTypesDTO = null, // le remplir par la suite
                //        Extensions = x.Extensions
                //    });
                #endregion
                var gpx = _repository.GatAll();
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
        public IActionResult Post()
        {
            var gpxValue = new GpxType() { Version = "1.1", Creator = "loulou"};
            gpxValue.GpxMetadataType = new GpxMetadataType() {
                GpxType = gpxValue,
                Time = DateTime.Now,
            };

            _repository.Add(gpxValue);
            _context.SaveChanges();

            return this.Ok();
        }
    }
}
