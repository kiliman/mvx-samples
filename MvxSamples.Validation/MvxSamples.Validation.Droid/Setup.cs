using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;

namespace MvxSamples.Validation.Droid
{
    public class Setup : MvxAndroidSetup
    {
        private readonly Context _applicationContext;

        public Setup(Context applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}
