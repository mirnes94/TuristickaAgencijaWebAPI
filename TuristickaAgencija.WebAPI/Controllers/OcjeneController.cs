﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Request;
using TuristickaAgencija.WebAPI.Services.Ocjene;

namespace TuristickaAgencija.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcjeneController : ControllerBase
    {
        private readonly IOcjeneService _ocjeneService;
        public OcjeneController(IOcjeneService ocjeneService)
        {
            _ocjeneService = ocjeneService;
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<Model.Ocjene>> Get([FromQuery] OcjeneSearchRequest request)
        {
            return _ocjeneService.Get(request);

        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public Model.Ocjene GetById(int id)
        {
            return _ocjeneService.GetById(id);

        }

        [HttpPost]
        public Model.Ocjene Insert(OcjeneInsertUpdateRequest request)
        {
            return _ocjeneService.Insert(request);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public Model.Ocjene Update(int id, OcjeneInsertUpdateRequest request)
        {
            return _ocjeneService.Update(id, request);
        }
    }
}
