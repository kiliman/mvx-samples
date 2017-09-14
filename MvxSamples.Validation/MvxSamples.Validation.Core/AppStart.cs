using MvvmCross.Core.Navigation;
using MvxSamples.Validation.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace MvxSamples.Validation.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly IMvxNavigationService _navigationService;

        public AppStart(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        /// <summary>
        /// Start is called on startup of the app
        /// Hint contains information in case the app is started with extra parameters
        /// </summary>
        public void Start(object hint = null)
        {
            _navigationService.Navigate<SigninViewModel>().GetAwaiter().GetResult();
        }
    }
}