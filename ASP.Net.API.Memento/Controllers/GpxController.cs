using Memento.Gpx.Application.Repository;
using Memento.Gpx.Domain;
using Memento.Gpx.Infrastructures.Data;
using Memento.Gpx.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.API.Memento.Controllers
{
    [Route("api/v1/Memento/[controller]")]
    [ApiController]
    public class GpxController(MementoDbContext context, ILogger<GpxController>? logger) : ControllerBase
    {
        #region Properties
        private readonly MementoDbContext _context = context;
        private readonly ILogger<GpxController>? _logger = logger;
        private readonly GpxTypeRepository _repository = new (context);
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
                var datas = _repository.GatAll();

                if (datas is not null)
                {
                    foreach (var data in datas)
                    {
                        Console.WriteLine($"{data.Id} {data.Version} {data.Creator} {data.GpxMetadataType?.Time}");
                    }
                    var first = datas.First();
                    var dat = new GpxType() { Id = first.Id, Version = first.Version, Creator = first.Creator };
                    return this.Ok(dat);
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
