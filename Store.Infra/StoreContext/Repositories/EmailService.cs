using Store.Domain.StoreContext.Services;

namespace Store.Infra.StoreContext.Repositories
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string from, string subject, string body)
        {
            //TODO
        }
    }
}