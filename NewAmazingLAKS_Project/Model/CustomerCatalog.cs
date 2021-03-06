﻿using System;
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
        private Customer _customerToAddOrder;
        public Customer CustomerToAddOrder
        {
            get { return _customerToAddOrder; }
            set
            {
                _customerToAddOrder = value;
                if (CustomerToAddOrder != null)
                {
                    Debug.WriteLine($"set customertoaddorder to {CustomerToAddOrder.CustomerName}");
                    if (OrderToEdit == null && CustomerToAddOrder.OrderList.Count > 0)
                    {
                        OrderToEdit = CustomerToAddOrder.OrderList[CustomerToAddOrder.OrderList.Count - 1];
                        Debug.WriteLine($"Set Order to Edit to {OrderToEdit}");
                    }
                }

            }
        } //Den kunde der skal tilføjes ordre til

        private Order _orderToEdit;
        public Order OrderToEdit
        {
            get { return _orderToEdit; }
            set
            {
                _orderToEdit = value;
                if (OrderToEdit != null)
                {
                    Debug.WriteLine($"set order to edit to order number {OrderToEdit.OrderNo}");
                }

            }
        } //Den ordre der skal redigeres

        private Customer _customerToEdit;
        public Customer CustomerToEdit
        {
            get { return _customerToEdit; }
            set
            {
                _customerToEdit = value;
                if (CustomerToEdit != null)
                {
                    Debug.WriteLine($"set customer to edit to {CustomerToEdit.CustomerName}");
                }

            }
        } //Den kunde der skal redigeres

        private Product _productToEdit;
        private int _customerCounter;

        public Product ProductToEdit
        {
            get { return _productToEdit; }
            set
            {
                _productToEdit = value;
                if (ProductToEdit != null)
                {
                    Debug.WriteLine($"set product to edit to {ProductToEdit.Productname}");
                }

            }
        } //Den kunde der skal redigeres

        public string TargetPage { get; set; }

        public int CustomerCounter
        {
            get { return _customerCounter; }
            set { _customerCounter = value; }
        }


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
                    CustomerList.Add(new Customer("kundenavn", "att", "address", "4000", "tlfnr", "cvr"));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong with the load");
                //CustomerList.Add(new Customer("2", "Eksamen", "lokale 122", 12, "Eksamen 1. semester"));
            }

        }


        public void Add(Customer newCustomer)
        {
            CustomerList.Add(newCustomer);
            PersistencyService.SaveKundeListeAsJsonAsync(CustomerList);
        }

        public void Add(string name, string att, string address, string postalNo, string phoneNo, string cvr)
        {
            CustomerList.Add(new Customer(name, att, address, postalNo, phoneNo, cvr));
            PersistencyService.SaveKundeListeAsJsonAsync(CustomerList);
        }

        public void Remove(Customer customerToBeRemoved)
        {
            CustomerList.Remove(customerToBeRemoved);
            PersistencyService.SaveKundeListeAsJsonAsync(CustomerList);
        }
    }
}
