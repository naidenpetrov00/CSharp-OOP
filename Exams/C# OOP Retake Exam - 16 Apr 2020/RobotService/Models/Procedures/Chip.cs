namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;
    using RobotService.Utilities.Messages;
    using System;

    public class Chip : Procedure
    {
        private const int ReductionOfHappiness = 5;

        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Happiness -= ReductionOfHappiness;

            if (this.Robots.Contains(robot))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            this.Robots.Add(robot);

            ProcedureTimeRemover(robot, procedureTime);
        }
    }
}
