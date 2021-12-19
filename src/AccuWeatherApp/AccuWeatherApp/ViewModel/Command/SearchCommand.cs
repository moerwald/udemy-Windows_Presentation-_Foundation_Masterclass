using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccuWeatherApp.ViewModel.Command
{
    public class SearchCommand : ICommand
    {

        public SearchCommand(WeatherViewModel vm) => Vm = vm;

        public WeatherViewModel Vm { get; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            Debug.WriteLine(nameof(CanExecute));

            if (parameter is null || (parameter is string query && string.IsNullOrWhiteSpace(query)))   
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.MakeQueryAsync();
        }
    }
}
