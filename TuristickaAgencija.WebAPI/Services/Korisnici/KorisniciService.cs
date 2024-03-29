﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Request;
using TuristickaAgencija.WebAPI.Database;

namespace TuristickaAgencija.WebAPI.Services.Korisnici
{
  
    public class KorisniciService : IKorisniciService
    {
        private readonly TuristickaAgencijaContext _context;
        private readonly IMapper _mapper;
        public KorisniciService(TuristickaAgencijaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        public string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }



        public string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);

        }

        public List<Model.Korisnici> Get(KorisniciSearchRequest request)
        {
            var query = _context.Korisnici.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }


            var list = query.ToList();

           

            return _mapper.Map<List<Model.Korisnici>>(list);
        }

        public Model.Korisnici GetById(int id)
        {
            var entity = _context.Korisnici.Find(id);

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Insert(KorisniciInsertUpdateRequest request)
        {
            var entity = _mapper.Map<Database.Korisnici>(request);

            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt,request.Password);
          
            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                korisniciUloge.KorisnikId = entity.Id;
                korisniciUloge.UlogaId = uloga;
                korisniciUloge.DatumIzmjene = DateTime.Now;
                _context.KorisniciUloge.Add(korisniciUloge);
            }
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Update(int id, KorisniciInsertUpdateRequest request)
        {
            
            var entity = _context.Korisnici.Find(id);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new Exception("Passwordi se ne slažu");
                }
            }

            foreach (var uloga in request.Uloge)
            {
                _context.KorisniciUloge.Add(new Database.KorisniciUloge()
                {
                    KorisnikId = entity.Id,
                    UlogaId = uloga,
                    DatumIzmjene = DateTime.Now,
            });
            }
            _context.Korisnici.Attach(entity);
            _context.Korisnici.Update(entity);

            _mapper.Map(request, entity);

          
           
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Authenticiraj(string username, string password)
        {
            var user = _context.Korisnici.Include(x=>x.KorisniciUloge).ThenInclude(x=>x.Uloga).FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, password);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Korisnici>(user);
                }
            }
            return null;
        }

        public Model.Korisnici Potvrdi(string username)
        {
            var user = _context.Korisnici.Include(x => x.KorisniciUloge).ThenInclude(x => x.Uloga).FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                    user.Status = true;
                _context.SaveChanges(); 
                    return _mapper.Map<Model.Korisnici>(user);
                    
            }
            return null;
        }
        public List<Model.Korisnici> GetAllUsers()
        {
            var list = _context.Korisnici.ToList();

            return _mapper.Map<List<Model.Korisnici>>(list);
        }
        public void Delete(int id)
        {
            var entity = _context.Korisnici.Find(id);
            _context.Korisnici.Remove(entity);
            _context.SaveChanges();
        }
    }
}
