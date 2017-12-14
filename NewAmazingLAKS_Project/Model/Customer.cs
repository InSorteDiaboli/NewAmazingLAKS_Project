using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        public string PostalNo { get; set; }
        public string PhoneNo { get; set; }
        private static int _count;
        public string CVR { get; set; }
        private Order _selectedOrder;

        public Order SelectedOrder
        {   
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                if (SelectedOrder != null)
                { 
                Debug.WriteLine($"set order in selectcustomer to no {SelectedOrder.OrderNo}");
                }
            }
        }


        public ObservableCollection<Order> OrderList { get; set; }

        public Customer(string kundenavn, string att, string adresse, string postnummer, string tlfnr, string cvr)
        {
            
            CustomerNo = _count++ +1;
            CustomerName = kundenavn;
            Att = att;
            Address = adresse;
            PostalNo = postnummer;
            PhoneNo = tlfnr;
            OrderList = new ObservableCollection<Order>();
            CVR = cvr;

        }

        //public override string ToString()
        //{
        //    return "Navn: " + CustomerName + " ATT: " + Att + " Adresse: " + Address + " Postnummer: " + PostalNo +
        //           " Telefon: " + PhoneNo;
        //}
    }
}
