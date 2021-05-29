﻿using LessonWebProject.Common.Models.DB;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.Generic;
using LessonWebProject.Data.Repository.Interfaces;
using LessonWebProject.Data;
using System.Linq;

namespace LessonWebProject.EmailSender
{
    public class SenderService
    {
        private readonly IFoundAdsRepository _foundTaskRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        public SenderService(IFoundAdsRepository foundTaskRepository, ApplicationDbContext applicationDbContext)
        {
            _foundTaskRepository = foundTaskRepository;
            _applicationDbContext = applicationDbContext;
        }
       
        private  async Task SendEmailAsync(string emailRecipient, IEnumerable<FoundAdDBModel> foundAdDBModel)
        {
            MailMessage m = new MailMessage(StaticParameters.EmailSender, emailRecipient);
            m.Subject = StaticParameters.Title;
            m.Body = $"{StaticParameters.HelloMessage} \r\n";
            foreach (var ad in foundAdDBModel)
            {
                string a = $"Категория:{ad.CategoryType} \r\n" +
                                $"Цена: {ad.Price} \r\n" +
                                $"Описание {ad.Description} \r\n" +
                                $"Телефон{ad.Phone} \r\n ";

                m.Body = string.Concat(m.Body, a);
            }
        
            SmtpClient smtp = new SmtpClient(StaticParameters.Host, StaticParameters.Port);
            smtp.Credentials = new NetworkCredential(StaticParameters.UserCredentialName, StaticParameters.UserCredentialPassword);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }

        public void DoSending()
        {
            var ads = _foundTaskRepository.GetAllFoundAds();

            var usersID = ads.Select(t => t.UserID).Distinct();
            foreach (var userId in usersID)
            {
                var adsByUser = ads.Where(t => t.UserID == userId);
                if (adsByUser.Count() > 0)
                {
                    var emailRecipient = _applicationDbContext.GetEmailByID(userId);
                    SendEmailAsync(emailRecipient, adsByUser).GetAwaiter();
                }
            }
        }
    }
}
