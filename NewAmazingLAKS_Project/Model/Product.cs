using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAmazingLAKS_Project.Model
{
    class Product
    {
        #region PRODUKTET

        public string Produktnavn { get; set; }
        public double Produktmaal { get; set; }
        public int Antal { get; set; }
        public string Medie { get; set; }
        public string Folie { get; set; }
        public string Laminering { get; set; }
        public string Produkttype { get; set; }
        public double Produktpris { get; set; }
        public double Fragtpris { get; set; }
        public int Levantal { get; set; }
        public int Procent { get; set; }

        #endregion

        #region KONSTRUKTØR

        public Product(string produktnavn, double produktmaal, int antal, string medie, string folie, string laminering, string produkttype, double produktpris, double fragtpris, int levantal, int procent)
        {
            Produktnavn = produktnavn;
            Produktmaal = produktmaal;
            Antal = antal;
            Medie = medie;
            Folie = folie;
            Laminering = laminering;
            Procent = procent;
            Produkttype = produkttype;
            Produktpris = produktpris + (produktpris / 100 * procent);
            Fragtpris = fragtpris;
            Levantal = levantal;
        }

        #endregion
    }
}
