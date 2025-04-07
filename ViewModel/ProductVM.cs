using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    class ProductVM : Utilities.MainViewModel
    {
        private readonly PageModel _pageModel;

        public string ProductAvaliability
        {
            get
            {
                return _pageModel.ProductStatus;
            }
            set
            {
                _pageModel.ProductStatus = value;
                OnPropertyChanged();
            }
        }

        public ProductVM()
        {
            _pageModel = new PageModel();
            ProductAvaliability = "Out Of Stock";
        }
    }
}
