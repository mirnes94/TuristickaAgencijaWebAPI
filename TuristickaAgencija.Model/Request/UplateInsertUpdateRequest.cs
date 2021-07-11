using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Model.Request
{
    public class UplateInsertUpdateRequest
    {
        public DateTime DatumUplate { get; set; }
        public double Iznos { get; set; }
        public int RezervacijaId { get; set; }
    }
}
