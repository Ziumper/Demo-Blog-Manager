using System.Collections.Generic;
using Blog.Bll.Services.Emails.Models;
using Blog.Dal.Models;

namespace Blog.Bll.Services.Emails {
    public interface IEmailService {
        void Send(EmailMessage emailMessage);
	    List<EmailMessage> ReceiveEmail(int maxCount = 10);
        bool ShouldSendingEmail();
        EmailMessage GetRegisterEmailMessage (User user);
    }
}