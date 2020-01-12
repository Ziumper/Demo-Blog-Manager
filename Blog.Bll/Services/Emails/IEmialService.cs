using System.Collections.Generic;
using Blog.Bll.Services.Emails.Models;

namespace Blog.Bll.Services.Emails {
    public interface IEmailService {
        void Send(EmailMessage emailMessage);
	    List<EmailMessage> ReceiveEmail(int maxCount = 10);
        bool ShouldSendingEmail();
    }
}