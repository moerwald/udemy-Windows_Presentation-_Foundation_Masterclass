using EvernoteClone.ViewModels.Commands;

namespace EvernoteClone.ViewModels
{
    public class SwitchLoginRegisterCommand : BaseCommand
    {
        private LoginViewModel _loginViewModel;

        public SwitchLoginRegisterCommand(LoginViewModel loginViewModel) 
            => _loginViewModel = loginViewModel;

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter) => _loginViewModel.SwitchLoginRegister();
    }
}