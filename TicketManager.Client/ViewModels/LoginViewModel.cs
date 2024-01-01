
/* Unmerged change from project 'TicketManager.Client (net7.0-windows10.0.19041.0)'
Before:
using System;
After:
using Microsoft.Toolkit.Mvvm.Input;
using System;
*/

/* Unmerged change from project 'TicketManager.Client (net7.0-maccatalyst)'
Before:
using System;
After:
using Microsoft.Toolkit.Mvvm.Input;
using System;
*/

/* Unmerged change from project 'TicketManager.Client (net7.0-ios)'
Before:
using System;
After:
using Microsoft.Toolkit.Mvvm.Input;
using System;
*/
using Microsoft.Toolkit.Mvvm.Input;
using System.Security;
using System.Windows.Input;


namespace TicketManager.Client.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new AsyncRelayCommand(async () => await LoginAsync());
            RegisterCommand = new AsyncRelayCommand(async () => await RegisterAsync());
            ForgotPasswordCommand = new AsyncRelayCommand(async () => await GetNewPasswordAsync());

        }
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username == value) return;
                _username = value;
                OnPropertyChanged();
            }
        }

        private SecureString _password;
        public SecureString Password
        {
            get { return _password; }
            set
            {
                if (_password == value) return;
                _password = value;
                OnPropertyChanged();
            }
        }


        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        public ICommand ForgotPasswordCommand { get; set; }


        public async Task<Task> LoginAsync()
        {
            return Task.CompletedTask;
        }

        public async Task<Task> RegisterAsync()
        {
            return Task.CompletedTask;
        }

        public async Task<Task> GetNewPasswordAsync()
        {
            return Task.CompletedTask;
        }
    }
}
