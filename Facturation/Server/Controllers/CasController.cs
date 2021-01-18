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
    public class CasController : ControllerBase
    {

        private readonly ILogger<FacturesController> _logger;
        private readonly IBusinessData _data;
        /*private BusinessData _bdata;*/
        private readonly IMapper _mapper;
        public CasController(ILogger<FacturesController> logger, IBusinessData data, /*BusinessData bdata,*/ IMapper mapper)
        /*public FacturesController(ILogger<FacturesController> logger, IBusinessData data)*/
        {
            _logger = logger;
            _data = data;
            this._mapper = mapper;
            /*this._bdata = bdata;*/
        }


        [HttpGet]
        public IEnumerable<ChiffreAffaire> Get()
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
            var cas = _data.CAs.ToList();

            return _data.CAs;

        }

        [HttpGet("{year}")]
        public ActionResult<ChiffreAffaire> Get(string year)
        {
            var ca = _data.CAs.Where(cas => cas.year == year).FirstOrDefault();
            if (ca != null)
            {
                /*var factureDTO = _mapper.Map<FactureDTO>(facture);*/
                /*var factureDTO = _mapper.Map<FactureDTO>(facture);
                return factureDTO;*/
                /*return Mapper.Map<FactureDTO>(facture);*/
                return ca;
            }
            else
                return NotFound();
        }

/*        [HttpPost]
        public ActionResult<FactureDTO> Post([FromBody] FactureDTO newFac)
        {
            // Créer un objet facture depuis le paramètre newFac en JSON
            *//*Facture newFac = new Facture();
            return newFac;*//*
            // _data.
            if (ModelState.IsValid)
            {
                //TODO : Ajouter la nouvelle facture à la collection
                _bdata.addFac(newFac);
                return Created($"factures/{newFac.code}", newFac);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }*/
    }
}
