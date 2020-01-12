using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Blog.Bll.Services.Emails.Models;
using Blog.Dal.Models;
using Microsoft.AspNetCore.Http;
using Blog.Bll.Exceptions;

namespace Blog.Bll.Services.Emails {
    public class EmailService : IEmailService {
        protected readonly IEmailConfiguration _emailConfiguration;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public EmailService (
            IEmailConfiguration emailConfiguration,
            IHttpContextAccessor htttpContextAccessor
            ) {
            _emailConfiguration = emailConfiguration;
            _httpContextAccessor = htttpContextAccessor;
        }

        public EmailMessage GetRegisterEmailMessage(User user)
        {
            EmailMessage emailMesssage = new EmailMessage ();
            emailMesssage.FromAddresses = new List<EmailAddress> ();
            emailMesssage.ToAddresses = new List<EmailAddress> ();

            EmailAddress emailAddres = new EmailAddress ();
            emailAddres.Address = "demom@email.com";
            emailAddres.Name = "demo bot";
            emailMesssage.FromAddresses.Add (emailAddres);

            EmailAddress userEmailAddres = new EmailAddress ();
            userEmailAddres.Name = user.FirstName + " " + user.LastName;
            userEmailAddres.Address = user.Email;
            emailMesssage.ToAddresses.Add (userEmailAddres);

            emailMesssage.Subject = "Activation code";

            var host = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";

            emailMesssage.Content = "Please go to " + host + "/activation/" + user.Id + " and a activate your account<br/> Here is your activation code: <b>" + user.ActivationCode + "</b>";

            return emailMesssage;
        }

        public List<EmailMessage> ReceiveEmail (int maxCount = 10) {
            throw new NotImplementedException ();
        }

        public void Send (EmailMessage emailMessage) {

            if(!ShouldSendingEmail()) {
                throw new BadRequestException("Sending emails are not avialalbe, to turn on sedning mails please, set sending mails option in configuration");
            }
            
            var message = new MimeMessage ();
            message.To.AddRange (emailMessage.ToAddresses.Select (x => new MailboxAddress (x.Name, x.Address)));
            message.From.AddRange (emailMessage.FromAddresses.Select (x => new MailboxAddress (x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart (TextFormat.Html) {
                Text = emailMessage.Content
            };

            using (var emailClient = new SmtpClient ()) {
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect (_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort,true);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove ("XOAUTH2");

                emailClient.Authenticate (_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

                emailClient.Send (message);

                emailClient.Disconnect (true);
            }
        }

        public bool ShouldSendingEmail()
        {
            return this._emailConfiguration.SendingEmail;
        }
    }
}