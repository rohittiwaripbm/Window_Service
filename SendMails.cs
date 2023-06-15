using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace WindowsService1
{
    public class SendMails
    {
        public SendMails() 
        {
            #region Variables
            EmailValidations validations = new EmailValidations();
            FetchData GetData = new FetchData();
            List<UserTable> list = new List<UserTable>();

            DataTable dt = GetData.Fetch();
            #endregion




            foreach (DataRow row in dt.Rows)
            {
                UserTable table = new UserTable();
                table.Id = Convert.ToInt32(row["ID"]);
                table.Name = Convert.ToString(row["Name"]);
                table.Email = Convert.ToString(row["email"]);
                table.Mobile_no = Convert.ToInt32(row["mob_no"]);
                table.IsActive = Convert.ToBoolean(row["IsActive"]);
                list.Add(table);
            }
            //List<UserTable> Mails = GetData.Fetch();
            foreach (var item in list)
            {
                bool Check = validations.IsValidEmail(item.Email);
                if (Check)
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("rohittiwarismtp@gmail.com", "kfsmagpgvaazvosx");
                    try
                    {
                        // Create a new mail message
                        MailMessage message = new MailMessage();
                        message.From = new MailAddress("rohittiwarismtp@gmail.com");
                        message.To.Add(item.Email);
                        message.Subject = "Testing SMTP email";
                        message.Body = "This is a test email sent using SMTP in C#.";
                        // Send the message
                        client.Send(message);
                        string path = "C:\\Users\\rohit\\Desktop\\Successmails.txt";
                        using (StreamWriter sw = new StreamWriter(path, true))
                        {
                            sw.WriteLine(DateTime.Now + " " + "Send Mails to  :   " + item.Email + " Where User id is " +
                                "" + item.Id + " & User name is " + item.Name);
                            sw.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        string path = "C:\\Users\\rohit\\Desktop\\FindingErrors.txt";
                        using (StreamWriter sw = new StreamWriter(path, true))
                        {
                            sw.WriteLine(DateTime.Now +" "+"Unable to Send Mails to  :   " + item.Email + " Where User id is " +
                                "" + item.Id + " & User name is " + item.Name);
                            sw.Close();
                        }
                    }
                    finally
                    {
                        // Dispose of the client
                        client.Dispose();
                    }
                }
                else
                {
                    string path = "C:\\Users\\rohit\\Desktop\\Demo1.txt";
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine(DateTime.Now + " " + "Getting Format Error in  " + item.Email+ " Where User id is " +
                            "" + item.Id + " & User name is " + item.Name);
                        sw.Close();
                    }
                }
            }
        }  
    }
}
