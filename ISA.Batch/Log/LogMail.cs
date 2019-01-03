using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace ISA.Batch
{
    public class LogMail
    {
        private string smtpHost;
        private int mailPort;
        private string mailFrom;
        private ArrayList mailTo;
        private ArrayList mailCC;
        private string mailPassword;
        private bool attachmentIncluded;

        private ArrayList GetMailAddressList(string mailAddress)
        {
            ArrayList addressList = new ArrayList();

            if (mailAddress != string.Empty)
            {
                char[] separator = new char[] { ',' };

                string[] recipients = mailAddress.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (recipients.Length > 0)
                {
                    foreach (string recipient in recipients)
                        addressList.Add(recipient.Trim());
                }
                else
                {
                    addressList.Add(mailAddress.Trim());
                }
            }

            return addressList; 
        }

        public LogMail()
        {
            this.smtpHost = AppSetting.GetRow("MAIL_SMTP").Value;
            this.mailPort = Convert.ToInt32(AppSetting.GetRow("MAIL_PORT").Value);
            this.mailFrom = AppSetting.GetRow("MAIL_FROM").Value;
            this.mailTo = this.GetMailAddressList(AppSetting.GetRow("MAIL_TO").Value);
            this.mailCC = this.GetMailAddressList(AppSetting.GetRow("MAIL_CC").Value);
            this.mailPassword = AppSetting.GetRow("MAIL_PASSWORD").Value;
            this.attachmentIncluded = Convert.ToInt32(AppSetting.GetRow("MAIL_ATTACHMENT").Value) != 0;
        }

        public bool SendMail(string mailSubject, string mailBody, string attachmentFileName)
        {
            bool isSent = false;

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(this.mailFrom);

                foreach (string to in this.mailTo)
                {
                    mail.To.Add(to);
                }

                foreach (string cc in this.mailCC)
                {
                    mail.CC.Add(cc);
                }

                mail.Subject = mailSubject;
                mail.Body = mailBody;

                if (this.attachmentIncluded && !String.IsNullOrEmpty(attachmentFileName))
                    mail.Attachments.Add(new Attachment(attachmentFileName));

                SmtpClient smtpServer = new SmtpClient(this.smtpHost);
                smtpServer.Port = this.mailPort;
                smtpServer.Credentials = new System.Net.NetworkCredential(this.mailFrom, this.mailPassword);
                smtpServer.EnableSsl = true;
                smtpServer.Timeout = (60 * 5 * 1000);

                smtpServer.Send(mail);

                isSent = true;

                return isSent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
