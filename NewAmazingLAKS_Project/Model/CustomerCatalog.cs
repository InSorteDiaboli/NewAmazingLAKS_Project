using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewAmazingLAKS_Project.Model
{
    class CustomerCatalog //Singleton
    {
        private static CustomerCatalog _instance = new CustomerCatalog();

        public static CustomerCatalog Instance
        {
            //get
            //{
            //    if (_instance == null)
            //        _instance = new EventCatalogSingleton();
            //    return _instance;
            //}

            get { return _instance ?? (_instance = new CustomerCatalog()); }

        }

        public ObservableCollection<Customer> CustomerList { get; set; }

        private CustomerCatalog()
        {
            CustomerList = new ObservableCollection<Customer>();
            LoadCustomersAsync();
        }



        public async void LoadCustomersAsync()
        {
            try
            {
                var events = await PersistencyService.LoadKundeListeFromJsonAsync();
                if (events != null)
                    foreach (var ev in events)
                    {
                        CustomerList.Add(ev);
                    }
                else
                {
                    //Data til testformål
                    CustomerList.Add(new Customer("1", "Pitching 2end semester Projects", "Auditorium 202", 12,
                        "De studerende fremlægger deres eksamensprojekt"));
                    CustomerList.Add(new Customer("2", "Eksamen", "lokale 122", 12, "Eksamen 1. semester"));
                }
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Debug.WriteLine("Something went wrong with the load");
                CustomerList.Add(new Customer("2", "Eksamen", "lokale 122", 12, "Eksamen 1. semester"));
            }

        }



        public void Add(Customer newCustomer)
        {
            CustomerList.Add(newCustomer);
            PersistencyService.SaveKundeListeAsJsonAsync(CustomerList);
        }

        public void Add(string name, string att, string address, int postalNo, string phoneNo)
        {
            CustomerList.Add(new Customer(name, att, address, postalNo, phoneNo));
            PersistencyService.SaveKundeListeAsJsonAsync(CustomerList);
        }

        public void Remove(Customer customerToBeRemoved)
        {
            CustomerList.Remove(customerToBeRemoved);
            PersistencyService.SaveKundeListeAsJsonAsync(CustomerList);
        }
    }
}
