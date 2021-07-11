using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.WebAPI.Database;

namespace TuristickaAgencija.WebAPI.Services.RecommenderService
{
    public class RecommenderService : IRecommenderService
    {
        Dictionary<int, List<Model.Ocjene>> korisnici = new Dictionary<int, List<Model.Ocjene>>();
        private readonly TuristickaAgencijaContext _context;
        private readonly IMapper _mapper;
        public RecommenderService(TuristickaAgencijaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }




        public List<Model.Putovanja> GetRecommendedPutovanja(int korisnikId)
        {
            LoadPutovanja(korisnikId);
            List<Model.Ocjene> OcjenePutovanja = new List<Model.Ocjene>();
            List<Database.Ocjene> zabiljezeneOcjene = _context.Ocjene.Where(x => x.KorisnikId == korisnikId).OrderBy(x => x.PutovanjeId).ToList();
            _mapper.Map(zabiljezeneOcjene, OcjenePutovanja);

            List<Model.Ocjene> OcjenePutovanja1 = new List<Model.Ocjene>();
            List<Model.Ocjene> OcjenePutovanja2 = new List<Model.Ocjene>();
            List<Model.Putovanja> preporucenaPutovanja = new List<Model.Putovanja>();

            foreach (var item in korisnici)
            {
                foreach (Model.Ocjene r in OcjenePutovanja)
                {
                    if (item.Value.Where(x => x.PutovanjeId == r.PutovanjeId).Count() > 0)
                    {
                        OcjenePutovanja1.Add(r);
                        OcjenePutovanja2.Add(item.Value.Where(x => x.PutovanjeId == r.PutovanjeId).First());
                    }
                }
                double slicnost = 0;
                slicnost = GetSlicni(OcjenePutovanja1, OcjenePutovanja2);





                if (slicnost > 0.89)
                {
                    var ocjene = _context.Ocjene.Where(x => x.KorisnikId == item.Key).ToList();
                    var putovanje1 = new Database.Putovanja();
                    foreach (var o in ocjene)
                    {
                        putovanje1 = _context.Putovanja
                            .Include(p=>p.Grad)
                            .Include(p => p.Prevoz)
                            .Include(p => p.Smjestaj)
                            .Include(p => p.VodiciPutovanja)
                            .Where(x => x.Id == o.PutovanjeId)
                            .FirstOrDefault();

                        Model.Putovanja putovanje2 = new Model.Putovanja();

                        putovanje2.BrojMjesta = putovanje1.BrojMjesta;
                        putovanje2.CijenaPutovanja = putovanje1.CijenaPutovanja;
                        putovanje2.DatumDolaska = putovanje1.DatumDolaska;
                        putovanje2.DatumPolaska = putovanje1.DatumPolaska;
                        putovanje2.GradId = (int)putovanje1.GradId;
                        putovanje2.Id = putovanje1.Id;
                        putovanje2.NazivPutovanja = putovanje1.NazivPutovanja;
                        putovanje2.OpisPutovanja = putovanje1.OpisPutovanja;
                        putovanje2.PrevozId = (int)putovanje1.PrevozId;
                        putovanje2.Slika = putovanje1.Slika;
                        putovanje2.SmjestajId = (int)putovanje1.SmjestajId;
                        //putovanje2.VodiciPutovanja = (ICollection<Model.VodiciPutovanja>)putovanje1.VodiciPutovanja;


                        preporucenaPutovanja.Add(putovanje2);
                    }





                }
                OcjenePutovanja1.Clear();
                OcjenePutovanja2.Clear();
            }


            return preporucenaPutovanja;
        }



        private double GetSlicni(List<Model.Ocjene> ocjenePutovanja1, List<Model.Ocjene> ocjenePutovanja2)
        {
            if (ocjenePutovanja1.Count != ocjenePutovanja2.Count)
                return 0;

            double num1 = 0, num2 = 0, num3 = 0;

            for (int i = 0; i < ocjenePutovanja1.Count; i++)
            {
                num1 += ocjenePutovanja1[i].Ocjena * ocjenePutovanja2[i].Ocjena;
                num2 += ocjenePutovanja1[i].Ocjena * ocjenePutovanja1[i].Ocjena;
                num3 += ocjenePutovanja2[i].Ocjena * ocjenePutovanja2[i].Ocjena;
            }

            num2 = Math.Sqrt(num2);
            num3 = Math.Sqrt(num3);
            double number = num2 * num3;
            if (number == 0)
                return 0;
            return num1 / number;
        }



        private void LoadPutovanja(int korisnikId)
        {
            var ocjene = _context.Ocjene.Where(x => x.KorisnikId == korisnikId).ToList();
            List<Database.Putovanja> aktivnaPutovanja = new List<Database.Putovanja>();
            foreach (var o in ocjene)
            {
                aktivnaPutovanja = _context.Putovanja.Where(x => x.Id != o.PutovanjeId).ToList();
                Database.Putovanja zabiljezenoPutovanje = _context.Putovanja.Where(x => x.Id == o.PutovanjeId).SingleOrDefault();
            }



            List<Model.Putovanja> novalista = new List<Model.Putovanja>();
            _mapper.Map(aktivnaPutovanja, novalista);



            foreach (Model.Putovanja a in novalista)
            {
                List<Database.Ocjene> listaocjena = _context.Ocjene.Where(x => x.PutovanjeId == a.Id).ToList();
                List<Model.Ocjene> modelocjena = new List<Model.Ocjene>();
                foreach (var item in listaocjena)
                {
                    Model.Ocjene novaocjena = new Model.Ocjene();
                    novaocjena.Datum = item.Datum;
                    novaocjena.Id = item.Id;
                    novaocjena.KorisnikId = item.KorisnikId;
                    novaocjena.Ocjena = item.Ocjena;
                    novaocjena.PutovanjeId = item.PutovanjeId;
                    modelocjena.Add(novaocjena);
                }
                if (modelocjena.Count > 0)
                    korisnici.Add(a.Id, modelocjena);
            }
        
        }
    }
}
