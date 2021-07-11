﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Request;
using TuristickaAgencija.WebAPI.Services.Obavijesti;

namespace TuristickaAgencija.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObavijestiController : ControllerBase
    {
        private readonly IObavijestiService _obavijestiService;
        public ObavijestiController(IObavijestiService obavijestiService)
        {
            _obavijestiService = obavijestiService;
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<Model.Obavijesti>> Get([FromQuery] ObavijestiSearchRequest request)
        {
            return _obavijestiService.Get(request);

        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public Model.Obavijesti GetById(int id)
        {
            return _obavijestiService.GetById(id);

        }

        [HttpPost]
        public Model.Obavijesti Insert(ObavijestiInsertUpdateRequest request)
        {
            return _obavijestiService.Insert(request);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public Model.Obavijesti Update(int id, ObavijestiInsertUpdateRequest request)
        {
            return _obavijestiService.Update(id, request);
        }
    }
}
