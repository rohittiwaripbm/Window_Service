using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace WindowsService1
{
    public class EmailValidations
    {

        //Check for Email Format
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // Regular expression pattern for email validation
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Check if the email matches the pattern
            return Regex.IsMatch(email, pattern);

        }
        public void MailChecker(string email)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("rohittiwarismtp@gmail.com", "kfsmagpgvaazvosx");

            try
            {
                // Create a new mail message
                MailMessage message = new MailMessage();
                message.From = new MailAddress("rohittiwarismtp@gmail.com");
                message.To.Add(email);
                message.Subject = "Testing SMTP email";
                message.Body = "This is a test email sent using SMTP in C#.";

                // Send the message
                client.Send(message);

            }
            catch (Exception ex)
            {
                string path = @"C:\Users\rohit\Desktop\FindingErrors.txt";
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine("Unable to find :   " + email);
                    sw.Close();
                }

            }

            finally
            {
                // Dispose of the client
                client.Dispose();
            }

        }
        
    }
}
