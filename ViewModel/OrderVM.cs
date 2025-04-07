using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    class OrderVM : Utilities.MainViewModel
    {
        private readonly PageModel _pageModel;
        public DateOnly DisplayOrderDate
        {
            get
            {
                return _pageModel.OrderDate;
            }
            set
            {
                _pageModel.OrderDate = value;
                OnPropertyChanged();
            }
        }

        public OrderVM()
        {
            _pageModel = new PageModel();
            DisplayOrderDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
