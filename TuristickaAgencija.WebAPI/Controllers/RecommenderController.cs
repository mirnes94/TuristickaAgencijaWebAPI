using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.WebAPI.Services.RecommenderService;

namespace TuristickaAgencija.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommenderController : ControllerBase
    {
        private readonly IRecommenderService _service;

        public RecommenderController(IRecommenderService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetRecommendedPutovanja/{korisnikId}")]
        public List<Model.Putovanja> GetRecommendedPutovanja(int korisnikId)
        {
            return _service.GetRecommendedPutovanja(korisnikId);
        }
    }
}
