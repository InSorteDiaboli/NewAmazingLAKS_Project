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

        #region Customer
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string Att { get; set; }
        public string Address { get; set; }
        public int PostalNo { get; set; }
        public string PhoneNo { get; set; }

        public CustomerCatalog CustomerList => CustomerCatalog.Instance; //set 

        public ObservableCollection<Order> OrderList { get; set; }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                Debug.WriteLine($"set customer to {CustomerName}");
            }
        }

        #endregion

        #region Order

        
        public int OrderNo { get; set; }
        public string LevDate { get; set; }
        public int Blok { get; set; }
        public string FileDate { get; set; }
        public ObservableCollection<Product> ProductList { get; set; }

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

        public ViewModel()
        {
            _removeCommand = new RelayCommand(Remove);
            _addCustomerCommand = new RelayCommand(AddCustomer);
            _loadCommand = new RelayCommand(Load);
            _addOrderCommand = new RelayCommand(AddOrder);
            //_saveCommand = new RelayCommand(Save);
            //CustomerList.Add("name", "att", "adr", 4000, "tlf"); //Testdata
            foreach (var customer in CustomerList.CustomerList) //is this right??? ved ikke om det her er den rigtige måde at benytte OrderList proppen, for vi har den jo også i Customer-klassen
            {
                //customer.OrderList.Add(new Order("some date", 4, "filedate"));
                OrderList = customer.OrderList;
            }
       


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

        public void AddCustomer()
        {
            CustomerList.Add(new Customer(CustomerName, Att, Address, PostalNo, PhoneNo));
            OnPropertyChanged();
            PersistencyService.MessageDialogHelper.Show("Kunde tilføjet", "Msg");
        }

        public void AddOrder()
        {
            OrderList.Add(new Order(LevDate, Blok, FileDate));
            OnPropertyChanged();
            PersistencyService.SaveKundeListeAsJsonAsync(CustomerList.CustomerList);
            PersistencyService.MessageDialogHelper.Show("Ordre tilføjet", "Msg");
        }

        public void AddProduct()
        {
            SelectedCustomer.SelectedOrder.ProductList.Add(new Product(Productname, Productsize, Amount, Media, Folie,
                Laminate, Producttype, Productprice, Levprice, Levamount, Percent));
            OnPropertyChanged();
            PersistencyService.SaveKundeListeAsJsonAsync(CustomerList.CustomerList);
            PersistencyService.MessageDialogHelper.Show("Produkt tilføjet", "Msg");
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

            if (SelectedCustomer.SelectedOrder != null)
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
