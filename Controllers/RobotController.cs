using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotManagmentApi.context;
using RobotManagmentApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        AppDbContext _Robots;

        public RobotController(AppDbContext robots)
        {
            _Robots = robots;
        }

        [Authorize] // Requires authentication using JWT token
        [HttpPost]
        [Route("addRobot")]
        public async Task<IActionResult> AddRobot([FromForm] Robot robot)
        {

       var existingRobot = _Robots.Robots.SingleOrDefault(each => each.RobotName == robot.RobotName);

           if (existingRobot != null)
           {
                   return Ok("Duplicate Robot Not allowed");
              }

                if (robot.Image != null && robot.Image.Length > 0)
                {
                    var imageName = Guid.NewGuid().ToString() + Path.GetExtension(robot.Image.FileName);
                    var imagePath = Path.Combine("images", imageName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await robot.Image.CopyToAsync(stream);
                    }

                    robot.ImagePath = imageName; // Save the image name in the database
                }

                //robot.Date = DateTime.Now;
                _Robots.Robots.Add(robot);
                await _Robots.SaveChangesAsync();

                return Ok("Robot Added Successfully");
        }
        [Authorize] // Requires authentication using JWT token
        [HttpDelete]
        [Route("deleteRobot/{id}")]
        public async Task<IActionResult> DeleteRobot(int id)
        {
            var robot = await _Robots.Robots.FindAsync(id);

            if (robot == null)
            {
                return NotFound("Robot not found");
            }

            _Robots.Robots.Remove(robot);
            await _Robots.SaveChangesAsync();

            return Ok("Robot deleted successfully");
        }

        [HttpGet]
        [Route("getAllRobots")]
        public IActionResult GetAllRobots()
        {
            var robots = _Robots.Robots.ToList();

            return Ok(robots);
        }
            
        [Authorize] // Requires authentication using JWT token
        [HttpPut]
        [Route("updateRobot")]
        public async Task<IActionResult> UpdateRobot([FromForm] Robot updatedRobot)
        {
            var robot = await _Robots.Robots.FindAsync(updatedRobot.Id);
            if (robot == null)
            {
                return NotFound("Robot not found");
            }

            // Update the properties of the existing robot
            robot.RobotName = updatedRobot.RobotName;
            robot.OwnerName = updatedRobot.OwnerName;
            robot.RobotFeatures = updatedRobot.RobotFeatures;
            robot.Location = updatedRobot.Location;
            robot.FirmwareVersion = updatedRobot.FirmwareVersion;

            if (updatedRobot.Image != null && updatedRobot.Image.Length > 0)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(updatedRobot.Image.FileName);
                var imagePath = Path.Combine("images", imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await updatedRobot.Image.CopyToAsync(stream);
                }
                robot.ImagePath = imageName; // Save the new image name in the database
            }

            await _Robots.SaveChangesAsync();

            return Ok("Robot updated successfully");
        }

    }
}
