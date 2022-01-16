using EvernoteClone.Model;
using EvernoteClone.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows;

namespace EvernoteClone.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
            LoginVisible = Visibility.Visible;
            RegisterVisible = Visibility.Collapsed;
            SwitchLoginRegisterCommand = new SwitchLoginRegisterCommand(this);
            User = new User();
        }

        public bool UserPropertiesForRegisterInValid()
        {
            if (string.IsNullOrEmpty(User.Name))
                return true;
            if (string.IsNullOrEmpty(User.LastName))
                return true;
            if (string.IsNullOrEmpty(User.Username))
                return true;
            if (string.IsNullOrEmpty(User.Password))
                return true;
            if (string.IsNullOrEmpty(ConfirmedPassword))
                return true;
            if (ConfirmedPassword != User.Password)
                return true;

            return false;
        }

        private User _user;
        private Visibility _loginVisible;
        private Visibility _registerVisible;
        private string _userName;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _confirmedPassword;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                User = new User
                {
                    Name = value,
                    LastName = LastName,
                    Username = UserName,
                    Password = Password,
                };
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;

                User = new User
                {
                    Name = FirstName,
                    LastName = value,
                    Username = UserName,
                    Password = Password,
                };
                OnPropertyChanged();
            }
        }

        public string ConfirmedPassword
        {
            get { return _confirmedPassword; }
            set
            {
                _confirmedPassword = value;
                OnPropertyChanged();
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                User = new User
                {
                    Name = User.Name,
                    LastName = User.LastName,
                    Username = value,
                    Password = Password
                };
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

                User = new User
                {
                    Name = User.Name,
                    LastName = User.LastName,
                    Username = UserName,
                    Password = value
                };

                OnPropertyChanged();
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoginVisible
        {
            get { return _loginVisible; }
            set
            {
                _loginVisible = value;
                OnPropertyChanged();
            }
        }

        public Visibility RegisterVisible
        {
            get { return _registerVisible; }
            set
            {
                _registerVisible = value;
                OnPropertyChanged();
            }
        }

        public SwitchLoginRegisterCommand SwitchLoginRegisterCommand { get; }

        public void SwitchLoginRegister()
        {
            if (LoginVisible == Visibility.Visible)
            {
                LoginVisible = Visibility.Collapsed;
                RegisterVisible = Visibility.Visible;
                return;
            }

            LoginVisible = Visibility.Visible;
            RegisterVisible = Visibility.Collapsed;
        }

        public RegisterCommand RegisterCommand { get; }
        public LoginCommand LoginCommand { get; }

        private void OnPropertyChanged([CallerMemberName] string? method = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(method));
    }
}
