using RobotManagmentApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagmentApi.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Robot> Robots { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Robot>().HasData(
            new Robot() { Id = 1, OwnerName = "akshay", RobotName = "RoboMax", Location ="Junagadh", FirmwareVersion="22PQ3T", RobotFeatures= "A versatile robot designed to assist in various tasks with its advanced AI, including cleaning, cooking, and personal assistance.", ImagePath="robot.jpg" },
            new Robot() { Id = 2, OwnerName = "Omdev", RobotName = "CyberBot", Location = "Suart", FirmwareVersion = "23SOq4", RobotFeatures = "An innovative robot equipped with cutting-edge technology, capable of autonomous navigation and data analysis for research and surveillance", ImagePath = "robot6.jpg", },
            new Robot() { Id = 3, OwnerName = "Akshay", RobotName = "MechWarrior", Location = "Junagadh", FirmwareVersion = "23SOW4", RobotFeatures = "A rugged and agile robot designed for planetary exploration, equipped with high-resolution cameras and sample collection tools.", ImagePath = "robot2.jpg", },
            new Robot() { Id = 4, OwnerName = "Omdev", RobotName = "TitanTron", Location = "Suart", FirmwareVersion = "23SOD4", RobotFeatures = "A nimble flying robot with exceptional maneuverability, ideal for aerial photography and surveillance missions", ImagePath = "robot3.jpg", },
            new Robot() { Id = 5, OwnerName = "Akshay", RobotName = "GalaxyBots", Location = "Junagadh", FirmwareVersion = "23S5V4", RobotFeatures = "A medical robot with AI-driven diagnostics, capable of assisting in surgeries and patient care in hospitals.", ImagePath = "robot4.jpg", },
            new Robot() { Id = 6, OwnerName = "Omdev", RobotName = "NanoDroid", Location = "Suart", FirmwareVersion = "23S6X4", RobotFeatures = "An agricultural robot designed to automate farming tasks, including planting, watering, and harvesting crops.", ImagePath = "robot5.jpg", }
            );

        }
    }
}
    