using RobotManagmentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagmentApi.UtilityService
{
    public interface IEmailService
    {
        void sendEmail(EmailModel emailModel);

    }
}
