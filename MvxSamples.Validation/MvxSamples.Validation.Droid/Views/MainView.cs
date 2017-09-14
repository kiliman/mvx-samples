using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MvxSamples.Validation.Core.ViewModels;

namespace MvxSamples.Validation.Droid.Views
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            Title = "Main";
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }
    }
}
