using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    class TransactionVM : Utilities.MainViewModel
    {
        private readonly PageModel _pageModel;

        public decimal TransactionAmount
        {
            get
            {
                return _pageModel.TransactionValue;
            }
            set
            {
                _pageModel.TransactionValue = value;
                OnPropertyChanged();
            }
        }
        public TransactionVM()
        {
            _pageModel = new PageModel();
            TransactionAmount = 2000;
        }
    }
}
