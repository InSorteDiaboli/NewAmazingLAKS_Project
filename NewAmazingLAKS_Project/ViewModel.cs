using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NewAmazingLAKS_Project.Annotations;
using NewAmazingLAKS_Project.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NewAmazingLAKS_Project
{
    class ViewModel : INotifyPropertyChanged
    {
        private ICommand _removeCommand;
        private ICommand _loadCommand;
        private ICommand _saveCommand; 
        private Customer _selectedCustomer;
        private ICommand _addCustomerCommand;
        private ICommand _addOrderCommand;
        private ObservableCollection<Order> _orderList;
        private ICommand _goToOrderCommand;
        private ICommand _editCommand;

        private ICommand _goBackCommand;
        private ICommand _clearCustomerListCommand;
        private ICommand _addProductCommand;
        private ICommand _goToEditOrderCommand;
        private ICommand _addProdukttypeCommand;
        private ICommand _addFolieCommand;
        private ICommand _addLaminateCommand;
        private ICommand _removeStuffCommand;
        private ICommand _godkendCommand;
        private ICommand _removeProductCommand;
        private ICommand _goToNewProductCommand;

        #region Customer
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string Att { get; set; }
        public string Address { get; set; }
        public int PostalNo { get; set; }
        public string PhoneNo { get; set; }

        //private Customer CustomerToAddOrder
        //{
        //    get { return _customerToAddOrder; }
        //    set
        //    {
        //        _customerToAddOrder = value;
        //        if (CustomerToAddOrder != null)
        //        {
        //            Debug.WriteLine($"set customertoaddorder to {CustomerToAddOrder.CustomerName}");
        //        }

        //    }
        //} //Den kunde der skal tilføjes ordre til

        public CustomerCatalog CustomerList => CustomerCatalog.Instance; //set 

        public ObservableCollection<Order> OrderList
        {
            get
            {
                //if (SelectedCustomer != null)
                //{
                //    return SelectedCustomer.OrderList;
                //}
                return _orderList;
            }
            set
            {
                _orderList = value;
                Debug.WriteLine($"set orderlist to {SelectedCustomer.CustomerName}s {OrderList.Count} orders");
            }
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                if (SelectedCustomer != null)
                {
                    Debug.WriteLine($"set customer to {SelectedCustomer.CustomerName}");
                }
            }
        }

        #endregion

        #region Order

        
        public int OrderNo { get; set; }
        public string LevDate { get; set; }
        public int Blok { get; set; }
        public string FileDate { get; set; }
        public ObservableCollection<Product> ProductList { get; set; }

        public Order EmptyOrder { get; set; }
        //private Order _selectedOrder;

        //public Order SelectedOrder
        //{
        //    get { return _selectedOrder; }
        //    set
        //    {
        //        _selectedOrder = value;
        //        if (SelectedOrder != null)
        //        {
        //            Debug.WriteLine($"set order in viewmodel to no {SelectedOrder.OrderNo}");
        //        }
        //    }
        //}

        #endregion

        #region Product

        public string Productname { get; set; }
        public string Productsize { get; set; }
        public int Amount { get; set; }
        public string Media { get; set; }
        public string Folie { get; set; }
        public string Laminate { get; set; }
        public string Producttype { get; set; }
        public double Productprice { get; set; }
        public double Dtpprice { get; set; }
        public double Levprice { get; set; }
        public double Percent { get; set; }
        public int Levamount { get; set; }
        public bool Solv { get; set; }
        public bool SUV { get; set; }

        #endregion

        public ViewModel() //
        {
            _removeCommand = new RelayCommand(Remove);
            _saveCommand = new RelayCommand(Save);
            _addCustomerCommand = new RelayCommand(AddCustomer);
            _loadCommand = new RelayCommand(Load);
            _addOrderCommand = new RelayCommand(AddOrder);
            _goToOrderCommand = new RelayCommand(GoToOrder);
            _editCommand = new RelayCommand(Edit);
            _goBackCommand = new RelayCommand(GoBack);
            _clearCustomerListCommand = new RelayCommand(ClearCustomerList);
            _addProductCommand = new RelayCommand(AddProduct);
            _goToEditOrderCommand = new RelayCommand(GoToEditOrder);
            _addFolieCommand = new RelayCommand(AddFolie);
            _addProdukttypeCommand = new RelayCommand(AddType);
            _addLaminateCommand = new RelayCommand(AddLaminate);
            _removeStuffCommand = new RelayCommand(RemoveStuff);
            _removeProductCommand = new RelayCommand(RemoveProduct);
            _godkendCommand = new RelayCommand(Godkend);
            _goToNewProductCommand = new RelayCommand(GoToNewProduct);
            Order EmptyOrder;
        }

        public ICommand GodkendCommand
        {
            get { return _godkendCommand; }
            set { _godkendCommand = value; }
        }

        public ICommand RemoveCommand
        {
            get { return _removeCommand; }
            set { _removeCommand = value; }
        }

        public ICommand LoadCommand
        {
            get { return _loadCommand; }
            set { _loadCommand = value; }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
            set { _saveCommand = value; }
        }

        public ICommand AddCustomerCommand
        {
            get { return _addCustomerCommand; }
            set { _addCustomerCommand = value; }
        }

        public ICommand AddOrderCommand
        {
            get { return _addOrderCommand; }
            set { _addOrderCommand = value; }
        }
        public ICommand GoToOrderCommand
        {
            get { return _goToOrderCommand; }
            set { _goToOrderCommand = value; }
        }

        public ICommand EditCommand
        {
            get { return _editCommand; }
            set { _editCommand = value; }
        }

        public ICommand GoBackCommand
        {
            get { return _goBackCommand; }
            set { _goBackCommand = value; }
        }

        public ICommand ClearCustomerListCommand
        {
            get { return _clearCustomerListCommand; }
            set { _clearCustomerListCommand = value; }
        }

        public ICommand AddProductCommand
        {
            get { return _addProductCommand; }
            set { _addProductCommand = value; }
        }

        public ICommand GoToEditOrderCommand
        {
            get { return _goToEditOrderCommand; }
            set { _goToEditOrderCommand = value; }
        }

        public ICommand AddFolieCommand
        {
            get { return _addFolieCommand; }
            set { _addFolieCommand = value; }
        }
        public ICommand AddLaminateCommand
        {
            get { return _addLaminateCommand; }
            set { _addLaminateCommand = value; }
        }
        public ICommand AddProdukttypeCommand
        {
            get { return _addProdukttypeCommand; }
            set { _addProdukttypeCommand = value; }
        }

        public ICommand RemoveStuffCommand
        {
            get { return _removeStuffCommand; }
            set { _removeStuffCommand = value; }
        }

        public ICommand RemoveProductCommand
        {
            get { return _removeProductCommand; }
            set { _removeProductCommand = value; }
        }

        public ICommand GoToNewProductCommand 
        {
            get { return _goToNewProductCommand; }
            set { _goToNewProductCommand = value; }
        }


        public void GoBack()
        {
            var frame = (Frame) Window.Current.Content;
            frame.Navigate(typeof(NewAmazingLAKS_Project.MainPage));
            Save();
        }

        public void Showbox(string content, string title)
        {
            PersistencyService.MessageDialogHelper.Show(content, title);
        }


        public void Godkend()
        {
            try
            {
                if (SelectedCustomer.SelectedOrder.OrderStatus == "Ny Ordre")
                {
                    SelectedCustomer.SelectedOrder.OrderStatus = "Godkendt";
                }
                else if (SelectedCustomer.SelectedOrder.OrderStatus == "Godkendt")
                {
                    SelectedCustomer.SelectedOrder.OrderStatus = "Udført";
                }
                else if (SelectedCustomer.SelectedOrder.OrderStatus == "Udført")
                {
                    SelectedCustomer.SelectedOrder.OrderStatus = "Inaktiv";
                }
                else if (SelectedCustomer.SelectedOrder.OrderStatus == "Inaktiv")
                {
                    SelectedCustomer.SelectedOrder.OrderStatus = "Ny Ordre";
                }
                OnPropertyChanged();
                GoBack();
                Save();
            }
            catch (Exception e)
            {
                Showbox("No order selected", "Error");
            }

        }


        public void Edit()
        {
            try
            {
                if (SelectedCustomer.SelectedOrder != null)
                {
                    CustomerList.OrderToEdit = SelectedCustomer.SelectedOrder;
                    var frame = (Frame)Window.Current.Content;
                    frame.Navigate(typeof(NewAmazingLAKS_Project.EditOrder));
                }
                else if (SelectedCustomer != null)
                {
                    CustomerList.CustomerToEdit = SelectedCustomer;
                    var frame = (Frame)Window.Current.Content;
                    frame.Navigate(typeof(NewAmazingLAKS_Project.EditCustomer));
                }
                else
                {
                    Showbox("Du skal vælge en kunde eller odre at redigere", "Error");
                }
                OnPropertyChanged();
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e);
            }

        }

        public void ClearCustomerList()
        {
            CustomerList.CustomerList.Clear();
        }


        public void GoToOrder() //Hvis vi går direkte til ordre fra mainscreen sætter vi CustomerToAddOrder til SelectedCustomer
        {
            if (CustomerList.CustomerList.Count > 0 && SelectedCustomer != null)
            {
            CustomerList.CustomerToAddOrder = SelectedCustomer;
            OnPropertyChanged();
            CustomerList.OrderToEdit = EmptyOrder;
                GoToNewProduct();
            }
            else
            {
                Showbox("Du skal vælge eller oprette en kunde før du kan lave ordrer", "Error");
            }
        }

        public void GoToNewProduct()
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(NewAmazingLAKS_Project.AddOrder));
        }

        public void GoToEditOrder()
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(NewAmazingLAKS_Project.EditOrderProduct));
        }

        public void AddCustomer() //Når vi laver en kunde sætter vi CustomerToAddOrder til den seneste kunde vi har lavet, for at kunne oprette ordrer til den med det samme
        {
            if (string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(Address) || PostalNo == 0 &&
                string.IsNullOrEmpty(PhoneNo))
            {
                Showbox("Du skal skrive navn, adresse, postnummer og telefonnummer", "Error");
            }
            else
            {
                CustomerList.Add(new Customer(CustomerName, Att, Address, PostalNo, PhoneNo));
                OnPropertyChanged();
                Showbox("Kunde tilføjet", "Msg");
                CustomerList.CustomerToAddOrder = CustomerList.CustomerList[CustomerList.CustomerList.Count - 1];
                Save();
                var frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(NewAmazingLAKS_Project.AddOrder));
            }
            
        }

        public void AddOrder() //Vi tilføjer en ordre til CustomerToAddOrder.OrderList
        {
            if (CustomerList.CustomerToAddOrder != null)
            {
                
                Debug.WriteLine($"Trying to add order to {CustomerList.CustomerToAddOrder.CustomerName}");
                CustomerList.CustomerToAddOrder.OrderList.Add(new Order(LevDate, Blok, FileDate));
                OnPropertyChanged();
                Save();
                Showbox("Ordre tilføjet", "Besked");
                CustomerList.OrderToEdit =
                    CustomerList.CustomerToAddOrder.OrderList[CustomerList.CustomerToAddOrder.OrderList.Count - 1]; //Hvis vi laver en ordre skal vi kunne tilføje produkter til den med det samme
            }
            else
            {
                Showbox("Du skal vælge en kunde at tilføje ordren til", "Error");
            }

        }

        public void AddProduct()
        {
            try
            {
                if ((Productname != null || Productsize != null || Amount != 0) && CustomerList.OrderToEdit != null)
                {
                    CustomerList.OrderToEdit.ProductList.Add(new Product(Productname, Productsize, Amount, Media, Productprice, Levprice, Levamount, Percent, Dtpprice, Solv, SUV));
                    OnPropertyChanged();

                    Showbox("Produkt tilføjet", "Msg");
                    CustomerList.ProductToEdit =
                        CustomerList.OrderToEdit.ProductList[CustomerList.OrderToEdit.ProductList.Count - 1];
                    CustomerList.OrderToEdit.SelectedProduct = CustomerList.OrderToEdit.ProductList[CustomerList.OrderToEdit.ProductList.Count - 1];
                    if (Folie != null)
                    {
                        CustomerList.ProductToEdit.Folie.Add(Folie);
                    }
                    if (Laminate != null)
                    {
                        CustomerList.ProductToEdit.Laminate.Add(Laminate);
                    }
                    if (Producttype != null)
                    {
                        CustomerList.ProductToEdit.Producttype.Add(Producttype);
                    }
                    Save();
                    GoToEditOrder();
                }
                else
                {
                    Showbox("Noget gik galt med at tilføje produktet, har du en ordre valgt? Opret en ordre til venstre på siden","Error");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e + "stop h8");
            }

            
        }

        public void AddLaminate()
        {
            try
            {
                if (!string.IsNullOrEmpty(Laminate))
                {
                    Debug.WriteLine($"Adding Laminate {Laminate} to product {CustomerList.OrderToEdit.SelectedProduct.Productname}");
                    CustomerList.OrderToEdit.SelectedProduct.Laminate.Add(Laminate);
                    Save();
                }
                else
                {
                    Showbox("Du kan ikke tilføje laminering uden navn", "Error");
                }

            }
            catch (Exception e)
            {
                Showbox("Marker et produkt at tilføje til", "Msg");
            }


        }

        public void AddType()
        {
            try
            {
                if (!string.IsNullOrEmpty(Producttype))
                {
                    Debug.WriteLine(
                        $"Adding Producttype {Producttype} to product {CustomerList.OrderToEdit.SelectedProduct.Productname}");
                    CustomerList.OrderToEdit.SelectedProduct.Producttype.Add(Producttype);
                    Save();
                }
                else
                {
                    Showbox("Du kan ikke tilføje produkttype uden navn", "Error");
                }

            }
            catch (Exception e)
            {
                Showbox("Marker et produkt at tilføje til", "Msg");
            }
        }

        public void AddFolie()
        {
            try
            {
                if (!string.IsNullOrEmpty(Folie))
                {
                    Debug.WriteLine(
                        $"Adding Folie {Folie} to product {CustomerList.OrderToEdit.SelectedProduct.Productname}");

                    CustomerList.OrderToEdit.SelectedProduct.Folie.Add(Folie);
                    Save();
                }
                else
                {
                    Showbox("Du kan ikke tilføje folie uden navn", "Error");
                }
            }
            catch (Exception e)
            {
                Showbox("Marker et produkt at tilføje til", "Msg");
            }
            
        }

        public async void Save()
        {
            PersistencyService.SaveKundeListeAsJsonAsync(CustomerList.CustomerList);
        }

        public async void Load()
        {
            var orders = await PersistencyService.LoadKundeListeFromJsonAsync();
            OrderList.Clear();
            foreach (var order in orders)
            {
                orders.Add(order);
            }
        }

        public async void Remove()
        {
            try
            {

                if (SelectedCustomer.SelectedOrder != null && SelectedCustomer != null /*&& SelectedCustomer.SelectedOrder.OrderNo != -1*/ && CustomerList.OrderToEdit != null)
                {
                    Debug.WriteLine("removing order");
                    SelectedCustomer.OrderList.Remove(SelectedCustomer.SelectedOrder);
                    CustomerList.OrderToEdit = EmptyOrder;
                }
                else if (SelectedCustomer != null)
                {
                    Debug.WriteLine("removing customer");
                    CustomerList.Remove(SelectedCustomer);
                    CustomerList.OrderToEdit = EmptyOrder;
                }
                else
                {
                    Showbox("Du skal vælge en kunde eller ordre at slette", "Error");
                }
                Save();
            }
            catch (System.NullReferenceException e)
            {
                Debug.WriteLine(e);
            }

        }

        public void RemoveProduct()
        {
            try
            {
                if (CustomerList.OrderToEdit.SelectedProduct != null)
                {
                    CustomerList.OrderToEdit.ProductList.Remove(CustomerList.OrderToEdit.SelectedProduct);
                }
                else
                {
                    Showbox("Du skal vælge et produkt at slette", "Error");
                }
                Save();
            }
            catch (Exception e)
            {
                Debug.WriteLine("DET KAN DU IKKE MOTHERFUCKER");
            }
        }

        public void RemoveStuff()
        {
            try
            {
                if (CustomerList.OrderToEdit.SelectedProduct.SelectedFolie != null)
                {
                    Debug.WriteLine("Removing Folie");
                    CustomerList.OrderToEdit.SelectedProduct.Folie.Remove(CustomerList.OrderToEdit.SelectedProduct
                        .SelectedFolie);
                    Save();
                }
                else if (CustomerList.OrderToEdit.SelectedProduct.SelectedLaminate != null)
                {
                    Debug.WriteLine("Removing laminate");

                    CustomerList.OrderToEdit.SelectedProduct.Laminate.Remove(CustomerList.OrderToEdit.SelectedProduct
                        .SelectedLaminate);
                    Save();
                }
                else if (CustomerList.OrderToEdit.SelectedProduct.SelectedType != null)
                {
                    Debug.WriteLine("Removing type");

                    CustomerList.OrderToEdit.SelectedProduct.Producttype.Remove(CustomerList.OrderToEdit.SelectedProduct
                        .SelectedType);
                    Save();
                }
                else
                {
                    Showbox("Du skal vælge noget at slette", "Error");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("DET KAN DU IKKE MOTHERFUCKER");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
