using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserForm.Common;
using UserForm.Data;
using UserForm.Models;
using MailKit.Net.Smtp;


namespace UserForm.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserFormInfo _context;

        public LoginController(UserFormInfo context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult MailCheck()
        {
            return View();
        }
        public IActionResult UploadImaage()
        {
            return View();
        }

        public int SendCodeforLog(int code)
        {
            
            try
            {               
                string check = "Your code is:" + code;                
                MimeMessage ePosta = new MimeMessage();
                ePosta.From.Add(MailboxAddress.Parse("kazmkorkmaz55@gmail.com"));
                ePosta.To.Add(MailboxAddress.Parse("kazmkorkmaz55@hotmail.com"));
                ePosta.Subject = "Konu";
                ePosta.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text=check};                
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("kazmkorkmaz55@gmail.com", "Korkmaz123");
                smtp.Send(ePosta);
                smtp.Disconnect(true);
                return (int)ResponseTypes.Success;
            }
            catch (Exception ex)
            {
                return (int)ResponseTypes.Error;
            }
   
        }     

        [HttpPost]
        public int LoginCheck(UserInformations user)
        {
            PasswordEncryption password = new PasswordEncryption();
            user.Password = password.Encode(user.Password.ToString());
            var users = _context.UserInformation.FirstOrDefault(u=>u.Email==user.Email && u.Password==user.Password);
            if (users !=null)
            {               
                return 1;
            }

            return  0;
        }

    }
}
