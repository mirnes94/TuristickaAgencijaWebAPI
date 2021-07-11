using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Request;
using TuristickaAgencija.WebAPI.Services.Korisnici;

namespace TuristickaAgencija.WebAPI.Controllers
{
   //[Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _korisniciService;
        public KorisniciController(IKorisniciService korisniciService)
        {
            _korisniciService = korisniciService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public List<Model.Korisnici> Get([FromQuery]KorisniciSearchRequest request)
        {
            return _korisniciService.Get(request);

        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public Model.Korisnici GetById(int id)
        {
            return _korisniciService.GetById(id);

        }

        //[Authorize(Roles="Admin")]
        [HttpPost]
        public Model.Korisnici Insert(KorisniciInsertUpdateRequest request)
        {
            return _korisniciService.Insert(request);
        }
        //[Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public Model.Korisnici Update(int id, KorisniciInsertUpdateRequest request)
        {
            return _korisniciService.Update(id, request);
        }
        [HttpGet]
        [Route("Authenticiraj/{username},{password}")]
        public Model.Korisnici Authenticiraj(string username, string password)
        {
            return _korisniciService.Authenticiraj(username, password);
        }


    }
}
