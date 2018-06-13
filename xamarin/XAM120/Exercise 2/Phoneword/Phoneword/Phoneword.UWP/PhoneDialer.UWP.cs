using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Phoneword.UWP;
using Xamarin.Forms;
using Windows.ApplicationModel;

[assembly: Dependency(typeof(PhoneDialer))]

namespace Phoneword.UWP
{
    public class PhoneDialer : IDialer
    {
        public Task<bool> DialAsync(string number)
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.Calls.CallsPhoneContract", 1,0))
            {
				// todo: DPOL: How to call from UWP ? 
				//Windows.ApplicationModel.Calls
				//	.PhoneCallManager.ShowPhoneCallUI(number, "Phoneword");

               return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}