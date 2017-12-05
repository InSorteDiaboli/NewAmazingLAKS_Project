using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAmazingLAKS_Project.Model
{
    class Product
    {
        #region PRODUCT

        public string Productname { get; set; }
        public double Productsize { get; set; }
        public int Amount { get; set; }
        public string Media { get; set; }
        public string Folie { get; set; }
        public string Laminate { get; set; }
        public string Producttype { get; set; }
        public double Productprice { get; set; }
        public double Levprice { get; set; }
        public int Levamount { get; set; }
        public double Procent { get; set; }

        #endregion

        #region CONSTRUCTOR

        public Product(string productname, double productsize, int amount, string media, string folie, string laminate, string producttype, double productprice, double levprice, int levamount, double procent)
        {
            Productname = productname;
            Productsize = productsize;
            Amount = amount;
            Media = media;
            Folie = folie;
            Laminate = laminate;
            Producttype = producttype;
            Productprice = productprice;
            Levprice = levprice;
            Levamount = levamount;
            Procent = Productprice + (Productprice/100*procent);
        }

        #endregion
    }
}
