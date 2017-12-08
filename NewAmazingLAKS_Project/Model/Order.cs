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
        public bool OrderStatus { get; set; }
        public ObservableCollection<Product> ProductList { get; set; }

        public Product SelectedProduct { get; set; }
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
            ProductList.Add(new Product("Test123", 1.23, 5, "Salt", "Folie", "", "Type", 123.4, 49, 10, 5));
            ProductList.Add(new Product("Test12333", 13.23, 53, "aaa", "Folie2", "", "Type3", 1234.4, 49, 10, 5));
        }
        #endregion

        public override string ToString() // Redundant tostring metode, vi bruger jo t3mpl4t3z
        {
            return "Ordrenr: " + OrderNo + " Ordredato: " + OrderDate + " Leveringsdato: " + LevDate + " Blok: " + Blok + " Dato for fil: " + FileDate;
        }
    }
}
