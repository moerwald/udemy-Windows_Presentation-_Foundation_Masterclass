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
        }

        private User _user;

        public event PropertyChangedEventHandler? PropertyChanged;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();

            }
        }

        private Visibility _loginVisible;

        public Visibility LoginVisible
        {
            get { return _loginVisible; }
            set
            {
                _loginVisible = value;
                OnPropertyChanged();
            }
        }

        private Visibility _registerVisible;

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
                LoginVisible = Visibility.Hidden;
                RegisterVisible = Visibility.Visible;
                return;
            }

            LoginVisible = Visibility.Visible;
            RegisterVisible = Visibility.Hidden;
        }

        public RegisterCommand RegisterCommand { get; }
        public LoginCommand LoginCommand { get; }

        private void OnPropertyChanged([CallerMemberName] string? method = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(method));
    }
}
