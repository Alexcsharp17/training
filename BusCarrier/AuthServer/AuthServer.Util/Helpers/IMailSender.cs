using System.Threading.Tasks;

namespace AuthServer.Util.Helpers
{
    public interface IMailSender
    {
        Task SendMail(string address, string subject, string text);
    }
}