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
        private ICommand _saveCommand; //Testcomment
        //private Order _selectedOrder;
        private Customer _selectedCustomer;
        private ICommand _addCustomerCommand;
        private ICommand _addOrderCommand;
        private ObservableCollection<Order> _orderList;
        private ICommand _goToOrderCommand;
        //private Customer _customerToAddOrder;
        private ICommand _editCommand;

        private ICommand _goBackCommand;
        private ICommand _clearCustomerListCommand;
        private ICommand _addProductCommand;


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
        public double Productsize { get; set; }
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

        #endregion

        //public Order SelectedOrder
        //{
        //    get { return _selectedOrder; }
        //    set
        //    {
        //        _selectedOrder = value;
        //        Debug.WriteLine($"set order to no {SelectedOrder.OrderNo}");
        //    }
        //}
        public ViewModel() //
        {
            _removeCommand = new RelayCommand(Remove);
            _addCustomerCommand = new RelayCommand(AddCustomer);
            _loadCommand = new RelayCommand(Load);
            _addOrderCommand = new RelayCommand(AddOrder);
            _goToOrderCommand = new RelayCommand(GoToOrder);
            _editCommand = new RelayCommand(Edit);
            _goBackCommand = new RelayCommand(GoBack);
            _clearCustomerListCommand = new RelayCommand(ClearCustomerList);
            _addProductCommand = new RelayCommand(AddProduct);
            //_saveCommand = new RelayCommand(Save);
            //CustomerList.Add("name", "att", "adr", 4000, "tlf"); //Testdata
            //foreach (var customer in CustomerList.CustomerList) //is this right??? ved ikke om det her er den rigtige måde at benytte OrderList proppen, for vi har den jo også i Customer-klassen
            //{
            //    //customer.OrderList.Add(new Order("some date", 4, "filedate"));
            //    OrderList = customer.OrderList;
            //}
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

        public void GoBack()
        {
            var frame = (Frame) Window.Current.Content;
            frame.Navigate(typeof(NewAmazingLAKS_Project.MainPage));
        }


        public void Edit()
        {
            try
            {
                if (SelectedCustomer.SelectedOrder != null)
                {
                    //CustomerList.TargetPage = "NewAmazingLAKS_Project.EditOrder";
                    //Debug.WriteLine($"Target Page set to {CustomerList.TargetPage}");
                    CustomerList.OrderToEdit = SelectedCustomer.SelectedOrder;
                    var frame = (Frame)Window.Current.Content;
                    frame.Navigate(typeof(NewAmazingLAKS_Project.EditOrder));
                }
                else if (SelectedCustomer != null)
                {
                    //CustomerList.TargetPage = "NewAmazingLAKS_Project.EditCustomer";
                    //Debug.WriteLine($"Target Page set to {CustomerList.TargetPage}");
                    CustomerList.CustomerToEdit = SelectedCustomer;
                    var frame = (Frame)Window.Current.Content;
                    frame.Navigate(typeof(NewAmazingLAKS_Project.EditCustomer));
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
            CustomerList.CustomerToAddOrder = SelectedCustomer;
            OnPropertyChanged();
        }

        public void AddCustomer() //Når vi laver en kunde sætter vi CustomerToAddOrder til den seneste kunde vi har lavet, for at kunne oprette ordrer til den med det samme
        {
            if (string.IsNullOrEmpty(CustomerName) && string.IsNullOrEmpty(Address) && PostalNo == 0 &&
                string.IsNullOrEmpty(PhoneNo))
            {
                PersistencyService.MessageDialogHelper.Show("Du skal skrive navn, adresse, postnummer og telefonnummer", "Error");
            }
            else
            {
                CustomerList.Add(new Customer(CustomerName, Att, Address, PostalNo, PhoneNo));
                OnPropertyChanged();
                PersistencyService.MessageDialogHelper.Show("Kunde tilføjet", "Msg");
                CustomerList.CustomerToAddOrder = CustomerList.CustomerList[CustomerList.CustomerList.Count - 1];
                PersistencyService.SaveKundeListeAsJsonAsync(CustomerList.CustomerList);
            }
            
        }

        public void AddOrder() //Vi tilføjer en ordre til CustomerToAddOrder.OrderList
        {
            if (CustomerList.CustomerToAddOrder != null)
            {
                
                Debug.WriteLine($"Trying to add order to {CustomerList.CustomerToAddOrder.CustomerName}");
                CustomerList.CustomerToAddOrder.OrderList.Add(new Order(LevDate, Blok, FileDate));
                OnPropertyChanged();
                PersistencyService.SaveKundeListeAsJsonAsync(CustomerList.CustomerList);
                PersistencyService.MessageDialogHelper.Show("Ordre tilføjet", "Besked");
                CustomerList.OrderToEdit =
                    CustomerList.CustomerToAddOrder.OrderList[CustomerList.CustomerToAddOrder.OrderList.Count - 1]; //Hvis vi laver en ordre skal vi kunne tilføje produkter til den med det samme
            }
            else
            {
                Debug.WriteLine("Ordren skal tilføjes til en kunde");
            }

        }

        public void AddProduct()
        {
            if (string.IsNullOrEmpty(Productname) && Productsize == 0 && Amount == 0 && string.IsNullOrEmpty(Media) && string.IsNullOrEmpty(Folie) && string.IsNullOrEmpty(Laminate) && string.IsNullOrEmpty(Producttype))
            {
                PersistencyService.MessageDialogHelper.Show("Du skal skrive produktnavn, produktstørrelse, medie, folie, laminering og produkttype", "Error");
            }
            else
            {
                CustomerList.OrderToEdit.ProductList.Add(new Product(Productname, Productsize, Amount, Media, Folie,
                    Laminate, Producttype, Productprice, Levprice, Levamount, Percent));
                OnPropertyChanged();
                PersistencyService.SaveKundeListeAsJsonAsync(CustomerList.CustomerList);
                PersistencyService.MessageDialogHelper.Show("Produkt tilføjet", "Msg");
            }
            
        }

        //public async void Save()
        //{
        //    PersistencyService.SaveKundeListeAsJsonAsync();
        //}

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
                if (SelectedCustomer.SelectedOrder != null && SelectedCustomer != null)
                {
                    Debug.WriteLine("removing order");
                    SelectedCustomer.OrderList.Remove(SelectedCustomer.SelectedOrder);
                }
                else if (SelectedCustomer != null)
                {
                    Debug.WriteLine("removing customer");
                    CustomerList.Remove(SelectedCustomer);
                }
                else
                {
                    Debug.WriteLine("No customer or order select");
                }
                PersistencyService.SaveKundeListeAsJsonAsync(CustomerList.CustomerList);
            }
            catch (System.NullReferenceException e)
            {
                Debug.WriteLine(e);
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
