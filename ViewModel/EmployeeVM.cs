using MyApp.Model;
using MyApp.Utilities;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyApp.ViewModel
{
    class EmployeeVM : MainViewModel
    {
        private string _searchString;
        private string query;
        public string SearchString
        {
            get
            {
                return _searchString;
            }
            set
            {
                if (value != _searchString)
                {
                    _searchString = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public ICommand SearchCommand { get; }
        public EmployeeVM()
        {
            query = "select ID, nome, cognome, ruolo, reparto, data_assunzione, data_nascita, stipendio from dipendenti";
            LoadEmployeesAsync();
            SearchCommand = new RelayCommand(ShowString);
        }

        private async void LoadEmployeesAsync()
        {
            var employees = await DatabaseHelper.GetEmployeesAsync(query);
            foreach (var employee in employees)
            {
                Employees.Add(employee);
            }
        }


        public void ShowString(object obj)
        {
            Employees.Clear();
            if (int.TryParse(SearchString, out int num))
            {
                query = $"select ID, nome, cognome, ruolo, reparto, data_assunzione, data_nascita, stipendio from dipendenti where ID = {SearchString}";
            }
            else
            {

                query = $"select ID, nome, cognome, ruolo, reparto, data_assunzione, data_nascita, stipendio from dipendenti where nome = \"{SearchString}\" or cognome = \"{SearchString}\" or ruolo = \"{SearchString}\" or reparto = \"{SearchString}\"";

            }
            LoadEmployeesAsync();
        }

    }
}
