using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagmentApi.Models
{
    public class Robot
    {
        public int Id { get; set; }
        public string RobotName { get; set; }
        public string OwnerName { get; set; }
        public string Location { get; set; }
        public string FirmwareVersion { get; set; }
        public string RobotFeatures { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
