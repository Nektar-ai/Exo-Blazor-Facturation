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
        private readonly IMapper _mapper;
        public FacturesController(ILogger<FacturesController> logger, IBusinessData data, IMapper mapper)        
        {
            this._logger = logger;
            this._data = data;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Facture> Get()        
        {
            return _data.Factures;
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
                Console.WriteLine("FACTURE RECUE DANS CONTROLLER");
                this._data.addFac(newFac);
                return Created($"factures/{newFac.code}", newFac);
            } else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}
