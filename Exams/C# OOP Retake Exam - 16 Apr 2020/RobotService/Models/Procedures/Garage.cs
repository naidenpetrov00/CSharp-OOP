namespace RobotService.Models.Procedures
{
    using RobotService.Models.Garages.Contracts;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Garage : IGarage
    {
        private const int Capacity = 10;

        private Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.Robots.Count == 10)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.Robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robots.First(r => r.Key.Equals(robotName)).Value.Owner = ownerName;
            this.robots.First(r => r.Key.Equals(robotName)).Value.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
