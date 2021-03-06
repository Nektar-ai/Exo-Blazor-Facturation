﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        public CasController(ILogger<FacturesController> logger, IBusinessData data, IMapper mapper)
        {
            _logger = logger;
            _data = data;
            this._mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<ChiffreAffaire> Get()
        {
            return _data.CAs;
        }

        [HttpGet("{year}")]
        public ActionResult<ChiffreAffaire> Get(string year)
        {
            var ca = _data.CAs.Where(cas => cas.year == year).FirstOrDefault();
            if (ca != null)
            {
                return ca;
            }
            else
                return NotFound();
        }
    }
}
