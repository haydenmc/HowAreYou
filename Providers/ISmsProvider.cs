using System.Threading.Tasks;

namespace HowAreYou.Providers
{
    public interface ISmsProvider
    {
        Task SendSms(string phoneNumber, string body);
    }
}