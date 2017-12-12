using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAmazingLAKS_Project.Model
{
    class Order
    {
        #region Properties

        #region Order

        private static int _count;

        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string LevDate { get; set; }
        public int Blok { get; set; }
        public string FileDate { get; set; }
        public string OrderStatus { get; set; }
        public ObservableCollection<Product> ProductList { get; set; }
        #endregion


        #endregion

        #region Constructor

        public Order(string levDate, int blok, string fileDate)
        {
            OrderNo = _count++;
            OrderDate = DateTime.Now;
            LevDate = levDate;
            Blok = blok;
            FileDate = fileDate;
            ProductList = new ObservableCollection<Product>();
            OrderStatus = "Ny Ordre";
        }
        #endregion

        public override string ToString() // Redundant tostring metode, vi bruger jo t3mpl4t3z
        {
            return "Ordrenr: " + OrderNo + " Ordredato: " + OrderDate + " Leveringsdato: " + LevDate + " Blok: " + Blok + " Dato for fil: " + FileDate;
        }
    }
}
