﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Request;
using TuristickaAgencija.WebAPI.Services.ListaZelja;

namespace TuristickaAgencija.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaZeljaController : ControllerBase
    {
        private readonly IListaZeljaService _listaZeljaService;
        public ListaZeljaController(IListaZeljaService listaZeljaService)
        {
            _listaZeljaService = listaZeljaService;
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<Model.ListaZelja>> Get([FromQuery] ListaZeljaSearchRequest request)
        {
            return _listaZeljaService.Get(request);

        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public Model.ListaZelja GetById(int id)
        {
            return _listaZeljaService.GetById(id);

        }

        [HttpPost]
        public Model.ListaZelja Insert(ListaZeljaInsertUpdateRequest request)
        {
            return _listaZeljaService.Insert(request);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public Model.ListaZelja Update(int id, ListaZeljaInsertUpdateRequest request)
        {
            return _listaZeljaService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _listaZeljaService.Delete(id);
        }
    }
}
