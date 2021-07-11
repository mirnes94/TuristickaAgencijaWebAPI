using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Request;
using TuristickaAgencija.WebAPI.Services.Putovanja;

namespace TuristickaAgencija.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PutovanjaController : ControllerBase
    {
        private readonly IPutovanjaService _putovanjaService;
        public PutovanjaController(IPutovanjaService putovanjaService)
        {
            _putovanjaService = putovanjaService;
        }
        
        [HttpGet]
        public virtual IList<Model.Putovanja> Get([FromQuery] PutovanjaSearchRequest request)
        {
            return _putovanjaService.Get(request);

        }
        /*
        public ActionResult<List<Model.Putovanja>> Get([FromQuery]PutovanjaSearchRequest request)
        {
            return _putovanjaService.Get(request);

        }*/


        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public Model.Putovanja GetById(int id)
        {
            return _putovanjaService.GetById(id);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public Model.Putovanja Insert(PutovanjaInsertUpdateRequest request)
        {
            return _putovanjaService.Insert(request);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public Model.Putovanja Update(int id, PutovanjaInsertUpdateRequest request)
        {
            return _putovanjaService.Update(id, request);
        }
    }
}
