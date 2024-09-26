using Memento.Gpx.Domain;
using Memento.Gpx.Infrastructures.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.API.Memento.Controllers
{
    [Route("api/v1/Memento/[controller]")]
    [ApiController]
    public class GpxController(MementoDbContext context, ILogger<GpxController> logger) : ControllerBase
    {
        #region Properties
        private readonly MementoDbContext _context = context;
        private readonly ILogger<GpxController> _logger = logger;
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
                var datas = Enumerable.Range(1, 5).Select(index => new GpxType
                {
                    Id = index,
                    Version = "1.1",
                    Creator = "Louloulabeille" + index.ToString(),
                }).ToArray();

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

            _context.Add(gpxValue);
            _context.SaveChanges();

            return this.Ok();
        }
    }
}
