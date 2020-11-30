using System.Threading.Tasks;

namespace BusCarrier.Util.Helpers
{
    public interface IMailSender
    {
        Task SendMail(string address, string subject, string text);
    }
}