using System;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvxSamples.Validation.Core.Common;
using MvvmValidation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvxSamples.Validation.Core.Services;

namespace MvxSamples.Validation.Core.ViewModels
{
    public class SigninViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ISigninService _signinService;
        private ValidationHelper _validator;

        public SigninViewModel(IMvxNavigationService navigationService, ISigninService signinService)
        {
            _navigationService = navigationService;
            _signinService = signinService;
            _validator = new ValidationHelper();
        }

        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; RaisePropertyChanged(() => Email); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; RaisePropertyChanged(() => Password); }
        }

        private string _result;
        public string Result
        {
            get => _result;
            set { _result = value; RaisePropertyChanged(() => Result); RaisePropertyChanged(() => HasResult); }
        }

        public bool HasResult => string.IsNullOrEmpty(Result) == false;

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }

        private ObservableDictionary<string, string> _errors;
        public ObservableDictionary<string, string> Errors
        {
            get => _errors;
            set { _errors = value; RaisePropertyChanged(() => Errors); }
        }

        private MvxCommand _signinCommand;

        public ICommand SigninCommand
        {
            get
            {
                _signinCommand = _signinCommand ?? new MvxCommand(DoSignin);
                return _signinCommand;
            }
        }


        private async void DoSignin()
        {
            try
            {
                if (!Validate())
                {
                    return;
                }

                IsBusy = true;
                Result = "";
                var success = await _signinService.SigninAsync(Email, Password);

                if (success)
                {
                    Result = "";
                    await _navigationService.Navigate<MainViewModel>();
                    Close(this);
                    return;
                }

                Result = "Invalid email/password. Please try again.";
            }
            catch (Exception ex)
            {
                Result = "Error occured during sign in.";
                Mvx.Error(ex.ToString());
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool Validate()
        {
            _validator = new ValidationHelper();
            _validator.AddRequiredRule(() => Email, "Email is required.");
            _validator.AddRequiredRule(() => Password, "Password is required.");

            var result = _validator.ValidateAll();

            Errors = result.AsObservableDictionary();

            return result.IsValid;
        }
    }
}