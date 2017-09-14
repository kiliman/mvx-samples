using Android.App;
using Android.OS;
using Android.Provider;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvxSamples.Validation.Core.ViewModels;

namespace MvxSamples.Validation.Droid.Views
{
    [Activity(Label = "Sign in")]
    public class SigninView : MvxAppCompatActivity<SigninViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SigninView);
        }

        
        public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Enter)
            {
                Signin();
                return true;
            }
            return base.OnKeyUp(keyCode, e);
        }

        private void Signin()
        {
            ViewModel.SigninCommand.Execute(null);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.signin_menu, menu);
            return true;
        }
    }
}