using System;
using System.Threading.Tasks;

namespace MvxSamples.Validation.Core.Services
{
    internal class SigninService : ISigninService
    {
        public async Task<bool> SigninAsync(string email, string password)
        {
            // simulate network access
            await Task.Delay(TimeSpan.FromSeconds(3));
            return true;
        }

        public void Signout()
        {
        }
    }
}