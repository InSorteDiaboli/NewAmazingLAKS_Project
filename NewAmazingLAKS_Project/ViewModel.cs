using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Eventmaker.Common;
using NewAmazingLAKS_Project.Annotations;
using NewAmazingLAKS_Project.Model;

namespace NewAmazingLAKS_Project
{
    class ViewModel : INotifyPropertyChanged
    {
        private ICommand _removeCommand;
        private ICommand _loadCommand;
        private ICommand _saveCommand;

        #region Customer
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string Att { get; set; }
        public string Address { get; set; }
        public int PostalNo { get; set; }
        public string PhoneNo { get; set; }
        private static int _count;

        public CustomerCatalog CustomerList => CustomerCatalog.Instance; //set 

        public ObservableCollection<Order> OrderList { get; set; }
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
        public double Levprice { get; set; }
        public int Levamount { get; set; }

        #endregion

        public Order SelectedOrder { get; set; }

        public ViewModel()
        {
            _removeCommand = new RelayCommand(Remove);
            _loadCommand = new RelayCommand(Load);
            //_saveCommand = new RelayCommand(Save);
            CustomerList.Add("name", "att", "adr", 4000, "tlf"); //Testdata
            foreach (var customer in CustomerList.CustomerList) //is this right??? ved ikke om det her er den rigtige måde at benytte OrderList proppen, for vi har den jo også i Customer-klassen
            {
                customer.OrderList.Add(new Order("some date", 4, "filedate"));
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

        public void Add()
        {
            OrderList.Add(new Order(LevDate, Blok, FileDate));
            OnPropertyChanged();
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
            foreach (var order in OrderList)
            {

                if (order.OrderNo == SelectedOrder.OrderNo)
                {

                    OrderList.Remove(SelectedOrder);
                    break;

                }
                OnPropertyChanged();

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
