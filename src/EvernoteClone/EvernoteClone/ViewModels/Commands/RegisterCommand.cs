using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModels.Commands
{
    public class RegisterCommand : BaseCommand
    {
        public RegisterCommand(LoginViewModel loginViewModel) => LoginViewModel = loginViewModel;

        public LoginViewModel LoginViewModel { get; }

        public override bool CanExecute(object? parameter)
        {
            if (parameter is not User user)
            {
                return false;
            }

            return !LoginViewModel.UserPropertiesForRegisterInValid();
        }

        public override void Execute(object? parameter)
        {
            // Todo
        }
    }
}
