﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TuristickaAgencija.WebAPI.Database
{
    public partial class Obavijesti
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public int? KorisnikId { get; set; }
        public DateTime Datum { get; set; }

        public virtual Korisnici Korisnik { get; set; }
    }
}
