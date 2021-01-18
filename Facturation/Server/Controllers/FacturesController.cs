using AutoMapper;
using Facturation.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturesController : ControllerBase
    {

        private readonly ILogger<FacturesController> _logger;
        private readonly IBusinessData _data;
        /*private BusinessData _bdata;*/
        private readonly IMapper _mapper;
        public FacturesController(ILogger<FacturesController> logger, IBusinessData data/*, BusinessData bdata*/, IMapper mapper)
        /*public FacturesController(ILogger<FacturesController> logger, IBusinessData data)*/
        {
            this._logger = logger;
            this._data = data;
            this._mapper = mapper;
            /*this._bdata = bdata;*/

        }

        [HttpGet]
        public IEnumerable<Facture> Get()
        /*public IEnumerable<FactureDTO> Get()*/
        {
            /*            var rng = new Random();
                        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = rng.Next(-20, 55),
                            Summary = Summaries[rng.Next(Summaries.Length)]
                        })
                        .ToArray();*/
            var factures = _data.Factures.ToList();
            /*Console.WriteLine("TYPE de la variable factures : "+factures.GetType());
            Console.WriteLine("TYPE de _data.Factures : "+_data.Factures.GetType());*/
            /*var facturesDTO = _mapper.Map<IEnumerable<FactureDTO>>(factures);
            var facturesDTO = _mapper.Map<IEnumerable<FactureDTO>>(factures);*/
            /*var facturesDTO = _mapper.Map<List<FactureDTO>>(factures);*/
            /*IEnumerable<FactureDTO> facturesDTO = _mapper.Map<IEnumerable<Facture>, IEnumerable<FactureDTO>>(_data.Factures);*/

            return _data.Factures;

            /*return _data.FacturesDTO;*/
            /*return facturesDTO;*/
            /*return null;*/
        }

        [HttpGet("{code}")]
        public ActionResult<Facture> Get(string code)
        {
            var facture = _data.Factures.Where(fac => fac.code == code).FirstOrDefault();
            if (facture != null)
            {
                return facture;
            }
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<FactureDTO> Post([FromBody]FactureDTO newFac)
        {
            // Créer un objet facture depuis le paramètre newFac en JSON          

            if(ModelState.IsValid)
            {
                //TODO : Ajouter la nouvelle facture à la collection
                this._data.addFac(newFac);
                return Created($"factures/{newFac.code}", newFac);
            } else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}
