using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAmazingLAKS_Project.Model
{
    class Customer
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string Att { get; set; }
        public string Address { get; set; }
        public int PostalNo { get; set; }
        public string PhoneNo { get; set; }
        private static int _count;

        public ObservableCollection<Order> OrderList { get; set; }

        public Customer(string kundenavn, string att, string adresse, int postnummer, string tlfnr)
        {
            CustomerNo = _count++;
            CustomerName = kundenavn;
            Att = att;
            Address = adresse;
            PostalNo = postnummer;
            PhoneNo = tlfnr;
            OrderList = new ObservableCollection<Order>();
            OrderList.Add(new Order("20/8/2016", 5, "1/1/2017")); //Dummydata
            OrderList.Add(new Order("20/8/2016", 5, "1/1/2017"));
        }

        public override string ToString()
        {
            return "Navn: " + CustomerName + " ATT: " + Att + " Adresse: " + Address + " Postnummer: " + PostalNo +
                   " Telefon: " + PhoneNo;
        }
    }
}
