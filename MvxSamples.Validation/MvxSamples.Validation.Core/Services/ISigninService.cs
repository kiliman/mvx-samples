using System.Threading.Tasks;

namespace MvxSamples.Validation.Core.Services
{
    public interface ISigninService
    {
        Task<bool> SigninAsync(string email, string password);
    }
}