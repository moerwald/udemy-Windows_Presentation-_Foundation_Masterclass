using EvernoteClone.Model;
using EvernoteClone.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModels
{
    public class LoginViewModel  : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }

        private User _user;

        public event PropertyChangedEventHandler? PropertyChanged;

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public RegisterCommand RegisterCommand { get; }
        public LoginCommand LoginCommand { get; }
    }
}
