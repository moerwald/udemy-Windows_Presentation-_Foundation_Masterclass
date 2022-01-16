using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModels.Commands
{
    public class LoginCommand : BaseCommand
    {
        public LoginCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public LoginViewModel LoginViewModel { get; }

        public override bool CanExecute(object? parameter)
        {
            if (parameter is not User user)
            {
                return false;
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                return false;
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                return false;
            }

            return true;
        }

        public override void Execute(object? parameter)
        {
        }
    }
}
